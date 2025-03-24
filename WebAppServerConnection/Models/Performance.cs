using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppServerConnection.Models
{
    public class Performance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Date { get; set; }

        [Required]
        [StringLength(255)]
        public string Category { get; set; }

        [Required]
        [StringLength(255)]
        public string Artist { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        public string Details { get; set; }

        [StringLength(500)]
        public string Link { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int IsAvailableNum { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int ReservationNum { get; set; } = 0;  // 기본값 설정

        public void Increment()
        {
            ReservationNum++;
        }

        public override string ToString()
        {
            return $"ID: {ID}, Details: {Details}, Location: {Location}, Date: {Date}, IsAvailableNum: {IsAvailableNum}";
        }
    }
}
