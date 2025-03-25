using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WebAppServerConnection.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }  // Primary Key 추가

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }  // 비밀번호 저장을 위한 길이 설정


        public bool IsAdmin { get; set; } = false;

        public virtual List<UserReservations> ReservationList { get; set; } = new List<UserReservations>();  // 다대다 관계 설정
    }
}
