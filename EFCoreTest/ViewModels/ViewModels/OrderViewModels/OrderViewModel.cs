using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Is Delivered")]
        public bool Delivered { get; set; }
        [Display(Name = "Payment Method")]
        public PaymentMethodEnum PaymentMethod { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "User")]
        public int UserId { get; set; }
    }
}
