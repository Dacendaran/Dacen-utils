using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dacen.Utils.Reflection
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// Gets every type directly deriving from a type
        /// </summary>
        /// <param name="type">The type to get the deriving types for</param>
        /// <param name="assembly">The assembly to search for deriving types in. If null, <see cref="Assembly.GetExecutingAssembly"/> is used</param>
        /// <param name="baseTypeInclusive">Should the passed base type be included in the returned IEnumerable?</param>
        /// <returns>Every type directly deriving from the passed type</returns>
        public static IEnumerable<Type> GetDerivingTypes(Type type, Assembly assembly = null, bool baseTypeInclusive = false)
        {
            assembly ??= Assembly.GetExecutingAssembly();
            var result = assembly.GetTypes().Where(t => type.IsAssignableFrom(t));
            return baseTypeInclusive ? result : result.Where(t => t != type);
		}

		/// <summary>
		/// Gets every type directly deriving from a generic type
		/// </summary>
		/// <param name="genericType">The generic type to get the deriving types for (pass it as typeof(GenericElement<>)</param>
		/// <param name="assembly">The assembly to search for deriving types in. If null, <see cref="Assembly.GetExecutingAssembly"/> is used</param>
		/// <param name="baseTypeInclusive">Should the passed base type be included in the returned IEnumerable?</param>
		/// <returns>Every type directly deriving from the passed type</returns>
		public static IEnumerable<Type> GetGenericDerivingTypes(Type genericType, Assembly assembly = null, bool baseTypeInclusive = false)
        {
			assembly ??= Assembly.GetExecutingAssembly();
            var result = assembly.GetTypes()
	            .Where(t => t.BaseType?.IsGenericType == true && t.BaseType.GetGenericTypeDefinition() == genericType);
			return baseTypeInclusive ? result : result.Where(t => t != genericType);
		}
    }
}