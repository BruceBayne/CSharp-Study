using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
	public struct Point
	{
		public int X;
		public int Y;
		public void IncrementX() { X++; }

	}

	class Foo
	{

		public readonly Point Point = new Point() { X = 10, Y = 20 };

	}

	[TestClass]
	public class UnitTest2
	{
		[TestMethod]
		public void ImmutabilityTest()
		{
			var foo = new Foo();
			foo.Point.IncrementX();
			foo.Point.X.Should().Be(11);



		}
	}
}
