namespace WebAPI.Models
{
    public class MessageExClass
    {
        public string UserId { get; set; }
        public string InstitutionID { get; set; }
        public string Department { get; set; }
        public List<ContactMessageClass> ContactMessages { get; set; }

        public MessageExClass()
        {
            UserId = "";
            InstitutionID = "";
            Department = "";
            ContactMessages = new List<ContactMessageClass>();
        }
    }
}
