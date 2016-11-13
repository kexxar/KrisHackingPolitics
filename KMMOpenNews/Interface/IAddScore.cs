using System;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface IAddScore
	{
		Task<string> AddScore(NewsPost post, int score);
	}
}
