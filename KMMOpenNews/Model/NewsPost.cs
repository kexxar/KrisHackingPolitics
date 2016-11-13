using System;
using System.Collections.Generic;

namespace KMMOpenNews
{
	public class NewsPost
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public string NewsType { get; set; }
		public DateTime NewsDate { get; set; }
		public ICollection<UserScore> Scores { get; set; }
		public ICollection<UserComment> UserComments { get; set; }
	}
}
