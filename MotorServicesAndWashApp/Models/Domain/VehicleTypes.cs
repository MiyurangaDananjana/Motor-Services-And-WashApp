using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class VehicleTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleTypeId { get; set; }
        [StringLength(100)]
        public string? VehicleTypesName { get; set; }

        public ICollection<ServiceCenter>? serviceCenters { get; set; }
    }
}
