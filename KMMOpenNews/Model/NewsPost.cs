using System;
using System.Collections.Generic;
using System.Linq;

namespace KMMOpenNews
{
	public class NewsPost
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public string NewsType { get; set; }
		public DateTime NewsDate { get; set; }
		public int TotalScore { 
			get {
				int score = 0;
				if (Scores != null) {
					Scores.ToList().ForEach(x => score += x.Score);
				}
				return score;
			}
		}
		public IEnumerable<UserScore> Scores { get; set; }
		public IEnumerable<UserComment> UserComments { get; set; }
	}
}
