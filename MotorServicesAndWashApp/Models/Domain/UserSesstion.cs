using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class UserSesstion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SessionId { get; set; }
        [StringLength(100)]
        public string? UserId { get; set; }
        [StringLength(200)]
        public string? Sesston { get; set; }

        public DateTime SesstonCreateDate { get; set; }
  
        public DateTime SesstonEndDate { get; set; }
    }
}
