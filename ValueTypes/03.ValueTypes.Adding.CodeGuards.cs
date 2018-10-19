public struct ExchangePair
	{
		public readonly string Exchange;
		public readonly string Pair;

		public ExchangePair(string exchange, string pair)
		{
			Exchange = exchange.ToLower();


			if (!pair.Contains("/"))
				throw new FormatException(pair);

			Pair = pair;
		}
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

		public const string BtcToUsdInvalid = "BTC-USD";

		public static ExchangePair BinanceBtcUsd => new ExchangePair(Binance, BtcToUsd);
	}


	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void ExchangePairShouldBeSame()
		{
			// Todo: fix this duplicates. Code smell's !!!!!!!!!!!! ASAP
			var pair1 = new ExchangePair(TestsInput.Binance, TestsInput.BtcToUsd);
			var pair2 = new ExchangePair(TestsInput.Binance, TestsInput.BtcToUsd);
			pair1.Should().Be(pair2);
		}

		[TestMethod]
		public void PriceShouldBeApplied()
		{
			PriceService.ApplyExchangePairPrice(TestsInput.BinanceBtcUsd, TestsInput.TestPrice);
			PriceService.GetPriceFor(TestsInput.BinanceBtcUsd).Should().Be(TestsInput.TestPrice);
		}


		[TestMethod]
		[ExpectedException(typeof(FormatException))]
		public void OnlyValidPairsCanBeCreated()
		{

			//Explanation:

			//The key here is probably PAIR ??
			//We Accept probably ANY exchange
			//but check only Pair validity there
			//this is first bell's about Pair type

			var shouldNeverHappenPair = new ExchangePair(TestsInput.Binance, TestsInput.BtcToUsdInvalid);

		}
	}