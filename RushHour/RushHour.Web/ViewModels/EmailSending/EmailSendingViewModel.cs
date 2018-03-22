using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RushHour.Web.ViewModels.EmailSending
{
    public class EmailSendingViewModel
    {
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}