using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KMMOpenNewsBackend.Models
{
    [Table("UserComment")]
    public class UserComment
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Text { get; set; }

        [Required]
        public int NewsPostId { get; set; }
        [ForeignKey("NewsPostId")]
        public virtual NewsPost NewsPost { get; set; }

        [Required]
        public DateTime CommentDate { get; set; } = DateTime.MinValue;

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
    }
}