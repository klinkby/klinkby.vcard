using System.Collections.Generic;

namespace Klinkby.VCard
{
    public class VCalendar : VSerializable
    {
        public VCalendar()
        {
            Method = "PUBLISH";
        }

        public string Method { get; set; }
        public IEnumerable<VEvent> Events { get; set; }
    }
}