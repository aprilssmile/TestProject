using System;
using System.Threading;
using CommandLine;
using TestProject.CommandLineOptions;
using TestProject.TasksSolvers;
using TestProject.Utils;

namespace TestProject
{
	public class Program
	{
		const int COULD_NOT_PARSE_ARGUMENTS = 1;
		const int ARGUMENTS_PARSED_SUCCESFULL = 0;

		static void Main(string[] args)
		{
			var parseResult = Parser.Default.ParseArguments<FindZeroDigitsOption, FindMaxCommonSequenceOption>(args);

			var tokenSource = new CancellationTokenSource();
			var cancellationToken = tokenSource.Token;

			var taskRunner = new TaskRunner();

			taskRunner.IsTaskFinished += TaskFinished();

			var result = MapResult(parseResult, taskRunner, cancellationToken);
			if (result == COULD_NOT_PARSE_ARGUMENTS)
			{
				Console.ReadKey();
				return;
			}

			Console.WriteLine("Calculationg...Push any button to interrupt operation and to exit application");

			Console.ReadKey();

			if (taskRunner.IsTaskFinishedAlready)
			{
				return;
			}

			TaskCancelled(taskRunner, tokenSource, cancellationToken);
			Console.WriteLine("Task cancelled");
		}

		private static void TaskCancelled(TaskRunner taskRunner, CancellationTokenSource tokenSource, CancellationToken cancellationToken)
		{
			tokenSource.Cancel();
			taskRunner.WaitForCancellation(cancellationToken);
		}

		private static int MapResult(ParserResult<object> parseResult, TaskRunner taskRunner, CancellationToken cancellationToken)
		{
			return parseResult.MapResult(
				(FindZeroDigitsOption opts) =>
				{
					var task = new GuidsWithZeroDigitsFinder(new GuidGenerator(), opts.DigitsCount, opts.DesiredResultAmount);
					taskRunner.Run(task, cancellationToken);

					return ARGUMENTS_PARSED_SUCCESFULL;
				},
				(FindMaxCommonSequenceOption opts) =>
				{
					var task = new MaxCommonCharactersSequenceFinder(new GuidGenerator(), opts.GuidsCountToReview);
					taskRunner.Run(task, cancellationToken);

					return ARGUMENTS_PARSED_SUCCESFULL;
				},
				errs => 1);
		}

		private static TaskRunner.TaskFinished TaskFinished()
		{
			return (sender, eventArgs) =>
			{
			    eventArgs.Result?.Publish(Console.Out);
			    Console.WriteLine("Task completed");
			};
		}
	}
}
