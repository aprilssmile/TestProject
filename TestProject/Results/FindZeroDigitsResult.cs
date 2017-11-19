using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject.Results
{
	public class FindZeroDigitsResult : BaseResult
	{
		public List<Guid> Result { get; }

		public FindZeroDigitsResult(List<Guid> result)
		{
			Result = result;
		}

		public override void Publish(TextWriter writer)
		{
			Console.WriteLine();
			if (Result == null || !Result.Any())
			{
				writer.WriteLine("Result set is empty");
				return;
			}

			Console.WriteLine("Result:");
			foreach (var guid in Result)
			{
				writer.WriteLine(guid);
			}

			Console.WriteLine();
		}
	}
}