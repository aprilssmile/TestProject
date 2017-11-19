using System;
using TestProject.Results;

namespace TestProject
{
	public class TaskFinishedEventArgs : EventArgs
	{
		public TaskFinishedEventArgs(BaseResult result)
		{
			Result = result;
		}

		public BaseResult Result { get; }
	}
}