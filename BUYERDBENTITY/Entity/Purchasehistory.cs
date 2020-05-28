using System;
using System.Collections.Generic;

namespace BUYERDBENTITY.Entity
{
    public partial class Purchasehistory
    {
        public int Purchaseid { get; set; }
        public int? Buyerid { get; set; }
        public string Transactiontype { get; set; }
        public int? Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Noofitems { get; set; }
        public DateTime Datetime { get; set; }
        public string Remarks { get; set; }
        public string Transactionstatus { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Items Item { get; set; }
    }
}
