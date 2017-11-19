using CommandLine;

namespace TestProject.CommandLineOptions
{
	[Verb("task2", HelpText = "find max sequence of characters (substring) which is common for more than 2 " +
	                          "GUIDs within the list of X randomly generated GUIDs.")]
	public class FindMaxCommonSequenceOption
	{
		[Value(0, MetaName = "guidsCount", Required = true, HelpText = "amount of GUIDs to review (X)")]
		public int GuidsCountToReview { get; set; }
	}
}