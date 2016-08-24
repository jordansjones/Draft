using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Draft
{
    internal static class SerializationInfoExtensions
    {
        public static void TryGetString(this SerializationInfo This, string name, Action<string> callback)
        {
            try
            {
                var value = This.GetString(name);
                if (!string.IsNullOrEmpty(value))
                    callback(value);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}