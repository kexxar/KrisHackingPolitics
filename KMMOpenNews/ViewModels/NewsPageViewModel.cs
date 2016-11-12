using System;
using Xamarin.Forms;

namespace KMMOpenNews
{
	public class NewsPageViewModel
	{
		private readonly NewsPage Page;
		private readonly Label NewsTypeLabel;

		public string NewsType { get; set; }
		public string Title { get; set; }
		public string Rate { get; set; }
		public string Description { get; set; }
		public string Date { get; set; }

		public NewsPageViewModel(NewsPage page, Label newsTypeLabel)
		{
			Page = page;
			NewsTypeLabel = newsTypeLabel;

			NewsType = "POLITICS";
			Title = "Поглавље 1.10.33 књиге \"de Finibus Bonorum et Malorum\" коју је написао Cicerо 45. године пре нове ере";
			Date = DateTime.Today.ToString();
			Rate = "4.5";
			Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? Lorem Ipsum је једноставно модел текста који се користи у штампарској и словослагачкој индустрији. Lorem ipsum је био стандард за модел текста још од 1500. године, када је непознати штампар узео кутију са словима и сложио их како би направио узорак књиге. Не само што је овај модел опстао пет векова, него је чак почео да се користи и у електронским медијима, непроменивши се. Популаризован је шездесетих година двадесетог века заједно са листовима летерсета који су садржали Lorem Ipsum пасусе, а данас са софтверским пакетом за прелом као што је Aldus PageMaker који је садржао Lorem Ipsum верзије.";

			if (NewsType.Equals("POLITICS")) {
				NewsTypeLabel.BackgroundColor = Color.FromHex("#FF530D");
			} else if (NewsType.Equals("SOCIETY")) {
				NewsTypeLabel.BackgroundColor = Color.FromHex("#22E869");
			} else if (NewsType.Equals("CHRONICLE")){
				NewsTypeLabel.BackgroundColor = Color.Black;
			}
			
		}
	}
}
