using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Student
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User? User { get; set; }

        [Display(Name = "Class")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Class { get; set; }

        [Display(Name = "Academic Degree")]
        [Column(TypeName = "nvarchar(max)")]
        public string? AcademicDegree { get; set; }

        [Display(Name = "Interests")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Interests { get; set; }
    }
}
