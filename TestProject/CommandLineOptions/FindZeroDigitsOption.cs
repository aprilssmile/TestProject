using CommandLine;

namespace TestProject.CommandLineOptions
{
	[Verb("task1", HelpText = "find list of N GUIDs, where each GUID should contains X sequential 0-digits")]
	public class FindZeroDigitsOption
	{
		[Value(0, MetaName = "digitsCount", Required = true, HelpText = "amount of digits")]
		public int DigitsCount { get; set; }

		[Value(1, MetaName = "resultAmount", Required = true, HelpText = "desired amount of results")]
		public int DesiredResultAmount { get; set; }
	}
}