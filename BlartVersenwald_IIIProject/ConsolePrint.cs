using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlartVersenwald_IIIProject
{
    public class ConsolePrint
    {
        public static void PrintMessage(string message)
        { Console.WriteLine(message); }

        public static void PrintFileContent(string content, long fileSize, int maxSize)
        {
            PrintMessage($"============-File content ({fileSize} bytes)-===============");

            PrintMessage($"{content.Substring(0, 1000)}{(content.Length > maxSize ? "..." : "")}");

            PrintMessage("=========================================");
        }

        public static void PrintError(Exception message)
        {
            PrintMessage("============-Error-===============");
            PrintMessage(message.Message);
            PrintMessage("=========================================");
        }

        public static void PrintCountOccurrences(GetFileNameOccurrencesInFile occurrencesInFile, Patterns pattern)
        {
            var count = occurrencesInFile.CountOccurrencesOfFilename(pattern);
            switch (pattern)
            {
                case Patterns.WithoutExtension:

                    PrintMessage($"Number of occurrences of \"{occurrencesInFile.GetFileNameWithoutExtension()}\" and not ending with \".{occurrencesInFile.GetExtension()}\" = {count} ");
                    break;

                case Patterns.WithExtension:

                    PrintMessage($"Number of occurrences of \"{occurrencesInFile.GetFileNameWithoutExtension()}.{occurrencesInFile.GetExtension()}\" = {count} ");
                    break;

                default:
                    PrintMessage($"All occurrences of \"{occurrencesInFile.GetFileNameWithoutExtension()}\" = {count} ");
                    break;
            }
        }
    }
}