using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class CourseTeacher
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("TeacherID_ForCourseTeacher")]
        public int TeacherID_ForCourseTeacher { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
