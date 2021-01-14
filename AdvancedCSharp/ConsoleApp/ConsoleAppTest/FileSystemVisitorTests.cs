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
        private int _numberOfSubDirs;
        private int _numberofFiles;

        [SetUp]
        public void Setup()
        {
            _testPath = Path.Combine(Path.GetTempPath(), "test");
            _numberOfSubDirs = 4;
            _numberofFiles = 5;

            if (!Directory.Exists(_testPath))
            {
                var di = new DirectoryInfo(_testPath);

                for (int i = 0; i < _numberOfSubDirs; i++)
                {
                    di.CreateSubdirectory(String.Concat("dir", i));
                }

                for (int i = 0; i < _numberofFiles; i++)
                {
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

        [Test]
        public void TraverseFileSystem_Returns_AllSubDirsAndFiles()
        {
            var di = new DirectoryInfo(_testPath);
            int expectedNumberOfItems = di.GetFileSystemInfos().Length;

            int actualNumberOfItems = 0;

            foreach (var item in _fileSystemVisitor)
            {
                actualNumberOfItems += 1;
            }

            Assert.AreEqual(expectedNumberOfItems, actualNumberOfItems);
        }

        [Test]
        public void FileSystemVisitor_Constructor_With_Predicate_Filters_Items()
        {
            var fileSystemVisitorWithPredicate = new FileSystemVisitor(_testPath, (FileSystemInfo fsi) =>
            {
                if (fsi.Name == "file2")
                {
                    return true;
                }

                return false;
            });

            int expectedNumberOfItems = 1;

            int actualNumberOfItems = 0;

            foreach (var item in fileSystemVisitorWithPredicate)
            {
                actualNumberOfItems++;
            }

            Assert.AreEqual(expectedNumberOfItems, actualNumberOfItems);
        } 
    }
}