using System.IO;

namespace TestProject.Results
{
	public abstract class BaseResult
	{
		public abstract void Publish(TextWriter writer);
	}
}