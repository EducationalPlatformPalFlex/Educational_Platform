using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Teacher
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
        public User? User { get; set; }

        [Display(Name = "Academic Degree")]
        [Column(TypeName = "nvarchar(max)")]
        public string? AcademicDegree { get; set; }

        [Display(Name = "Experience")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Experience { get; set; }

        [Display(Name = "Phone Number")]
        [Column(TypeName = "int")]
        public int PhoneNumber { get; set; }

        [Display(Name = "Birthdate")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Birthdate { get; set; }
    }
}
