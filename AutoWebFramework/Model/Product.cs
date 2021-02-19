using TechTalk.SpecFlow.Assist.Attributes;

namespace AutoWebFramework.Model
{
    public class Product
    {
		[TableAliases("Descrição")]
		public string Description { get; set; }

		[TableAliases("CodProduto")]
		public string ProductCode { get; set; }

		[TableAliases("Voltagem")]
		public string Voltage { get; set; }

		[TableAliases("Parceiros")]
		public string Partner { get; set; }

		[TableAliases("Pontos")]
		public string Points { get; set; }

		[TableAliases("Quantidade")]
		public int Qty { get; set; }

		public Product(string description, string productCode, string voltage, string partner, string points, int qty)
		{
			Description = description;
			ProductCode = productCode;
			Voltage = voltage;
			Partner = partner;
			Points = points;
			Qty = qty;
		}
	}
}
