using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Ppics
    {
        public int ObjId { get; set; }
        public string ProductNo { get; set; }
        public string PicType { get; set; }
        public string PicName { get; set; }

        public virtual Product ProductNoNavigation { get; set; }
    }
}
