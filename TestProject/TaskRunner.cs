using System;
using System.Threading;
using System.Threading.Tasks;
using TestProject.Results;
using TestProject.TasksSolvers;

namespace TestProject
{
	public class TaskRunner
	{
		private Task _currentTask;

		public delegate void TaskFinished(object sender, TaskFinishedEventArgs args);
		public event TaskFinished IsTaskFinished;

		public bool IsTaskFinishedAlready { get; private set; }

		protected virtual void OnTaskFinished(BaseResult result)
		{
			var handler = IsTaskFinished;
		    handler?.Invoke(this, new TaskFinishedEventArgs(result));
		    IsTaskFinishedAlready = true;
		}

		public void Run(TaskSolver solver, CancellationToken cancellationToken)
		{
			_currentTask = Task.Factory.StartNew(() => solver.Calculate(cancellationToken), cancellationToken)
				.ContinueWith(result => OnTaskFinished(result.Result), cancellationToken);
		}

		public void WaitForCancellation(CancellationToken cancellationToken)
		{
			if (_currentTask == null || IsTaskFinishedAlready)
			{
				return;
			}

			try
			{
				_currentTask.Wait(cancellationToken);
			}
			catch (OperationCanceledException) 
			{
			}
		}
	}
}