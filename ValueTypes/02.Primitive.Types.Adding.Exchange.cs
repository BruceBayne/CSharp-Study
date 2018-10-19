


//Keep extending primitive types example 
//Adding Exchange to PriceService


public struct ExchangePair
	{
		public string Exchange;
		public string Pair;
	}


	public static class PriceService
	{

		private static readonly Dictionary<ExchangePair, float> PairPrice = new Dictionary<ExchangePair, float>();

		public static float GetPriceFor(ExchangePair exchangePair)
		{
			return PairPrice[exchangePair];
		}


		public static void ApplyExchangePairPrice(ExchangePair exchangePair, float price)
		{
			PairPrice[exchangePair] = price;
		}
	}




	/// Tests region

	public class TestsInput
	{
		public static float TestPrice => 10.0f;

		public const string Binance = "Binance";
		public const string BtcToUsd = "BTC/USD";

		public static ExchangePair BinanceBtcUsd => new ExchangePair()
		{
			Exchange = Binance,
			Pair = BtcToUsd
		};
	}



	[TestClass]
	public class UnitTest1
	{
		
		[TestMethod]
		public void ExchangePairShouldBeSame()
		{
			//Todo: fix this duplicates. Code smell's
			var pair1 = new ExchangePair() { Exchange = TestsInput.Binance, Pair = TestsInput.BtcToUsd };
			var pair2 = new ExchangePair() { Exchange = TestsInput.Binance, Pair = TestsInput.BtcToUsd };
			pair1.Should().Be(pair2);
		}
		
		[TestMethod]
		public void PriceShouldBeApplied()
		{

			PriceService.ApplyExchangePairPrice(TestsInput.BinanceBtcUsd, TestsInput.TestPrice);
			PriceService.GetPriceFor(TestsInput.BinanceBtcUsd).Should().Be(TestsInput.TestPrice);
		}
	}