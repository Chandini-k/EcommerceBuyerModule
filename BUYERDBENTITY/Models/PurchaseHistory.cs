using System;
using System.Collections.Generic;
using System.Text;

namespace BUYERDBENTITY.Models
{
    public class PurchaseHistory
    { 
        public int purchaseId { get; set; }
        public int? buyerId { get; set; }
        public string transactionType { get; set; }
        public int? itemId { get; set; }
        public string itemName { get; set; }
        public int? noOfItems { get; set; }
        public DateTime dateTime { get; set; }
        public string remarks { get; set; }
        public string transactionStatus { get; set; }
    }
}
