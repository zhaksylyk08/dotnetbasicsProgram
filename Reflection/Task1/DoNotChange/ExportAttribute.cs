using System;

namespace Task1.DoNotChange
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportAttribute : Attribute
    {
        public ExportAttribute()
        {
        }

        public ExportAttribute(Type contract)
        {
            Contract = contract;
        }

        public Type Contract { get; }
    }
}
