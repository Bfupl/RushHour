using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RushHour.Web.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public string Phone { get; set; }
        public bool IsAdmin { get; set; }
    }
}