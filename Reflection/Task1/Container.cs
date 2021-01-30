using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;

namespace Task1
{
    public class Container
    {
        private List<Type> types;

        public Container()
        {
            types = new List<Type>();
        }

        public void AddAssembly(Assembly assembly)
        {
            throw new NotImplementedException();
        }

        public void AddType(Type type)
        {
            var customAttributes = type.GetCustomAttributes();

            if (customAttributes.Count() > 0)
            {
                types.Add(type);
            }
        }

        public void AddType(Type type, Type baseType)
        {
            throw new NotImplementedException();
        }

        public T Get<T>()
        {
            var type = typeof(T);

            if (types.Contains(type))
            {

            }

            return default(T);
        }
    }
}
