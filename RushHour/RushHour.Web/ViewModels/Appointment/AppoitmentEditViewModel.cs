using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RushHour.Web.ViewModels.Appointment
{
    public class AppoitmentEditViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<ViewModels.CheckBoxView.ListCheckBoxViewModel> Activities { get; set; }

        [Required]
        public string StartDateTime { get; set; }

        [Required]
        public string EndDateTime { get; set; }
    }
}