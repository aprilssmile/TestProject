using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Results;
using TestProject.TasksSolvers;

namespace TestProjectTests.GuidsWithZeroDigitsFinderTests
{
	[TestClass]
	public class Calculate_Should
	{
		[TestMethod] 
		public void ReturnFirstCorrectGuid()
		{
			var guid1 = new Guid("11111111-1111-1111-1111-111111111111");
			var guid2 = new Guid("11111111-1111-1111-1111-111111111101");
			var guid3 = new Guid("11111111-1111-1111-1111-111111111110");

			var generator = new GuidGeneratorTest(new List<Guid> {guid1, guid2, guid3});

			var taskSolver = new GuidsWithZeroDigitsFinder(generator, 1, 1);
			var result = (FindZeroDigitsResult)taskSolver.Calculate(new CancellationToken());

			Assert.AreEqual(1, result.Result.Count);
			Assert.AreEqual(guid2, result.Result.First());
		}

		[TestMethod]
		public void ReturnSeveralCorrectGuids()
		{
			var guid1 = new Guid("11111111-1111-1111-1111-111111111111");
			var guid2 = new Guid("11111111-1111-1111-1111-111111111100");
			var guid3 = new Guid("11111111-1111-1111-1111-111111111110");
			var guid4 = new Guid("11111111-1111-1001-1111-111111111111");

			var generator = new GuidGeneratorTest(new List<Guid> { guid1, guid2, guid3, guid4 });

			var taskSolver = new GuidsWithZeroDigitsFinder(generator, 2, 2);
			var result = (FindZeroDigitsResult)taskSolver.Calculate(new CancellationToken());

			Assert.AreEqual(2, result.Result.Count);
			CollectionAssert.AreEquivalent(new List<Guid>{guid2, guid4}, result.Result);
		}

		[TestMethod]
		public void ReturnGuidWithDashBetweenZeros()
		{
			var guid1 = new Guid("11111111-1111-1111-1110-011111111111");

			var generator = new GuidGeneratorTest(new List<Guid> { guid1 });

			var taskSolver = new GuidsWithZeroDigitsFinder(generator, 2, 1);
			var result = (FindZeroDigitsResult)taskSolver.Calculate(new CancellationToken());

			Assert.AreEqual(1, result.Result.Count);
			Assert.AreEqual(guid1, result.Result.First());
		}

		[TestMethod]
		public void ReturnEmptyListWhenFirstDigitsCountArgumentNegative()
		{
			var generator = new GuidGeneratorTest(new List<Guid>());

			var taskSolver = new GuidsWithZeroDigitsFinder(generator, -1, 1);
			var result = (FindZeroDigitsResult)taskSolver.Calculate(new CancellationToken());

			Assert.AreEqual(0, result.Result.Count);
		}

		[TestMethod]
		public void ReturnEmptyListWhenDesiredResultAmountArgumentNegative()
		{
			var generator = new GuidGeneratorTest(new List<Guid>());

			var taskSolver = new GuidsWithZeroDigitsFinder(generator, 1, -1);
			var result = (FindZeroDigitsResult)taskSolver.Calculate(new CancellationToken());

			Assert.AreEqual(0, result.Result.Count);
		}
	}
}