using System;
using System.IO;

namespace ConsoleApp
{
    public class FilteredItemFoundEventArgs<T> : EventArgs where T : FileSystemInfo 
    {
        public T FilteredItemFoundInfo;

        public FilteredItemFoundEventArgs(T filteredItemFoundInfo)
        {
            FilteredItemFoundInfo = filteredItemFoundInfo;
        }
    }
}
