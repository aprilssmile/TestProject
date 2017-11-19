using System;
using System.Collections.Generic;

namespace TestProject.Utils
{
	public class GuidGenerator
	{
		public virtual List<Guid> Generate(int count)
		{
			var guids = new List<Guid>();
			for (var i = 0; i < count; ++i)
			{
				guids.Add(Guid.NewGuid());
			}
			return guids;
		}

		public virtual Guid Next()
		{
			return Guid.NewGuid();
		}
	}
}