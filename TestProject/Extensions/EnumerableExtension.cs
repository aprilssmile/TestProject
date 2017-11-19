using System.Collections.Generic;
using System.Linq;

namespace TestProject.Extensions
{
	public static class EnumerableExtension
	{
		public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> items, int count)
		{
			return GetCombinations(items, count);
		}

		private static IEnumerable<IEnumerable<T>> GetCombinations<T>(IEnumerable<T> items, int itemsCountInCombination)
		{
			var curItemIndex = 0;
			foreach (var firstItem in items.Select(item => new[] { item }))
			{
				if (itemsCountInCombination == 1)
				{
					yield return firstItem;
				}
				else
				{
					foreach (var tailCombination in Combinations(items.Skip(curItemIndex + 1), itemsCountInCombination - 1))
					{
						yield return firstItem.Concat(tailCombination);
					}
				}

				curItemIndex++;
			}
		}
	}
}