using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Scissors.Utils
{
    public static class ResourceExtentions
    {
        public static Stream GetResourceStream(this object obj, string path)
        {
            Guard.AssertNotNull(obj, nameof(obj));

            return GetResourceStream(obj.GetType(), path);
        }

        public static Stream GetResourceStream(this Type type, string path)
        {
            Guard.AssertNotNull(type, nameof(type));
            Guard.AssertNotEmpty(path, nameof(path));

            var assembly = type.Assembly;
            var name = type.Assembly.GetName().Name;

            path = path.Replace("/", ".").Replace("\\", ".");

            var fullPath = $"{name}.{path}";
            var stream = assembly.GetManifestResourceStream(fullPath);

            if(stream == null)
            {
                throw new ResourceNotFoundException(assembly, path);
            }

            return stream;
        }
    }
}
