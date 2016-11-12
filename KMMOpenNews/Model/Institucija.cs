using System;
using Newtonsoft.Json;

namespace KMMOpenNews
{
	public struct Institucija
	{
		[JsonProperty(PropertyName = "Prva klasifikacija")]
		public string PrvaKlasifikacija { get; set; }
		public string Kategorija { get; set; }
		[JsonProperty(PropertyName = "Naziv organa")]
		public string NazivOrgana { get; set; }
		[JsonProperty(PropertyName = "Poštanski broj")]
		public string PostanskiBroj { get; set; }
		public string Adresa { get; set; }
		[JsonProperty(PropertyName="Br.")]
		public string Broj { get; set; }
		[JsonProperty(PropertyName="Druga klasifikacija")]
		public string DrugaKlasifikacija { get; set; }
		[JsonProperty(PropertyName="Veb adresa")]
		public string VebAdresa { get; set; }
		[JsonProperty(PropertyName="_id")]
		public int Id { get; set; }
		[JsonProperty(PropertyName="Sedište")]
		public string Sediste { get; set; }
		[JsonProperty(PropertyName="Obaveza informatora")]
		public string ObavezaInformatora { get; set; }
	}
}
