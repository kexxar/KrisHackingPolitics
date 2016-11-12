using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGrease.Css.Extensions;

namespace KMMOpenNewsBackend.Models
{
    [Table("NewsPost")]
    public class NewsPost
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        //[Required]
        //public IEnumerable<int> Scores { get; set; }
        //[Required]
        //public int Score { get; set; }
        [Required]
        public string NewsType { get; set; }
        //[NotMapped]
        //[JsonIgnore]
        //public float TotalScore {
        //    get {
        //        if (string.IsNullOrWhiteSpace(Scores)) {
        //            return 0f;
        //        }
        //        var sum = 0f;
        //        Scores.ForEach(c => {
        //            sum += (float)char.GetNumericValue(c);
        //        });
        //        return sum / Scores.Count();
        //    }
        //}
        
        [NotMapped]
        [JsonIgnore]
        public int TotalScore {
            get {
                int score = 0;
                if (Scores != null) {
                    Scores.ForEach(x => score += x.Score);
                }
                return score;
            }
        }

        [Required]
        public DateTime NewsDate { get; set; } = DateTime.MinValue;

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<UserScore> Scores { get; set; }

        public virtual ICollection<UserComment> UserComments { get; set; }
    }
}
