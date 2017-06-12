using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Province
    {
        public int ObjId { get; set; }
        public int? Pcode { get; set; }
        public string Pname { get; set; }
        public int? NationCode { get; set; }
    }
}
