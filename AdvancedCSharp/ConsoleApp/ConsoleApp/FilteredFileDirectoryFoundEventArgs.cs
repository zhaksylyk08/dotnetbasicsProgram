using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class FilteredFileDirectoryFoundEventArgs : EventArgs
    {
        public readonly List<string> filteredDirsAndFiles;

        public FilteredFileDirectoryFoundEventArgs(List<string> filteredDirsAndFiles)
        {
            this.filteredDirsAndFiles = filteredDirsAndFiles;
        }
    }
}
