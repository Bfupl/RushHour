using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace RushHour.Web.ViewModels
{
    public class ActivityViewModel :BaseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Duration { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public bool IsChecked { get; set; }
    }
}