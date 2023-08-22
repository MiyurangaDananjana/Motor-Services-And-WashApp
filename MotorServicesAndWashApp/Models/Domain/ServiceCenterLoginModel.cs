using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorServicesAndWashApp.Models.Domain
{
    [Table("ServiceCenterLogin")]
    public class ServiceCenterLoginModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? SystemUserPhoneNumber { get; set; }

        public string? SystemUserEmail { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public ServiceCenter? ServiceCenter { get; set; }
    }
}
