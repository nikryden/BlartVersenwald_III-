/***
 * --BlartVersenwald_III--
 * Project created for programing test
 * Author Niklas Rydén (c) 2022-06-14
 * Assignment:
 * 1. Write a console program that takes one argument, a path to a file
 * 2. Open that file and count how many times its filename (minus the file extension) occurs in the file's contents.
 * 3. Create tests aiming.
 * 4. Nice error messages
 *
 * The console aplication is writen in .NET 6
 * To start just run BlartVersenwald_IIIProject.exe + [path to file]
 * The program will count usage of the file name in three senarios and print it to the console
 * 1. Get all occurrences of the filename without the file extension
 * 2. Get all occurrences of the filename with the file extension
 * 3. Get all occurrences of the filename with and without the file extension
 *
 * The program will throw error
 *  * if file missing
 *  * if file extends 300MB
 *  * if it fail to read the text from the file
 *  * if the Text propery in GetFileNameOccurrencesInFile is null or empty
 */

using BlartVersenwald_IIIProject;

var maxFileSize = 104857600 * 3; // max size is set to 300MB
var instance = GetFileNameOccurrencesInFile.Instance;
try
{
    if (args.Count() == 0)
        throw new FileLoadException($"Sorry No file path argument found! Please start the application with file path argument");

    instance.SetFilePath(args[0], maxFileSize);

    ConsolePrint.PrintMessage($"Reading file {instance.FilePath}");
    ConsolePrint.PrintCountOccurrences(instance, Patterns.WithoutExtension);
    ConsolePrint.PrintCountOccurrences(instance, Patterns.WithExtension);
    ConsolePrint.PrintCountOccurrences(instance, Patterns.JustName);

    ConsolePrint.PrintFileContent(instance.Text, instance.FileSize, instance.Text.Length);
}
catch (Exception ex)
{
    ConsolePrint.PrintError(ex);
}
finally
{
    ConsolePrint.PrintMessage("Please press any key to quit");
    Console.ReadKey();
}