using System.Collections.Generic;
using System.Linq;

public static class PriceService
{
	public static readonly Dictionary<ExchangePair, float> PairPrice = new Dictionary<ExchangePair, float>();

	public static float GetPriceFor(ExchangePair exchangePair)
	{
		return PairPrice[exchangePair];
	}



	public static CurrencyPair GetHighestPricePair()
	{
		return PairPrice.OrderByDescending(x => x.Value).First().Key.Pair;
	}



	public static void ApplyPrice(ExchangePair exchangePair, float price)
	{
		PairPrice[exchangePair] = price;
	}

	public static void RemoveExchange(Exchange exchange)
	{
		PairPrice.RemoveAll((pair, f) => pair.Exchange.Equals(exchange));
	}


}