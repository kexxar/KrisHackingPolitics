using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KMMOpenNewsBackend.Models.DTO
{
    public class NewsPostDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public string NewsType { get; set; }

        //[Required]
        public DateTime NewsDate { get; set; } = DateTime.Now;

        //public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }

        //[Required]
        //public List<UserScore> Scores { get; set; }

        //[Required]
        //public List<UserComment> UserComments { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //[Display(Name = "Current password")]
        //public string OldPassword { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //[Display(Name = "New password")]
        //public string NewPassword { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm new password")]
        //[Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }
    }
}