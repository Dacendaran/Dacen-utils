using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dacen.Utils.Reflection
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// Gets every type deriving from this type
        /// </summary>
        /// <param name="type">The type to get the deriving types for</param>
        /// <param name="baseTypeInclusive">Should the base type (the type this method is executed for) be included in the returned IEnumerable?</param>
        /// <returns>Every type deriving from the type this method is executed for</returns>
        public static IEnumerable<Type> GetDerivingTypes(Type type, bool baseTypeInclusive = false)
        {
            if (baseTypeInclusive)
                return Assembly.GetExecutingAssembly().GetTypes().Where(t => type.IsAssignableFrom(t));
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t != type && type.IsAssignableFrom(t));
        }
    }
}