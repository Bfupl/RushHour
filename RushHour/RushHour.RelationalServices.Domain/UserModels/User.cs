using RushHour.BaseService.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour.RelationalServices.Domain.UserModels
{
    public class User : BaseModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
    }
}
