using System.ComponentModel.DataAnnotations;

namespace Compet.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        [Required]
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
