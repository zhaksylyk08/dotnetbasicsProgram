using System;

namespace ClassLibrary
{
    public class Class1
    {
        public static string SayHello(string name)
        {
            return $"{DateTime.Now} Hello, {name}!";
        }
    }
}
