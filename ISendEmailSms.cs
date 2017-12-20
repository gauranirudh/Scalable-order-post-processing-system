using System;
using System.Collections.Generic;
using System.Text;

namespace SendSmsEmail
{
    public interface ISendEmailSms
    {
        bool SendSms(Sms smsObject);
        bool SendEmail(Email emailObject);
        void ReceiveMessageFromRabbitMQ(string hostName);
    }
}
