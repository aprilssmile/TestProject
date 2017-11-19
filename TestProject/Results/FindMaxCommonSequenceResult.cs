using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestProject.Results
{
	public class FindMaxCommonSequenceResult : BaseResult
	{
		public List<Guid> Guids { get; }
		public List<string> CommonSequences { get; }

		public FindMaxCommonSequenceResult(List<Guid> guids, List<string> result)
		{
			Guids = guids;
			CommonSequences = result;
		}

		public override void Publish(TextWriter writer)
		{
			Console.WriteLine();
			if (Guids == null || !Guids.Any())
			{
				writer.WriteLine("No guids to analyze");
				return;
			}

			writer.WriteLine("Generated GUIDs:");

			foreach (var guid in Guids)
			{
				writer.WriteLine(guid);
			}

			Console.WriteLine();
			if (CommonSequences == null || !CommonSequences.Any())
			{
				writer.WriteLine("No matching substrings");
				return;
			}

			writer.WriteLine("Max common strings for 3 and more GUIDs:");
			foreach (var value in CommonSequences)
			{
				writer.WriteLine(value);
			}
			Console.WriteLine();
		}
	}
}