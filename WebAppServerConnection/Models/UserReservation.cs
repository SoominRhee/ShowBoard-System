using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppServerConnection.Models
{
    public class UserReservations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public int PerformanceID { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("PerformanceID")]
        public virtual Performance Performance { get; set; }
    }
}
