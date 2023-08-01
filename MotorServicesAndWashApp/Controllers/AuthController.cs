using Microsoft.AspNetCore.Mvc;
using MotorServicesAndWashApp.Data;
using MotorServicesAndWashApp.Models;
using MotorServicesAndWashApp.Models.Domain;
using BLL.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MotorServicesAndWashApp.Controllers
{
    [Controller]
    public class AuthController : Controller
    {
        private readonly MotorServiceDbContext _DbContext;
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
            return View();
        }

        [Route("Recovery")]
        public IActionResult Recovery()
        {
            return View();
        }

        [HttpPost("NewUser")]
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
                        RandomStringGenerator generator = new RandomStringGenerator();
                        string salt = generator.ComputeSHA256Hash(generator.GenerateRandomString(5));
                        string modifyPass = generator.ComputeSHA256Hash(userModel.password);
                        var userDetails = new UserDetails()
                        {
                            Id = Guid.NewGuid(),
                            firstName = userModel.firstName,
                            lastName = userModel.lastName,
                            email = userModel.email,
                            phoneNumber = userModel.phoneNumber,
                            city = userModel.city,
                            homeTown = userModel.homeTown,
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
                        RandomStringGenerator generator = new RandomStringGenerator();
                        var userSalt = isUser.salt;
                        var userPassword = generator.ComputeSHA256Hash(userModel.password);
                        var hashPass = userSalt + userPassword;
                        if (isUser.password != hashPass)
                        {
                            TempData["ReecoveryLink"] = "204 : Check the Password.";
                            return RedirectToAction("Login", "Auth");
                        }

                        var isLogin = await _DbContext.UserDetails.FirstOrDefaultAsync(x => x.email == userModel.email && x.password == hashPass);

                        if (isLogin != null)
                        {

                            return Ok("Login Success");
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
            if(isUser != null)
            {
                return Ok("OK");
            }
            else
            {
                TempData["Message"] = "500 : Please try again later or contact support.";
                return RedirectToAction("Recovery", "Auth");
            }
        }
    }
}
