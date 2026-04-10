using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photography_WebAPI.Models
{
    public class PhotosModels
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public DateTime Created_date { get; set; }

        [Required]
        public int Photographer_Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Url_Photo { get; set; } = string.Empty;

        [Required]
        public int Category_Id { get; set; }

    }
}
