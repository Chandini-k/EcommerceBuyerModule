using System;
using System.Collections.Generic;

namespace BUYERDBENTITY.Entity
{
    public partial class Items
    {
        public Items()
        {
            Cart = new HashSet<Cart>();
            Purchasehistory = new HashSet<Purchasehistory>();
        }

        public int Itemid { get; set; }
        public int Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int? Stockno { get; set; }
        public string Remarks { get; set; }
        public string Imagename { get; set; }

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual ICollection<Purchasehistory> Purchasehistory { get; set; }
    }
}
