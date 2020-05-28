using System;
using System.Collections.Generic;
using System.Text;

namespace BUYERDBENTITY.Models
{
    public class Product
    {
        public string productName { get; set; }
        public int productId { get; set; }
        public int? categoryId { get; set; }
        public int? subCategoryId { get; set; }
        public int? price { get; set; }
        public string description { get; set; }
        public int? stockno { get; set; }
        public string remarks { get; set; }
        public string imageName { get; set; }
        public string categoryName { get; set; }
        public string subCategoryName { get; set; }
    }
}
