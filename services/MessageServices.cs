using WebAPI.Models;

namespace WebAPI.services
{
    public class MessageServices
    {
        enum EumJobStatus { New = 0, Pending = 11, Sent = 12, Failed = 10, Queuing = 20, Delivered = 21, Undelivered = 22, Incoming = 32, GeneralError = -1, Deleted = 33 }

        readonly DataLayer? _oDataLayer = null;

        public MessageServices(string connString, string logDir)
        {
            DataLayer _oDataLayer = new DataLayer(connString);
      
        }

        public MessageResultClass SendMessageEx(string Token, MessageExClass Messages) {

            MessageResultClass Result = new MessageResultClass();
            foreach (var contactMessage in Messages.ContactMessages) {
                ResultClass messageResult = new ResultClass();
                messageResult.Contact = contactMessage.Contact;
                messageResult.Status = 1;
                messageResult.StatusDescription = "OK";
                Result.Results.Add(messageResult);
            }
            return Result;
        }
    }
}
