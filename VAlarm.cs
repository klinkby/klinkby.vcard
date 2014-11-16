namespace Klinkby.VCard
{
    public class VAlarm : VSerializable
    {
        public string Trigger { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
    }
}