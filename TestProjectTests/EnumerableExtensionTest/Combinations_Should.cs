using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Extensions;

namespace TestProjectTests.EnumerableExtensionTest
{
	[TestClass]
	public class Combinations_Should
	{
		[TestMethod]
		public void ReturnEmptyCollectionWhenCollectionLessThanCountInCombinations()
		{
			var initCollection = new List<int> { 1 };

			var combinations = initCollection.Combinations(2);

			Assert.AreEqual(0, combinations.Count());
		}

		[TestMethod]
		public void ReturnEmptyCollectionWhenCountInCominationsIsZero()
		{
			var initCollection = new List<int> { 1, 2 };

			var combinations = initCollection.Combinations(0);

			Assert.AreEqual(0, combinations.Count());
		}

		[TestMethod]
		public void ReturnOneObjectCollectionWhenCountInCombinationIs1()
		{
			var initCollection = new List<int> { 1, 2 };

			var combinations = initCollection.Combinations(1).ToList();

			Assert.AreEqual(2, combinations.Count());

			var expectedResult = new[]
			{
				new[] {1},
				new[] {2}
			};

			for (var i = 0; i < combinations.Count(); i++)
			{
				CollectionAssert.AreEquivalent(expectedResult[i], combinations[i].ToList());
			}
		}

		[TestMethod]
		public void ReturnNotRepeatedCombinations()
		{
			var initCollection = new List<int> {1, 2};

			var combinations = initCollection.Combinations(2);

			Assert.AreEqual(1, combinations.Count());
			CollectionAssert.AreEquivalent(new[] {1, 2}, combinations.First().ToList());
		}

		[TestMethod]
		public void ReturnNotRepeatedCombinationsForCount2()
		{
			var initCollection = new List<int> {1, 2, 3};

			var combinations = initCollection.Combinations(2).ToList();

			Assert.AreEqual(3, combinations.Count());

			var expectedResult = new[]
			{
				new[] {1, 2},
				new[] {1, 3},
				new[] {2, 3}
			};

			for (var i = 0; i < combinations.Count(); i++)
			{
				CollectionAssert.AreEquivalent(expectedResult[i], combinations[i].ToList());
			}
		}
	}
}
