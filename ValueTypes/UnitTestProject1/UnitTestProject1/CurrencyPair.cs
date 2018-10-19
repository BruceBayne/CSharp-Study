using System;






public struct CurrencyPair
{
	public string Value;

	public override string ToString()
	{
		return $"{nameof(Value)}: {Value}";
	}

	public CurrencyPair(string value)
	{
		if (!value.Contains("/"))
			throw new FormatException(value);
		Value = value;
	}
}