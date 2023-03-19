using System.ComponentModel.DataAnnotations;

namespace Compet.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Превышено количество символов")]
        public string Name { get; set; }
    }
}
