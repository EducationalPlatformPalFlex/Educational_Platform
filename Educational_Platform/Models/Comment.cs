using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Comment
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("PostID")]
        public int PostID { get; set; }
        public Post? Post { get; set; }

        [ForeignKey("UserID_ForComment")]
        public int UserID_ForComment { get; set; }
        public User? User { get; set; }

        [Display(Name = "Content")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
    }
}
