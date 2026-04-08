using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography_WebAPI.Models
{
    public class PhotographersModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Materno { get; set; }

        [Required]
        [MaxLength(100)]
        public string Paterno { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string UrlFoto { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string Instagram { get; set; }

        [Required]
        [MaxLength(200)]
        public string Facebook { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Biography { get; set; }

        [Required]
        public int Type_User { get; set; }

        
    }
}
