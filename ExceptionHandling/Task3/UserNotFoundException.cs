using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() { }

        public UserNotFoundException(string message)
            :base(message)
        {

        }

        public UserNotFoundException(string message, Exception inner)
            :base(message, inner)
        {

        }
    }
}
