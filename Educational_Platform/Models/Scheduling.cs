using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Scheduling
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("CourseTeacherID")]
        public int CourseTeacherID { get; set; }
        public CourseTeacher? CourseTeacher { get; set; }

        [ForeignKey("RegisterID")]
        public int RegisterID { get; set; }
        public Registration? Registration { get; set; }

        [Display(Name = "Conflict Status")]
        [Column(TypeName = "nvarchar(max)")]
        public string? ConflictStatus { get; set; }

        [Display(Name = "Suggestions")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Suggestions { get; set; }

        [Display(Name = "Start Hour")]
        [Column(TypeName = "nvarchar(max)")]
        public string? StartHour { get; set; }

        [Display(Name = "End Hour")]
        [Column(TypeName = "nvarchar(max)")]
        public string? EndHour { get; set; }
    }
}
