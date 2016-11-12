using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KMMOpenNews
{
	public interface ISearchService
	{
		Task SearchInstitucije(string query, Action<List<Institucija>> callback);
	}
}
