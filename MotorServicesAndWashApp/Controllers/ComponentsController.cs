
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorServicesAndWashApp.Data;
using MotorServicesAndWashApp.Models;
using MotorServicesAndWashApp.Models.Domain;
using MotorServicesAndWashApp.Selection;

namespace MotorServicesAndWashApp.Controllers
{
    [Controller]
    public class ComponentsController : Controller
    {
        private readonly MotorServiceDbContext _DbContext;
        public ComponentsController(MotorServiceDbContext motorServiceDbContext)
        {
            this._DbContext = motorServiceDbContext;
        }

        public IActionResult Main()
        {
            SelectionsBox selections = new SelectionsBox(_DbContext);
            ViewBag.vehicleTypeList = selections.GetVehicleTypes();
            ViewBag.ProvincesList = selections.GetProvinces();
            return View();
        }

        [HttpGet("GetDistrict/{Id}")]
        public IActionResult LoadDistrict(int Id)
        {
            var result = _DbContext.Districts.Where(d => d.Provinces.ProvincesId == Id).Select(x => new DistrictViewModel
            {
                DistrictsId = x.DistrictsId,
                DistrictsName = x.DistrictsName
            }).ToList();
            

            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpGet("GetCities/{Id}")]
        public IActionResult LoadCities(int Id)
        {
            var result = _DbContext.Cities.Where(d => d.Districts.DistrictsId == Id).Select(x => new CitiesViewModel
            {
                CitiesId = x.CitiesId,
                CitiesName = x.CitiesName
            }).ToList();


            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
