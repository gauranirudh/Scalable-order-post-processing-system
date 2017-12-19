using System;
using System.Collections.Generic;
using System.Text;

namespace SendSmsEmail
{
    public class Sms
    {
        public string PhoneNumber { get; set; } // string because it can have country codes with +
        public string Body { get; set; }
    }
}
