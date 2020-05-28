using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BUYERDBENTITY.Models
{
    public class BuyerRegister
    {
       
        public int buyerId { get; set; }
        [Required(ErrorMessage = "pls Enter Name")]
        [StringLength(maximumLength: 20, ErrorMessage = "Name should not be greater than 20")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string password { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string emailId { get; set; }
        [RegularExpression(@"[6-9]\d{9}", ErrorMessage = "Invalid Number")]
        public string mobileNo { get; set; }
        public DateTime dateTime { get; set; }

    }
}
