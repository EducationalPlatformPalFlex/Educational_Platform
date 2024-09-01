using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Registration
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        [ForeignKey("StudentID_ForRegistration")]
        public int StudentID_ForRegistration { get; set; }
        public Student? Student { get; set; }

        [Display(Name = "Registeration Date")]
        [Column(TypeName = "nvarchar(max)")]
        public string? RegisterationDate { get; set; }

        [Display(Name = "Approval Status")]
        [Column(TypeName = "nvarchar(max)")]
        public string? ApprovalStatus { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Name { get; set; }

        [Display(Name = "Profile Link")]
        [Column(TypeName = "nvarchar(max)")]
        public string? ProfileLink { get; set; }
    }
}
