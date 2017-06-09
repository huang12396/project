using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Cart
    {
        public string ProductNo { get; set; }
        public int Num { get; set; }
        public string CustomerUserName { get; set; }

        public virtual Customer CustomerUserNameNavigation { get; set; }
        public virtual Product ProductNoNavigation { get; set; }
    }
}
