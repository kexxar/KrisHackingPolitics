using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface IFetchNewsService
	{
		Task<List<NewsPost>> FetchNewsList();
		Task<List<NewsPost>> FetchLatestNews();
	}
}
