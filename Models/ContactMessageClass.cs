namespace WebAPI.Models
{
    public class ContactMessageClass
    {
        public string Contact { get; set; }
        public string Message { get; set; }
        public int Priority { get; set; }

        public string InstitutionID { get; set; }
        public string Department { get; set; }

        public DateTime ScheduleTimestamp { get; set; } //20220511

        public ContactMessageClass()
        {
            Contact = "";
            Message = "";
            Priority = 2;
            InstitutionID = "";
            Department = "";
            ScheduleTimestamp = DateTime.Now; //20220511
        }
    }
}
