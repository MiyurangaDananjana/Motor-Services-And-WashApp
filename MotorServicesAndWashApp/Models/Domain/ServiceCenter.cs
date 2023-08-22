using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class ServiceCenter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceCenterId { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        public string? ServiceCenterName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? HotlineNumber { get; set; }

        public string? Email { get; set; }

        [Column("OpenTime")]
        public DateTime ServiceCenterOpenTime { get; set; }

        [Column("CloseTime")]
        public DateTime ServiceCenterCloseTime { get; set; }

        public string? Description { get; set; }

        public string? MapLink { get; set; }

        public Provinces? Provinces { get; set; }

        public Districts? Districts { get; set; }

        public Cities? Cities { get; set; }

        public ICollection<ServiceCenterLoginModel>? ServiceCenterLoginModel { get; set; }

        public ICollection<DaysOfCloseModel>? daysOfCloseModels { get; set; }

        public ICollection<ServiceVehicles>? ServiceVehicles { get; set; }
    }
}
