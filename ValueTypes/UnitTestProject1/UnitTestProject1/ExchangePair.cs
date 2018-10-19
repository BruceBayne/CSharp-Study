using System;

public struct ExchangePair
{
	public Exchange Exchange;
	public CurrencyPair Pair;

	public override string ToString()
	{
		return $"{nameof(Exchange)}: {Exchange}, {nameof(Pair)}: {Pair}";
	}

	public ExchangePair(Exchange exchange, CurrencyPair pair)
	{
		Exchange = exchange;
		Pair = pair;
	}
}