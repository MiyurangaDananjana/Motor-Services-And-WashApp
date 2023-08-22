using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorServicesAndWashApp.Models.Domain
{
    [Table("DayOfWeeks")]
    public class DayOfWeeksModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? CalendarDays { get; set; }

        public ICollection<DaysOfCloseModel>? DaysOfCloseModel { get; set; }
    }
}
