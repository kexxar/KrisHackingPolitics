using System;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface IAddNews
	{
		Task<bool> AddNews(string Title, string NewsType, string Desctipiton);
	}
}
