using System.Linq;
using System.Reflection;

namespace Task1.Tests
{
    internal static class TestHelper
    {
        public static Assembly GetTask1Assembly() => GetAssemblyByName("Task1");

        private static Assembly GetAssemblyByName(string name)
        {
            var assemblyName = Assembly
                .GetExecutingAssembly()
                .GetReferencedAssemblies()
                .Single(a => a.Name == name);

            return Assembly.Load(assemblyName);
        }
    }
}
