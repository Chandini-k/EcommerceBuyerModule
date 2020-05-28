using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;

namespace BUYERDBENTITY.Models
{
   public class Login
    {
        public string userName { get; set; }
        public string userPassword { get; set; }
        public int buyerId { get; set; }
    }
}
