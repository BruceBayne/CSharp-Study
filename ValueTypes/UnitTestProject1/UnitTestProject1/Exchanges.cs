public static class Exchanges
{
	public static CurrencyPair ToPair(this string plainTextPair)
	{
		return new CurrencyPair(plainTextPair);
	}

	public static Exchange Binance = new Exchange("Binance");
	public static Exchange Bittrex = new Exchange("Bittrex");

	public static ExchangePair WithPair(this Exchange exchange, CurrencyPair pair)
	{
		return new ExchangePair(exchange, pair);
	}
}