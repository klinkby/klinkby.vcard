using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Klinkby.VCard
{
    public class VSerializable
    {
        public override string ToString()
        {
            Type t = GetType();
            IEnumerable<PropertyInfo> pi = t.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            string members = pi.Aggregate(
                string.Empty,
                (s, p) =>
                    {
                        object val = p.GetValue(this, null);
                        if (val != null && (!(val is string) || !string.IsNullOrEmpty((string) val)))
                        {
                            Type[] ga = p.PropertyType.GetGenericArguments();
                            bool traverse = val is IEnumerable && ga.Length == 1 &&
                                            ga[0].IsSubclassOf(typeof (VSerializable));
                            s += traverse
                                     ? ((IEnumerable) val).Cast<VSerializable>()
                                                          .Aggregate(string.Empty, (u, v) => u + v.ToString())
                                     : val is VSerializable
                                           ? val.ToString()
                                           : Line(p.Name, val.ToString());
                        }
                        return s;
                    }
                );
            return Line("BEGIN", t.Name.ToUpperInvariant())
                   + members
                   + Line("END", t.Name.ToUpperInvariant());
        }

        private static string Line(string key, string value)
        {
            return key.ToUpperInvariant() + ":" + value.Replace(Environment.NewLine, "\\n") + Environment.NewLine;
        }
    }
}