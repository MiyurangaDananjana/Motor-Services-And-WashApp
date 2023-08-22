using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class ServiceVehicles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public VehicleTypes? VehicleTypes { get; set; }

        public ServiceCenter? serviceCenter { get; set; }
    }
}
