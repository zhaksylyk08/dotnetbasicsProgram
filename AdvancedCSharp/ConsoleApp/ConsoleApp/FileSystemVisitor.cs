using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    public delegate void FileFoundEventHandler(object sender, FileFoundEventArgs e);
    public delegate void DirectoryFoundEventHandler(object sender, DirectoryFoundEventArgs e);
    public delegate void FilteredFileDirectoryFoundEventHandler(object sender, FilteredFileDirectoryFoundEventArgs e);
    class FileSystemVisitor : IEnumerable
    {
        private string rootPath;
        private List<string> dirsAndFiles;

        public static event Action Started;
        public static event Action Finished;
        public event FileFoundEventHandler FileFound;
        public event DirectoryFoundEventHandler DirectoryFound;
        public event FilteredFileDirectoryFoundEventHandler FilteredFileDirectoryFound;
        public FileSystemVisitor(string rootPath)
        {
            this.rootPath = rootPath;
            TraverseFileSystem();
        }

        public FileSystemVisitor(string rootPath, 
                                    Func<List<string>, List<string>> filterDirsAndFiles)
                                    :this(rootPath)
        {
            this.rootPath = rootPath;
            dirsAndFiles = filterDirsAndFiles(dirsAndFiles);
            OnFilteredFileDirectoryFound(new FilteredFileDirectoryFoundEventArgs(dirsAndFiles));
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in dirsAndFiles)
            {
                yield return item;
            }
        }

        protected virtual void OnFileFound(FileFoundEventArgs e)
        {
            FileFoundEventHandler handler = FileFound;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDirectoryFound(DirectoryFoundEventArgs e)
        {
            DirectoryFoundEventHandler handler = DirectoryFound;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnFilteredFileDirectoryFound(FilteredFileDirectoryFoundEventArgs e)
        {
            FilteredFileDirectoryFoundEventHandler handler = FilteredFileDirectoryFound;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void TraverseFileSystem()
        {
            Started();

            dirsAndFiles = new List<string>();
            var dirs = new Stack<string>();

            dirs.Push(rootPath);

            while (dirs.Count > 0)
            {
                var currentDir = dirs.Pop();
                string[] subDirs;

                try
                {
                    subDirs = Directory.GetDirectories(currentDir);

                    foreach (var subDir in subDirs)
                    {
                        var di = new DirectoryInfo(subDir);
                        dirsAndFiles.Add(di.Name);
                        OnDirectoryFound(new DirectoryFoundEventArgs(di.Name));
                        dirs.Push(subDir);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files = null;

                try
                {
                    files = Directory.GetFiles(currentDir);

                    foreach (var file in files)
                    {
                        var fi = new FileInfo(file);
                        OnFileFound(new FileFoundEventArgs(fi.Name));
                        dirsAndFiles.Add(fi.Name);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            Finished();
        }
    }
}
