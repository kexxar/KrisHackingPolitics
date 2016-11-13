using System;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface IAddScore
	{
		Task<bool> AddScore(NewsPost post, int score);
	}
}
