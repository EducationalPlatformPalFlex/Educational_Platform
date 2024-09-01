using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Rating
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("TeacherID_ForRating")]
        public int TeacherID_ForRating { get; set; }
        public Teacher? Teacher { get; set; }

        [ForeignKey("StudentID")]
        public int StudentID { get; set; }
        public Student? Student { get; set; }

        [Display(Name = "Rating Value")]
        [Column(TypeName = "nvarchar(max)")]
        public string? RatingValue { get; set; }

        [Display(Name = "Rating Text")]
        [Column(TypeName = "nvarchar(max)")]
        public string? RatingText { get; set; }

        [Display(Name = "View")]
        [Column(TypeName = "nvarchar(max)")]
        public string? View { get; set; }
    }
}
