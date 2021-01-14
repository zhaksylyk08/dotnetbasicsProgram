using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections;
using System.IO;

namespace ConsoleAppTest
{
    public class FileSystemVisitorTests
    {
        private FileSystemVisitor _fileSystemVisitor;
        private string _testPath;

        [SetUp]
        public void Setup()
        {
            _testPath = Path.Combine(Path.GetTempPath(), "test");

            if (!Directory.Exists(_testPath))
            {
                var di = new DirectoryInfo(_testPath);

                for (int i = 1; i < 4; i++)
                {
                    di.CreateSubdirectory(String.Concat("dir", i));
                    File.Create(Path.Combine(_testPath, String.Concat("file", i)));
                }
            }

            _fileSystemVisitor = new FileSystemVisitor(_testPath);
        }

        [Test]
        public void FileSystemVisitor_Is_A_Collection()
        {
            Assert.IsInstanceOf<IEnumerable>(_fileSystemVisitor);
        }


    }
}