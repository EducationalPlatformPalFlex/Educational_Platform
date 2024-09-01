using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Post
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User? User { get; set; }

        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }

        [Display(Name = "Photo")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Photo { get; set; }

        [Display(Name = "Type")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Type { get; set; }

        [Display(Name = "Timestamp")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Timestamp { get; set; }
    }
}
