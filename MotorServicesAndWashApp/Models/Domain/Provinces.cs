using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MotorServicesAndWashApp.Models.Domain
{
    [Table("Provinces")]
    public class Provinces
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProvincesId { get; set; }

        [Column("Provinces_Name")]
        [MaxLength(50)]
        public string? ProvincesName { get; set; }

        public ICollection<Districts>? Districts { get; set; }
        public ICollection<ServiceCenter>? serviceCenters { get; set; }


    }
}
