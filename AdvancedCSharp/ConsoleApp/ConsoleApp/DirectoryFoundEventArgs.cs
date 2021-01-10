using System;

namespace ConsoleApp
{
    public class DirectoryFoundEventArgs : EventArgs
    {
        public readonly string directoryName;

        public DirectoryFoundEventArgs(string directoryName)
        {
            this.directoryName = directoryName;
        }
    }
}
