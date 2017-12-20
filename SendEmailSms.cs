using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace SendSmsEmail
{
    public class SendEmailSms : ISendEmailSms
    {
        public void ReceiveMessageFromRabbitMQ(string hostName)
        {
            //hostName can be "localhost"
            ReceiverRabbitMQ receiver = new ReceiverRabbitMQ(hostName);
            receiver.ReceiveMessage();
            Sms sms = new Sms();
            Email email = new Email();
            bool smsStatus = SendSms(sms);
            bool emailStatus = SendEmail(email);
        }

        public bool SendSms(Sms smsObject)
        {
            try
            {
                if (!IsPhoneNumberValid(smsObject.PhoneNumber))
                {
                    //log Invalid Phone Number
                    return false;
                }
                //send sms using third party services
                return true;
            }
            catch(Exception ex)
            {
                //log proper error message
                throw;
            }
        }
        public bool SendEmail(Email emailObject)
        {
            try
            {
                if (!IsEmailAddressValid(emailObject.EmailAddress))
                {
                    //log Invalid Email Address
                    return false;
                }
                if(IsInvoiceGenerated())
                {
                    //Attach Invoice
                }
                else
                {
                    //Attach footer message
                }
                //send email using third party services
                return true;
            }
            catch (Exception ex)
            {
                //log proper error message
                throw;
            }
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            return Regex.Match(phoneNumber, @"^(\+[0-9]{9})$").Success;
        }

        private bool IsEmailAddressValid(string emailAddress)
        {
            try
            {
                var addr = new MailAddress(emailAddress);
                return addr.Address == emailAddress;
            }
            catch
            {
                return false;
            }
        }

        private bool IsInvoiceGenerated()
        {
            //return true or false based on invoice is generated or not
            return true;
        }
    }
}
