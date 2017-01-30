using System;
using System.Collections.Generic;

namespace KMMOpenNews
{
	public static class Constants
	{
		private static string SearchUrl = "http://data.poverenik.rs/api/action/datastore_search_sql?sql=SELECT * FROM \"85f49574-e799-4cf6-8e80-b4e8eb18cdc8\" WHERE _full_text @@ to_tsquery('{0}') OR \"Veb adresa\" LIKE '%{0}%' LIMIT 50";
		/// <summary>
		/// Gets the search URL. Search is limited to 50 entries
		/// </summary>
		/// <returns>The search URL.</returns>
		/// <param name="query">Query.</param>
		public static string GetSearchUrl(string query) {
			return string.Format(SearchUrl, query);
		}

		public static Dictionary<string, string> Categories = new Dictionary<string,string> {
			{ "new", "NOVO" },
			{ "politics", "POLITIKA"},
			{ "society", "DRUSTVO"},
			{ "chronicle", "HRONIKA"}
		};
	}
}
