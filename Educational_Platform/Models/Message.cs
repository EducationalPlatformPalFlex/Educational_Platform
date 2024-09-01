using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class Message
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [ForeignKey("CourseID")]
        public int CourseID { get; set; }
        public Course? Course { get; set; }

        [Display(Name = "Message Text")]
        [Column(TypeName = "nvarchar(max)")]
        public string? MessageText { get; set; }

        [ForeignKey("SenderID_ForMessage")]
        public int SenderID_ForMessage { get; set; }
        public User? Sender { get; set; }

        [ForeignKey("ReceiverID_ForMessage")]
        public int ReceiverID_ForMessage { get; set; }
        public User? Receiver { get; set; }

        [Display(Name = "Timestamp")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Timestamp { get; set; }

        [Display(Name = "Attachment")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Attachment { get; set; }
    }
}
