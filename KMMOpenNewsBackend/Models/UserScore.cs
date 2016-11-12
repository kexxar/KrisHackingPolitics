using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KMMOpenNewsBackend.Models
{
    [Table("UserScore")]
    public class UserScore
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }

        [ForeignKey("PostId")]
        public virtual NewsPost Post { get; set; }
        [Required]
        public int PostId { get; set; }

        [Required]
        public byte Score { get; set; } = 0;
    }
}