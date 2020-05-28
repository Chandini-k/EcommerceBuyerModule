using System;
using System.Collections.Generic;

namespace BUYERDBENTITY.Entity
{
    public partial class Cart
    {
        public int Cartid { get; set; }
        public int? Buyerid { get; set; }
        public int? Itemid { get; set; }
        public int Price { get; set; }
        public string Itemname { get; set; }
        public string Description { get; set; }
        public int? Stockno { get; set; }
        public string Remarks { get; set; }
        public string Imagename { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Items Item { get; set; }
    }
}
