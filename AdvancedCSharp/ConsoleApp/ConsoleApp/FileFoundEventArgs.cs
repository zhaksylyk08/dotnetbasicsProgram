using System;

namespace ConsoleApp
{
    public class FileFoundEventArgs : EventArgs
    {
        public readonly string fileName;

        public FileFoundEventArgs(string fileName)
        {
            this.fileName = fileName;
        }
    }
}
