using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApi.Models
{
    public class MvcProductsModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CategoryId { get; set; }

        public virtual MvcCategoryModel Category { get; set; }
    }
}