using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorServicesAndWashApp.BLL;
using MotorServicesAndWashApp.Data;

namespace MotorServicesAndWashApp.Controllers
{
    public class ServiceCenterController : Controller
    {
        private readonly MotorServiceDbContext _DbContext;

        public ServiceCenterController(MotorServiceDbContext motorServiceDbContext)
        {
            this._DbContext = motorServiceDbContext;
        }

        public IActionResult Register()
        {
            SelectionsBox selections = new SelectionsBox(_DbContext);
            ViewBag.ProvincesList = selections.GetProvinces();
            ViewBag.VehicalTypeList = selections.GetVehicleTypes();
            ViewBag.DayOfWeeksList = selections.GetDayOfWeeks();
            return View();
          
        }
    }
}
