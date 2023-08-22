using MotorServicesAndWashApp.Controllers;
using MotorServicesAndWashApp.Data;

namespace MotorServicesAndWashApp.BLL
{
    public class UserBLL
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MotorServiceDbContext _DbContext;


        public UserBLL(ILogger<HomeController> logger, MotorServiceDbContext motorServiceDbContext)
        {
            _logger = logger;
            this._DbContext = motorServiceDbContext;
        }
    }
}
