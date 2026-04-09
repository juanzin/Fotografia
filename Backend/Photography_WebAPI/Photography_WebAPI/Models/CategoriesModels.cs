using System.ComponentModel.DataAnnotations;

namespace Photography_WebAPI.Models
{
    public class CategoriesModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
