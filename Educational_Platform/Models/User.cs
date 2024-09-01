using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Educational_Platform.Models
{
    public class User
    {
        [Key]
        [Display(Name = "Code")]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Name { get; set; }

        [Display(Name = "Photo")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Photo { get; set; }

        [Display(Name = "Address")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Address { get; set; }

        [Display(Name = "Role")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Role { get; set; }

        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Email { get; set; }

        [Display(Name = "Password")]
        [Column(TypeName = "nvarchar(max)")]
        public string? Password { get; set; }

        [Display(Name = "City")]
        [Column(TypeName = "nvarchar(max)")]
        public string? City { get; set; }
    }
}
