using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RushHour.Web.ViewModels.EmailSending
{
    public class EmailSendingViewModel
    {
        [Required(ErrorMessage = "Field cannot be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Comment { get; set; }
    }
}