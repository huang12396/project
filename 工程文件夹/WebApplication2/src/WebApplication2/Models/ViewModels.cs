using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models.AccountViewModels;

namespace WebApplication2.Models
{
    public class HomeIndexViewModel
    {
        public List<ProductList> recProducts { get; set; }
        public List<ProductList> disProducts { get; set; }
        public List<ProductCat> productCats { get; set; }
    }

    public class ProductList
    {
        public Product p { get; set; }
    }
    public class ProductCat
    {
        public string typeName { get; set; }
        public List<ProductClassification> types { get; set; }
    }
}
