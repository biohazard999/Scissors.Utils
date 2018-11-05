using System;
using System.Linq;
using System.Reflection;

namespace Scissors.Utils
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException(Assembly assembly, string resourceName) : base($"Resource '{resourceName}' was not found in Assembly '{assembly.GetName().Name}'")
        {
            Assembly = assembly;
            ResourceName = resourceName;
        }

        public Assembly Assembly { get; }

        public string ResourceName { get; }

        public string ResourcePath => $"{Assembly.GetName().Name}.{ResourceName}";
    }
}
