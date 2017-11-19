using System;
using System.Collections.Generic;
using TestProject.Utils;

namespace TestProjectTests
{
	public class GuidGeneratorTest : GuidGenerator
	{
		private readonly List<Guid> _testData;
		private int _currentIndex;

		public GuidGeneratorTest(List<Guid> testData)
		{
			_testData = testData;
			_currentIndex = 0;
		}

		public override List<Guid> Generate(int count)
		{
			return _testData;
		}

		public override Guid Next()
		{
			if (_currentIndex >= _testData.Count)
			{
				throw new Exception();
			}

			var res = _testData[_currentIndex];
			_currentIndex++;

			return res;
		}
	}
}