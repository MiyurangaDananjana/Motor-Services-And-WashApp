using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorServicesAndWashApp.Models.Domain
{
    public class Districts
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DistrictsId { get; set; }

        [Column("Districts_Name")]
        [MaxLength(50)]
        public string? DistrictsName { get; set; }

        public Provinces? Provinces { get; set; }

        public ICollection<Cities>? Cities { get; set; }

        public ICollection<ServiceCenter>? serviceCenters { get; set; }

    }
}
