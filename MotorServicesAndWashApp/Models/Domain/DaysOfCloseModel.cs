using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorServicesAndWashApp.Models.Domain
{
    [Table("DaysOfClose")]
    public class DaysOfCloseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ServiceCenter? ServiceCenter { get; set; }

        public DayOfWeeksModel? dayOfWeeksModel { get; set; }

    }
}
