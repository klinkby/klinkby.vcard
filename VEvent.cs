using System;

namespace Klinkby.VCard
{
    public class VEvent : VSerializable
    {
        public VEvent(DateTime fromTime, DateTime toTime, DateTime createdDateTime)
        {
            Transp = "OPAQUE";
            Sequence = 0;
            Priority = 5;
            Class = "PUBLIC";
            Alarm = new VAlarm
                {
                    Trigger = "PT1H",
                    Action = "DISPLAY",
                    Description = "Reminder",
                };
            SetDtStart(fromTime);
            SetDtEnd(toTime);
            SetDtStamp(createdDateTime);
        }

        public string Organizer { get; set; }
        public string DtStart { get; private set; }
        public string DtEnd { get; private set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string Transp { get; set; }
        public int Sequence { get; set; }
        public string UId { get; set; }
        public string DtStamp { get; private set; }
        public string Summary { get; set; }
        public int Priority { get; set; }
        public string Class { get; set; }
        public VAlarm Alarm { get; private set; }

        public void SetDtStart(DateTime dt)
        {
            DtStart = dt.ToString("yyyyMMddTHHmmssZ");
        }

        public void SetDtEnd(DateTime dt)
        {
            DtEnd = dt.ToString("yyyyMMddTHHmmssZ");
        }

        public void SetDtStamp(DateTime dt)
        {
            DtStamp = dt.ToString("yyyyMMddTHHmmssZ");
        }
    }
}