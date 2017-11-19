using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestProject.Extensions;
using TestProject.Results;
using TestProject.Utils;

namespace TestProject.TasksSolvers
{
	public class MaxCommonCharactersSequenceFinder : TaskSolver
	{
		private readonly GuidGenerator _guidGenerator;
		private readonly int _guidCount;

		private List<Guid> _guids;

		private const int MinGuidsCountWithMaxCommonSubstrings = 3;

		public MaxCommonCharactersSequenceFinder(GuidGenerator guidGenerator, int guidCount)
		{
			_guidGenerator = guidGenerator;
			_guidCount = guidCount;
		}

		public override BaseResult Calculate(CancellationToken cancellationToken)
		{
			if (_guids == null)
			{
				_guids = _guidGenerator.Generate(_guidCount);
			}

			var maxCommonStrings = new List<string>();

			if (_guids.Count < 3)
			{
				return new FindMaxCommonSequenceResult(_guids, maxCommonStrings);
			}

			var strGuids = _guids.Select(x => x.ToString().Replace("-", String.Empty));
			foreach (var comb in strGuids.Combinations(MinGuidsCountWithMaxCommonSubstrings))
			{
				cancellationToken.ThrowIfCancellationRequested();

				var currentMaxCommonSubstrings = comb.MaxCommonSubstrings();
				maxCommonStrings.AddRange(currentMaxCommonSubstrings);

				maxCommonStrings = maxCommonStrings.Where(x => x.Length == maxCommonStrings.Max(y => y.Length)).Distinct().ToList();
			}

			return new FindMaxCommonSequenceResult(_guids, maxCommonStrings);
		}
	}
}