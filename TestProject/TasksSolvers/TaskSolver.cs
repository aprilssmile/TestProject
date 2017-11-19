using System.Threading;
using TestProject.Results;

namespace TestProject.TasksSolvers
{
	public abstract class TaskSolver
	{
		public abstract BaseResult Calculate(CancellationToken cancellationToken);
	}
}