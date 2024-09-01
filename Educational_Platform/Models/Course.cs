using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Course
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("TeacherID")]
        public int TeacherID { get; set; }
        public Teacher? Teacher { get; set; }

        [Display(Name = "Title")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Title { get; set; }

        [Display(Name = "Description")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Description { get; set; }

        [Display(Name = "Status")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Status { get; set; }

        [Display(Name = "Price")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Price { get; set; }
    }
}
