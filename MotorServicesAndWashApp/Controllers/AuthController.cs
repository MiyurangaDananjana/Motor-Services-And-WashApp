using BLL.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorServicesAndWashApp.Data;
using MotorServicesAndWashApp.Models;
using MotorServicesAndWashApp.Models.Domain;
using EmailService;
using RestSharp;
using MotorServicesAndWashApp.BLL;

namespace MotorServicesAndWashApp.Controllers
{
    [Controller]
    public class AuthController : Controller
    {
        private readonly MotorServiceDbContext _DbContext;

        private const string Key = "MotorService";

        public AuthController(MotorServiceDbContext motorServiceDbContext)
        {
            this._DbContext = motorServiceDbContext;
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Register")]
        public IActionResult Register()
        {
            SelectionsBox selections = new SelectionsBox(_DbContext);
            ViewBag.ProvincesList = selections.GetProvinces();
            return View();
        }

        [Route("Recovery")]
        public IActionResult Recovery()
        {
            return View();
        }
        [Route("Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("New-User")]
        public async Task<IActionResult> NewUser(UserModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isUser = await _DbContext.UserDetails.FirstOrDefaultAsync(x => x.email == userModel.email);
                    if (isUser != null)
                    {
                        TempData["Message"] = "User already exists.";
                        return RedirectToAction("Register", "Auth");
                    }
                    if (userModel.password != null)
                    {
                        string salt = RandomStringGenerator.ComputeSHA256Hash(RandomStringGenerator.GenerateRandomString(5));
                        string modifyPass = RandomStringGenerator.ComputeSHA256Hash(userModel.password);
                        var userDetails = new UserDetails()
                        {
                            Id = Guid.NewGuid(),
                            firstName = userModel.firstName,
                            lastName = userModel.lastName,
                            email = userModel.email,
                            phoneNumber = userModel.phoneNumber,
                            CitiesId = userModel.Cities,
                            salt = salt,
                            password = salt + modifyPass
                        };
                        await _DbContext.UserDetails.AddAsync(userDetails);
                        await _DbContext.SaveChangesAsync();
                        TempData["Message"] = "New user saved successfully.";
                        return RedirectToAction("Register", "Auth");
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                TempData["Message"] = "500 : Please try again later or contact support.";
                return RedirectToAction("Register", "Auth");
            }
        }

        [HttpPost("User-Login")]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            try
            {
                var isUser = await _DbContext.UserDetails.FirstOrDefaultAsync(x => x.email == userModel.email);
                if (isUser != null)
                {
                    if (userModel.password != null)
                    {
                        var userSalt = isUser.salt;
                        var userPassword = RandomStringGenerator.ComputeSHA256Hash(userModel.password);
                        var hashPass = userSalt + userPassword;
                        if (isUser.password != hashPass)
                        {
                            TempData["ReecoveryLink"] = "204 : Check the Password.";
                            return RedirectToAction("Login", "Auth");
                        }

                        var isLogin = await _DbContext.UserDetails.FirstOrDefaultAsync(x => x.email == userModel.email && x.password == hashPass);
                        if (isLogin != null)
                        {
                            DateTime currentDate = DateTime.Now;

                            string Value = RandomStringGenerator.GenerateRandomString(20);
                            CookieOptions option = new CookieOptions
                            {
                                Expires = DateTime.Now.AddDays(5)
                            };
                            var isSession = await _DbContext.UserSesstions.FirstOrDefaultAsync(x => x.UserId == isLogin.Id.ToString());
                            if (isSession != null)
                            {
                                isSession.Sesston = Value;
                                await _DbContext.SaveChangesAsync();
                            }
                            else
                            {
                                UserSesstion sesstion = new UserSesstion
                                {
                                    SessionId = Guid.NewGuid(),
                                    UserId = isLogin.Id.ToString(),
                                    Sesston = Value,
                                    SesstonCreateDate = currentDate,
                                    SesstonEndDate = currentDate.AddDays(5)
                                };
                                await _DbContext.UserSesstions.AddAsync(sesstion);
                                await _DbContext.SaveChangesAsync();
                            }
                            Response.Cookies.Append(Key, Value, option);
                            return RedirectToAction("Main", "Components");
                        }
                        else
                        {
                            TempData["Message"] = "204 : User Not Registered.";
                            return RedirectToAction("Login", "Auth");
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    TempData["Message"] = "401 : User not registered.";
                    return RedirectToAction("Login", "Auth");
                }
            }
            catch (Exception)
            {
                TempData["Message"] = "500 : Please try again later or contact support.";
                return RedirectToAction("Login", "Auth");
            }
        }

        [HttpPost("Recover-Password")]
        public async Task<IActionResult> PasswordRecovery(UserModel userModel)
        {
            var isUser = await _DbContext.UserDetails.FirstOrDefaultAsync(x => x.email == userModel.email);
            if (isUser != null)
            {
                if (isUser.email != null)
                {
                    int OTPCode = RandomStringGenerator.OtpCodeGenerator();
                    // Update OTP code and Date and Time 
                    isUser.OptCode = (short)OTPCode;
                    isUser.OptCodeSendDateTime = DateTime.Now;
                    await _DbContext.SaveChangesAsync();
                    return RedirectToAction("Recovery", "Auth");
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                TempData["Message"] = "500 : Please try again later or contact support.";
                return RedirectToAction("Recovery", "Auth");
            }
        }


        public IActionResult RemoveCookie()
        {
            string value = string.Empty;
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(-1)
            };
            Response.Cookies.Append(Key, value, option);
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet("getSp")]
        public IActionResult GetSp()
        {
            var result = _DbContext.UserDetails.FromSqlRaw("SpUserDetails").ToList();
            return Ok(result);
        }
    }
}
