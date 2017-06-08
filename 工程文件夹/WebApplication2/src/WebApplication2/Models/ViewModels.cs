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
        public Ppics pn { get; set; }
    }
   
    public class ProductCat
    {
        public string typeName { get; set; }
        public List<ProductClassification> types { get; set; }
    }

    public class MemberHomeModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "当前密码")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} 必须至少包含 {2} 个字符。", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "新密码")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "确认新密码")]
        [Compare("NewPassword", ErrorMessage = "新密码和确认密码不匹配。")]
        public string ConfirmPassword { get; set; }
        //public LocalPasswordModel PassWordModel { get; set; }
        public RegisterViewModel CustomerInfo { get; set; }
    }
    public class ProductDtl
    {
        public Product p { get; set; }
        public IEnumerable<Ppics> productpics { get; set; }
        public Ppics pnd { get; set; }
        public Pdetail pdtl { get; set; }
    }
}
