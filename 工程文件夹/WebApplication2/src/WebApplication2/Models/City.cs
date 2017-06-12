using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class City
    {
        public int ObjId { get; set; }
        public int? Ccode { get; set; }
        public string Cname { get; set; }
        public int? ProvinceCode { get; set; }
    }
}
