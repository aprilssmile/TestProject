using System;
using System.Collections.Generic;
using System.Threading;
using TestProject.Results;
using TestProject.Utils;

namespace TestProject.TasksSolvers
{
	public class GuidsWithZeroDigitsFinder : TaskSolver
	{
		private readonly GuidGenerator _guidGenerator;
		private readonly int _digitsCount;
		private readonly int _desiredResultAmount;

		public GuidsWithZeroDigitsFinder(GuidGenerator guidGenerator, int digitsCount, int desiredResultAmount)
		{
			_guidGenerator = guidGenerator;
			_digitsCount = digitsCount;
			_desiredResultAmount = desiredResultAmount;
		}

		public override BaseResult Calculate(CancellationToken cancellationToken)
		{
			var result = new List<Guid>();

			if (_digitsCount < 0)
			{
				return new FindZeroDigitsResult(result);
			}

			var patternToFind = new string('0', _digitsCount);

			while (result.Count < _desiredResultAmount)
			{
				cancellationToken.ThrowIfCancellationRequested();

				var guid = _guidGenerator.Next();

				if (ContainsSubstring(guid, patternToFind))
				{
					result.Add(guid);
				}
			}

			return new FindZeroDigitsResult(result);
		}

		public bool ContainsSubstring(Guid guid, string patternToFind)
		{
			var guidStr = guid.ToString().Replace("-", String.Empty);
			return guidStr.Contains(patternToFind);
		}
	}
}