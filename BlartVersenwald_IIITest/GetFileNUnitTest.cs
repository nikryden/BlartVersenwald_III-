using BlartVersenwald_IIIProject;
using NUnit.Framework;
using System.IO;
using System.Reflection;

namespace BlartVersenwald_IIITest
{
    public class Tests
    {
        private GetFileNameOccurrencesInFile _instance = GetFileNameOccurrencesInFile.Instance;
        private string _fileName = "TestAntura.txt";

        private string _text = @"
TestAntura.txt
TestAntura
TestAntura
TestAntura.txt
TestAntura.txtTestAntura
TestAntura
TestAntura
TestAntura
TestAntura
Kallekula TestAntura
";

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_fileName)) File.Delete(_fileName);
            var text = File.CreateText(_fileName);
            text.WriteLine(_text);
            text.AutoFlush = true;
            text.Close();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_fileName);
        }

        [Test]
        public void Set_File_Name()
        {
            // ACT
            _instance.SetFilePath(_fileName);
            // ASSERT
            Assert.AreEqual(_fileName, _instance.FilePath);
            Assert.AreEqual(true, _instance.FileSize > 0);
            Assert.AreEqual(false, string.IsNullOrWhiteSpace(_instance.Text));
        }

        public void Set_File_Size_To_Bigg()
        {
            // ASSERT
            Assert.Throws<FileLoadException>(() => _instance.SetFilePath(_fileName, 10));
        }

        [Test]
        public void SetFile_File_Not_Found()
        {
            // ASSERT
            Assert.Throws<FileLoadException>(() => _instance.SetFilePath("fileDoNotExists.txt"));
        }

        [Test]
        public void Set_Text_String()
        {
            // ACT
            _instance.SetTextString("Test string");
            // ASSERT
            Assert.AreEqual("Test string", _instance.Text);
        }

        [Test]
        public void Get_Extension()
        {
            //ARRANGE
            _instance.SetFilePath(_fileName);
            // ACT
            var ext = _instance.GetExtension();
            // ASSERT
            Assert.AreEqual("txt", ext);
        }

        [Test]
        public void Get_File_Name_Without_Extension()
        {
            // ACT
            var fileName = _instance.GetFileNameWithoutExtension();
            // ASSERT
            Assert.AreEqual("TestAntura", fileName);
        }

        [Test]
        public void Count_Occurrences_JustName()
        {
            // ARRANGE
            _instance.SetFilePath(_fileName);
            // ACT
            var count = _instance.CountOccurrencesOfFilename(Patterns.JustName);
            // ASSERT
            Assert.AreEqual(11, count);
        }

        [Test]
        public void Count_Occurrences_Without_Extension()
        {
            // ARRANGE
            _instance.SetFilePath(_fileName);
            // ACT
            var count = _instance.CountOccurrencesOfFilename(Patterns.WithoutExtension);
            // ASSERT
            Assert.AreEqual(8, count);
        }

        [Test]
        public void Count_Occurrences_With_Extension()
        {
            // ARRANGE
            _instance.SetFilePath(_fileName);
            // ACT
            var count = _instance.CountOccurrencesOfFilename(Patterns.WithExtension);
            // ASSERT
            Assert.AreEqual(3, count);
        }

        [Test]
        public void Count_Occurrences_ArgumentException()
        {
            // ARRANGE
            _instance.SetTextString("");
            // ASSERT
            Assert.Throws<System.ArgumentException>(() => _instance.CountOccurrencesOfFilename(Patterns.JustName));
        }

        [Test]
        public void Read_To_Text_From_File()
        {
            // ARRANGE
            _instance.SetFilePath(_fileName);
            // ACT
            Assert.AreEqual(true, _instance.Text?.Length > 0);
        }
    }
}