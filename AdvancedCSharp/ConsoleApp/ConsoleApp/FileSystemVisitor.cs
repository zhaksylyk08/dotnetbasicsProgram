using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public delegate void FileFoundEventHandler(object sender, ItemFoundEventArgs<FileInfo> e);
    public delegate void DirectoryFoundEventHandler(object sender, ItemFoundEventArgs<DirectoryInfo> e);
    public delegate void FilteredFileFoundEventHandler(object sender, FilteredItemFoundEventArgs<FileInfo> e);
    public delegate void FilteredDirectoryFoundEventHandler(object sender, FilteredItemFoundEventArgs<DirectoryInfo> e);
    class FileSystemVisitor : IEnumerable
    {
        private string rootPath;
        private List<FileSystemInfo> dirsAndFiles;

        public static event Action Started;
        public static event Action Finished;
        public static event FileFoundEventHandler FileFound;
        public static event DirectoryFoundEventHandler DirectoryFound;
        public static event FilteredFileFoundEventHandler FilteredFileFound;
        public static event FilteredDirectoryFoundEventHandler FilteredDirectoryFound;
        public FileSystemVisitor(string rootPath)
        {
            this.rootPath = rootPath;
            TraverseFileSystem();
        }

        public FileSystemVisitor(string rootPath, Func<FileSystemInfo, bool> predicate)
            :this(rootPath)
        {
            dirsAndFiles = dirsAndFiles.Where(item => predicate(item)).ToList();

            dirsAndFiles.ForEach(item => 
            {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    OnFilteredDirectoryFound(new FilteredItemFoundEventArgs<DirectoryInfo>(item as DirectoryInfo));
                }
                else
                {
                    OnFilteredFileFound(new FilteredItemFoundEventArgs<FileInfo>(item as FileInfo));
                }
            });
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in dirsAndFiles)
            {
                yield return item;
            }
        }

        protected virtual void OnFileFound(ItemFoundEventArgs<FileInfo> e)
        {
            FileFoundEventHandler handler = FileFound;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDirectoryFound(ItemFoundEventArgs<DirectoryInfo> e)
        {
            DirectoryFoundEventHandler handler = DirectoryFound;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnFilteredDirectoryFound(FilteredItemFoundEventArgs<DirectoryInfo> e)
        {
            FilteredDirectoryFoundEventHandler handler = FilteredDirectoryFound;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnFilteredFileFound(FilteredItemFoundEventArgs<FileInfo> e)
        {
            FilteredFileFoundEventHandler handler = FilteredFileFound;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void TraverseFileSystem()
        {
            Started();

            dirsAndFiles = new List<FileSystemInfo>();
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
                        var directoryInfo = new DirectoryInfo(subDir);
                        dirsAndFiles.Add(directoryInfo);

                        var args = new ItemFoundEventArgs<DirectoryInfo>(directoryInfo);
                        OnDirectoryFound(args);

                        if (args.CancelRequested)
                        {
                            return;
                        }

                        dirs.Push(subDir);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                string[] files;

                try
                {
                    files = Directory.GetFiles(currentDir);

                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        dirsAndFiles.Add(fileInfo);

                        var args = new ItemFoundEventArgs<FileInfo>(fileInfo);
                        OnFileFound(args);

                        if (args.CancelRequested)
                        {
                            break;
                        }
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
