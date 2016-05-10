using System.Text;
using CommandLine;
using CommandLine.Text;
namespace HashCheck
{
    /// <summary>
    /// Command-Line options for the command-line client using HashCommand
    /// </summary>
    class Options
    {
        
        [Option('r', "read", Required = true,
          HelpText = "Input file to be processed.")]
        public string InputFile { get; set; }

        [Option('a', "algo", Required = false, DefaultValue ="md5",
          HelpText = "Name of hash algorithm (e.g. md5, sha512)")]
        public string HashAlgoName { get; set; }

        [Option('h', "hash", Required = false, DefaultValue = null,
          HelpText = "Hash value in hexadecimal.  If supplied, authenticate the input file. ")]
        public string HashAsHex{ get; set; }

        [Option('e', "exec", Required = false, DefaultValue = false,
         HelpText = "If verified, should file be executed?")]
        public bool IsFileToBeExecuted { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var usage = new StringBuilder();

            usage.AppendLine("HashCheck computes hash for a file or checks to see the files match hex.");

            usage.AppendLine(HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current)));

            return usage.ToString();
        }
    }
}
