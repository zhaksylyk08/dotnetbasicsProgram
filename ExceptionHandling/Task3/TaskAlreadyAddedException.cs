using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class TaskAlreadyAddedException : Exception
    {
        public TaskAlreadyAddedException() { }

        public TaskAlreadyAddedException(string message)
            : base(message)
        {

        }

        public TaskAlreadyAddedException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
