using System.ComponentModel.DataAnnotations;

namespace Compet.Models
{
    public class ResultsCompititions
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public Participant Participant { get; set; }
    }
}
