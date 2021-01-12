using System;
using System.IO;

namespace ConsoleApp
{
    public class ItemFoundEventArgs<T> : EventArgs where T : FileSystemInfo
    {
        public T FoundItemInfo { get; }
        public bool CancelRequested { get; set; }

        public ItemFoundEventArgs(T foundItemInfo)
        {
            FoundItemInfo = foundItemInfo;
        }
    }
}
