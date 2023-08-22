using Microsoft.EntityFrameworkCore;
using MotorServicesAndWashApp.Data;
using MotorServicesAndWashApp.Models;

namespace MotorServicesAndWashApp.BLL
{
    public class SelectionsBox
    {
        private readonly MotorServiceDbContext _DbContext;

        public SelectionsBox(MotorServiceDbContext motorServiceDbContext)
        {
            _DbContext = motorServiceDbContext;
        }

        public List<VehicleTypeViewModel> GetVehicleTypes()
        {
            var vehicleTypeList = _DbContext.VehicleTypes
           .Select(p => new VehicleTypeViewModel
           {
               VehicleTypeId = p.VehicleTypeId,
               VehicleTypeName = p.VehicleTypesName
           })
           .ToList();

            return vehicleTypeList;
        }

        public List<DayOfWeekViewModel> GetDayOfWeeks()
        {
            var dayOfWeekList = _DbContext.DayOfWeeks
                .Select(x => new DayOfWeekViewModel
                {
                    DayOfWeekId = x.Id,
                    DayOfWeekName = x.CalendarDays
                }).ToList();

            return dayOfWeekList;
        }

        public List<ProvincesViewModel> GetProvinces()
        {
            var provincesList = _DbContext.Provinces
                                .Select(p => new ProvincesViewModel
                                {
                                    ProvincesId = p.ProvincesId,
                                    ProvincesName = p.ProvincesName
                                })
                                .ToList();
            return provincesList;
        }



    }
}
