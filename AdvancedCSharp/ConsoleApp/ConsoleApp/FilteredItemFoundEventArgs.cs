using System;
using System.IO;

namespace ConsoleApp
{
    public class FilteredItemFoundEventArgs<T> : EventArgs where T : FileSystemInfo 
    {
        public readonly T filteredItemFoundInfo;

        public FilteredItemFoundEventArgs(T filteredItemFoundInfo)
        {
            this.filteredItemFoundInfo = filteredItemFoundInfo;
        }
    }
}
