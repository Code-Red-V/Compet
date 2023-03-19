using System.ComponentModel.DataAnnotations;

namespace Compet.Models
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Превышено количество символов")]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }    
    }
}
