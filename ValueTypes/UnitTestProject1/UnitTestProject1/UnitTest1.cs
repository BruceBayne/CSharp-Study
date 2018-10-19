using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;


[TestClass]
public class UnitTest1
{
	[TestMethod]
	[ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
	public void OnlyValidExchangeCanBeCreated()
	{
		var shouldNeverHappenPair = new Exchange("");
	}


	struct BigData
	{
		public decimal a1;
		public decimal a2;
		public decimal a3;
		public decimal a4;
		public decimal a5;
		public decimal a6;
		public decimal a7;
		public decimal a8;
		public decimal a9;
		public decimal a0;
		public decimal a11;
		public decimal a12;
		public decimal a13;
		public decimal a14;
		public decimal a15;
		public decimal a16;
		public decimal a17;
		public decimal a18;
		public decimal a19;
		public decimal a20;
		public decimal a21;
		public decimal a22;
		public decimal a23;
		public decimal a24;
	}


	int RecursiveMethod(BigData b, int limit)
	{
		try
		{
			limit++;
			RuntimeHelpers.EnsureSufficientExecutionStack();
			return RecursiveMethod(b, limit);
		}
		catch (Exception)
		{
			return limit;
		}
	}


	[TestMethod]
	public void ComputeRecursionLimit()
	{
		var counter = RecursiveMethod(new BigData(), 1);
		Debug.WriteLine(counter);
	}


	[TestMethod]
	public void ExchangePairShouldBeSame()
	{
		// Todo: fix this duplicates. Code smell's !!!!!!!!!!!! ASAP
		var pair1 = new ExchangePair(TestsInput.Binance, TestsInput.BtcToUsd);
		var pair2 = new ExchangePair(TestsInput.Binance, TestsInput.BtcToUsd);
		pair1.Should().Be(pair2);
	}


	[TestMethod]
	public void TwoSameExchangesShouldBeSame()
	{
		TestsInput.Binance.Should().Be(new Exchange("BINANCE"));
	}


	[TestMethod]
	public void PriceShouldBeApplied()
	{
		PriceService.ApplyPrice(TestsInput.BinanceBtcUsd, TestsInput.TestPrice);
		PriceService.GetPriceFor(TestsInput.BinanceBtcUsd).Should().Be(TestsInput.TestPrice);
	}


	[TestMethod]
	public void PriceShouldBeApplied2()
	{
	}


	[TestMethod]
	public void Test()
	{
	}


	public enum Mode
	{
		Include,
		Exclude,
	}


	[Serializable]
	public struct Filter : IEquatable<Filter>, ISerializable
	{
		public readonly Mode Mode;
		public readonly HashSet<string> Data;

		public Filter(Mode mode, HashSet<string> data)
		{
			Mode = mode;
			Data = data;
		}

		public bool Equals(Filter f)
		{
			return true;
		}

		public override bool Equals(object obj)
		{
			if (obj is Filter other)
			{
				if (other.Mode != Mode)
					return false;

				if (Data.Equals(other.Data))
					return true;

				return Data.SetEquals(other.Data);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return Mode.GetHashCode() ^ Data.Select(element => element.GetHashCode()).Sum();
		}


		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue(nameof(Mode), Mode);
			info.AddValue(nameof(Data), Data);
		}

		private Filter(SerializationInfo info, StreamingContext para)
		{
			Mode = (Mode)info.GetInt32(nameof(Mode));
			Data = (HashSet<string>)info.GetValue(nameof(Data), typeof(HashSet<string>));
		}
	}


	private static Filter CreateFilter()
	{
		return new Filter(Mode.Include, new HashSet<string>() { "a", "b" });
	}


	private static void CheckJsonSerialization<T>(T instance)
	{
		var serialized = JsonConvert.SerializeObject(instance);
		Debug.WriteLine("Serialized: " + serialized + Environment.NewLine);
		var deserialized = JsonConvert.DeserializeObject<T>(serialized);
		Debug.WriteLine("Deserialized: " + JsonConvert.SerializeObject(deserialized) + Environment.NewLine);
		deserialized.Should().Be(instance);
	}


	[TestMethod]
	public void FilterValuesShouldBeSerializable()
	{
		var filter = CreateFilter();

		filter.Should().BeBinarySerializable();
		CheckJsonSerialization(filter);


		//filter.Should().BeXmlSerializable();
	}


	[TestMethod]
	public void TwoSameValueTypesShouldExistOnceInHashset()
	{
		var e = new HashSet<Filter>();
		var filterOne = CreateFilter();
		var filterTwo = CreateFilter();


		//filterTwo.Should().BeEquivalentTo(filterOne);
		//filterOne.Should().BeEquivalentTo(filterTwo);

		e.Add(filterOne);
		e.Add(filterTwo);

		e.Count.Should().Be(1);
	}


	//[TestMethod]
	//[ExpectedException(typeof(KeyNotFoundException))]
	//public void ExchangeShouldBeRemoved()
	//{
	//	PriceService.ApplyPrice(TestsInput.BinanceBtcUsd, TestsInput.TestPrice);
	//	PriceService.RemoveExchange(TestsInput.Binance);
	//	PriceService.GetPriceFor(TestsInput.BinanceBtcUsd);
	//}


	[TestMethod]
	[ExpectedException(typeof(FormatException))]
	public void OnlyValidPairsCanBeCreated()
	{
		"BTC-USD".ToPair();
	}
}