using System;
using System.Collections.Generic;
using System.Text;

namespace SendSmsEmail
{
    public class Email
    {
        public string EmailAddress { get; set; }
        public string Body { get; set; }
        public object Attachment { get; set; }
    }
}
