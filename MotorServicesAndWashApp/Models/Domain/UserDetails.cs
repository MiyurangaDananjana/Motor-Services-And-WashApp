using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class UserDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string? firstName { get; set; }
        [StringLength(100)]
        public string? lastName { get; set; }
        [StringLength(100)]
        public string? email { get; set; }
        [Phone]
        public string? phoneNumber { get; set; }
        [StringLength(100)]
        public string? city { get; set; }
        [StringLength(100)]
        public string? homeTown { get; set; }
        [StringLength(200)]
        public string? salt { get; set; }
        [StringLength(200)]
        public string? password { get; set; }

        [Range(0, 200)]
        public short OptCode { get; set; }

        public DateTime OptCodeSendDateTime { get; set; }
    }
}
