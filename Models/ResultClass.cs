namespace WebAPI.Models
{
    public class ResultClass
    {
        public int Status { get; set; }
        public string StatusDescription { get; set; }
        public string MessageId { get; set; }
        public string Contact { get; set; }
        public int ErrorCode { get; set; }
        public ResultClass()
        {
            Status = 0;
            StatusDescription = "";
            MessageId = "";
            Contact = "";
            ErrorCode = -20;
        }
    }
}
