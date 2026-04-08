using System.ComponentModel.DataAnnotations;

namespace Photography_WebAPI.Models
{
    public class TypeUsersModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Type { get; set; } = string.Empty;
    }
}
