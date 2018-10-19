using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public struct Exchange : IEquatable<Exchange>
{

	public readonly string Name;
	public override string ToString()
	{
		return $"{nameof(Name)}: {Name}";
	}

	public Exchange(string name)
	{
		if (string.IsNullOrEmpty(name))
			throw new ArgumentException(name);
		var cultureInfo = Thread.CurrentThread.CurrentCulture;
		var textInfo = cultureInfo.TextInfo;
		Name = textInfo.ToTitleCase(name.ToLower());

	}

	public bool Equals(Exchange other)
	{

		//var d=EqualityComparer<Exchange>.Default;
		//d.Equals(this, other);

		return string.Equals(Name, other.Name);
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj)) return false;
		return obj is Exchange other && other.Name == Name;
	}

	public override int GetHashCode()
	{
		return (Name != null ? Name.GetHashCode() : 0);
	}
}