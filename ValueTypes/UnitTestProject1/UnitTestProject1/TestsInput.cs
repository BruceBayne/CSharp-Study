/// Tests region
public class TestsInput
{
	public static float TestPrice => 10.0f;

	public static Exchange Binance => new Exchange("Binance");
	public static CurrencyPair BtcToUsd => new CurrencyPair("BTC/USD");

	public static CurrencyPair BtcToUsdInvalid => new CurrencyPair("BTC-USD");

	public static ExchangePair BinanceBtcUsd => new ExchangePair(Binance, BtcToUsd);
}