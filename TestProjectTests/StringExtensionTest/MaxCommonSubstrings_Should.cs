using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.Extensions;

namespace TestProjectTests.StringExtensionTest
{
	[TestClass]
	public class MaxCommonSubstrings_Should
	{
		[TestMethod]
		public void ReturnCommonSubstringWhenItExist()
		{
			var strList = new List<string> {"str123s", "tyu123t"};

			var commonStr = strList.MaxCommonSubstrings();

			Assert.AreEqual(1, commonStr.Count());
			Assert.AreEqual("123", commonStr.First());
		}

		[TestMethod]
		public void ReturnEmptyCollectionWhenNoCommonSubstring()
		{
			var strList = new List<string> {"12345", "6789"};

			IEnumerable<string> commonStr = strList.MaxCommonSubstrings();

			Assert.AreEqual(0, commonStr.Count());
		}

		[TestMethod]
		public void ReturnEmptyCollectionWhenOneStringIsEmpty()
		{
			var strList = new List<string> {"12345", ""};

			IEnumerable<string> commonStr = strList.MaxCommonSubstrings();

			Assert.AreEqual(0, commonStr.Count());
		}

		[TestMethod]
		public void ReturnEmptyCollectionWhenOneStringIsNull()
		{
			var strList = new List<string> {"12345", null};

			var commonStr = strList.MaxCommonSubstrings();

			Assert.AreEqual(0, commonStr.Count());
		}

		[TestMethod]
		public void ReturnEmptyCollectionWhenFirstStringIsNull()
		{
			var strList = new List<string> {null, "12345"};

			var commonStr = strList.MaxCommonSubstrings();

			Assert.AreEqual(0, commonStr.Count());
		}

		[TestMethod]
		public void ReturnEmptyCollectionWhenFirststringIsEmpty()
		{
			var strList = new List<string> {"", "12345"};

			var commonStr = strList.MaxCommonSubstrings();

			Assert.AreEqual(0, commonStr.Count());
		}

		[TestMethod]
		public void ReturnAllResultsWhenSeveralCommonSubstrings()
		{
			var strList = new List<string> {"str123s456", "tyu123t456"};

			var commonStr = strList.MaxCommonSubstrings().ToList();

			Assert.AreEqual(2, commonStr.Count());
			CollectionAssert.AreEquivalent(new[] {"123", "456"}, commonStr);
		}

		[TestMethod]
		public void ReturnOneCommonSubstrinfIfTwoSubstringIsMatch()
		{
			var strList = new List<string> {"str123s123", "tyu123t123"};

			var commonStr = strList.MaxCommonSubstrings().ToList();

			Assert.AreEqual(1, commonStr.Count());
			Assert.AreEqual("123", commonStr.First());
		}
	}
}
