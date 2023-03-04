using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_ASP_Project.Models
{
    public class Publisher
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Publisher_Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Publisher_Name { get; set; }
        public string Hotline { get; set; }
        public string Publisher_Address { get; set; }
    }
}
