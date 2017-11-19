using System.Collections.Generic;
using System.Linq;

namespace TestProject.Extensions
{
	public static class StringExtension
	{
		public static IEnumerable<string> Substrings(this string inputString)
		{
			if (string.IsNullOrEmpty(inputString))
			{
				yield return "";
			}

			for (var fromIndex = 0; fromIndex < inputString.Length - 1; fromIndex++)
			{
				for (var length = 1; fromIndex + length <= inputString.Length; length++)
				{
					yield return inputString.Substring(fromIndex, length);
				}
			}
		}

		public static IEnumerable<string> MaxCommonSubstrings(this IEnumerable<string> strings)
		{
			var maxCommonSubstrings = new List<string>();
			if (!strings.Any() || strings.Any(string.IsNullOrEmpty))
			{
				return maxCommonSubstrings;
			}

			var commonSubstrings = new HashSet<string>(strings.First().Substrings());
			foreach (var str in strings.Skip(1))
			{
				commonSubstrings.IntersectWith(str.Substrings());
				if (commonSubstrings.Count == 0)
				{
					return maxCommonSubstrings;
				}
			}

			var maxLength = commonSubstrings.Select(x => x.Length).Max();
			maxCommonSubstrings.AddRange(commonSubstrings.Where(x => x.Length == maxLength));
			return maxCommonSubstrings;
		}
	}
}

