using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class Cities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CitiesId { get; set; }

        public string? CitiesName { get; set; }

        [StringLength(15)]
        public string? PostCode { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public Districts? Districts { get; set; }

        public ICollection<ServiceCenter>? serviceCenters { get; set; }
    }
}
