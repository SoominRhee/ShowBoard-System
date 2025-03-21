using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppServerConnection.Models
{
    public class BoardPost
    {
        [Key]  // Primary Key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Auto-Increment (IDENTITY)
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Organizer { get; set; }

        [Required]
        [StringLength(500)]
        public string Summary { get; set; }

        [Required]
        public string Details { get; set; }  // TEXT 대신 VARCHAR로 조정 가능

        [Required]
        [StringLength(50)]
        public string DisplayPeriod { get; set; }
    }
}
