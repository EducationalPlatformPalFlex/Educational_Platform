using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class CourseStudent
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("StudentID_ForCourseStudent")]
        public int StudentID_ForCourseStudent { get; set; }
        public Student? Student { get; set; }

        [Display(Name = "Join Date")]
        [Column(TypeName = "nvarchar(max)")]
        public string? JoinDate { get; set; }
    }
}
