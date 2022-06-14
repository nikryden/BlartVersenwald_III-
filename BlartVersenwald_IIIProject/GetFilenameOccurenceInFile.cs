namespace BlartVersenwald_IIIProject
{
    public class GetFileNameOccurrencesInFile
    {
        public static GetFileNameOccurrencesInFile Instance = new GetFileNameOccurrencesInFile();

        /// <summary>
        /// Path to the file to read
        /// </summary>
        public string FilePath { get; private set; } = "";

        /// <summary>
        /// The text to check for pattern
        /// </summary>
        public string Text { get; private set; } = "";

        public long FileSize { get; private set; } = 0;

        /// <summary>
        /// Set the file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="maxFileSize"></param>
        /// <exception cref="FileLoadException"></exception>
        public void SetFilePath(string filePath, int maxFileSize = 104857600 * 3)
        {
            CheckFileExists(filePath);
            FilePath = filePath.Trim();
            FileSize = GetFileSize();
            if (FileSize > maxFileSize)
                throw new FileLoadException($"Sorry, the {GetFileNameWithoutExtension()}.{GetExtension()} file extends max file size {maxFileSize} bytes");
            ReadToTextFromFile();
        }

        /// <summary>
        /// Get extension from file (FilePath)
        /// </summary>
        /// <returns></returns>
        public string GetExtension() => Path.GetExtension(FilePath ?? "").TrimStart('.');

        /// <summary>
        /// Get the name from the file without the extension
        /// </summary>
        /// <returns></returns>
        public string GetFileNameWithoutExtension() => Path.GetFileNameWithoutExtension(FilePath ?? "");

        /// <summary>
        /// Read all text from the FilePath
        /// </summary>
        /// <exception cref="FileLoadException"></exception>
        private void ReadToTextFromFile()
        {
            Text = File.ReadAllText(FilePath);
        }

        /// <summary>
        /// Set the Text
        /// </summary>
        /// <param name="text"></param>
        public void SetTextString(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Count the occurrences of a string in Text from a pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int CountOccurrencesOfFilename(Patterns pattern)
        {
            if (string.IsNullOrWhiteSpace(Text))
                throw new ArgumentException("Error: Text must not be null or empty!\n  - Please use ReadTextFromFile() or SetTextString(string text)");
            var patternString = GetPattern(pattern);
            return System.Text.RegularExpressions.Regex.Matches(Text, patternString).Count;
        }

        private GetFileNameOccurrencesInFile()
        {
        }

        private long GetFileSize()
        {
            CheckFileExists(FilePath);
            using (var file = File.Open(FilePath, FileMode.Open))
            {
                var size = file.Length;
                return size;
            }
        }

        private string GetPattern(Patterns pattern) => pattern switch
        {
            Patterns.WithExtension => FileNameWithExtensionPattern,
            Patterns.WithoutExtension => FileNameWithoutExtensionPattern,
            Patterns.JustName => FileNamePattern,
            _ => ""
        };

        private void CheckFileExists(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileLoadException($"Sorry, could not find the file {filePath}");
        }

        private string FileNameWithoutExtensionPattern => $@"(({GetFileNameWithoutExtension()}){($"(?![.]{GetExtension()}))")}";
        private string FileNamePattern => $@"({GetFileNameWithoutExtension()})";
        private string FileNameWithExtensionPattern => $@"({GetFileNameWithoutExtension()}[.]{GetExtension()})";
    }
}