

//Primitive Types Example
public static class PriceService
	{
		private static readonly Dictionary<string, float> PairPrice = new Dictionary<string, float>();


		public static float GetPriceFor(string pair)
		{
			return PairPrice[pair];
		}


		public static void ApplyPairPrice(string pair, float price)
		{
			PairPrice[pair] = price;
		}
	}


	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void PriceShouldBeApplied()
		{
			var pair = "BTC/USD";
			var newPrice = 10.0f;

			PriceService.ApplyPairPrice(pair, newPrice);

			PriceService.GetPriceFor(pair).Should().Be(newPrice);
		}
	}