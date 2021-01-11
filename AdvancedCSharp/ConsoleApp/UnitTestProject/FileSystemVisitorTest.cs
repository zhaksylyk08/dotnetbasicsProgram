using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using ConsoleApp;

namespace UnitTestProject
{
    [TestClass]
    public class FileSystemVisitorTest
    {
        private FileSystemVisitor _fileSystemVisitor;

        [SetUp]
        public void SetUp()
        {
            string rootPath = @"C:\dotnetmentoring";
            _fileSystemVisitor = new FileSystemVisitor(rootPath);
        }

        [TestMethod]
        public void InvalidDirectoryPath_ThrowsException()
        {
            var invalidRootPath = @"C:\dotnetmentoring222";
            var fileSystemVisitor = new FileSystemVisitorTest(invalidRootPath);

            Assert.Throws<Exception>(() => fileSystemVisitor.TraverseFileSystem());
        }
    }
}
