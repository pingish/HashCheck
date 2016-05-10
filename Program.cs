using System;
using System.IO;
using System.Diagnostics;
namespace HashCheck
{

    class Program
    {
        static Options _options;
        private static HashCommand _hashCmd;
        static string getHashAsHexString()
        {
            _hashCmd = new HashCommand(HashAlgorithmFactory.GetHashAlgorithm(_options.HashAlgoName));

            if (File.Exists(_options.InputFile))
                _hashCmd.InputBytes = File.ReadAllBytes(_options.InputFile);
            else
                _hashCmd.InputString = _options.InputFile;

            _hashCmd.Execute();

            return _hashCmd.OutputStringAsHex;
        }
        static void ComputeHash()
        {
            Console.WriteLine(getHashAsHexString());
        }

        static void VerifyHash()
        {
            bool doHashStringsMatch = _options.HashAsHex == getHashAsHexString();
            if (_options.IsFileToBeExecuted)
                if (doHashStringsMatch)
                    Process.Start(_options.InputFile);
                else
                    Console.WriteLine("Hash does not match.");
            else
                Console.WriteLine(doHashStringsMatch);
        }
        static void Main(string[] args)
        {
             _options = new Options();
            
            if (CommandLine.Parser.Default.ParseArguments(args, _options))
            {
                if (_options.HashAsHex == null)
                    ComputeHash();
                else
                    VerifyHash();
               
            }
        }
    }
}
