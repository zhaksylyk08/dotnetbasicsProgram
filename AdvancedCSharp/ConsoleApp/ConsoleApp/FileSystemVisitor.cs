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

    public class FileSystemVisitor : IEnumerable
    {
        private string _rootPath;
        private List<FileSystemInfo> _dirsAndFiles;

        public static event Action Started;
        public static event Action Finished;
        public static event FileFoundEventHandler FileFound;
        public static event DirectoryFoundEventHandler DirectoryFound;
        public static event FilteredFileFoundEventHandler FilteredFileFound;
        public static event FilteredDirectoryFoundEventHandler FilteredDirectoryFound;
        public FileSystemVisitor(string rootPath)
        {
            _rootPath = rootPath;
            TraverseFileSystem();
        }

        public FileSystemVisitor(string rootPath, Func<FileSystemInfo, bool> predicate)
            :this(rootPath)
        {
            _dirsAndFiles = _dirsAndFiles.Where(item => predicate(item)).ToList();

            _dirsAndFiles.ForEach(item => 
            {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    FilteredDirectoryFound?.Invoke(this, new FilteredItemFoundEventArgs<DirectoryInfo>(item as DirectoryInfo));
                }
                else
                {
                    FilteredFileFound?.Invoke(this, new FilteredItemFoundEventArgs<FileInfo>(item as FileInfo));
                }
            });
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _dirsAndFiles)
            {
                yield return item;
            }
        }

        public void TraverseFileSystem()
        {
            Started?.Invoke();

            _dirsAndFiles = new List<FileSystemInfo>();
            var dirs = new Stack<string>();

            dirs.Push(_rootPath);

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
                        _dirsAndFiles.Add(directoryInfo);

                        var args = new ItemFoundEventArgs<DirectoryInfo>(directoryInfo);
                        DirectoryFound?.Invoke(this, args);

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
                        _dirsAndFiles.Add(fileInfo);

                        var args = new ItemFoundEventArgs<FileInfo>(fileInfo);
                        FileFound?.Invoke(this, args);

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

            Finished?.Invoke();
        }
    }
}
