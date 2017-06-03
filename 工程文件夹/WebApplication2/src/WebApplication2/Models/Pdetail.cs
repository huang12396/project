using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class Pdetail
    {
        public int ObjId { get; set; }
        public string ProductNo { get; set; }
        public string XiangXing { get; set; }
        public string Yuanliao { get; set; }
        public string Chucangtiaojian { get; set; }
        public string Jiuchang { get; set; }
        public string Jinghanliang { get; set; }
        public string Gongyi { get; set; }
        public string Jiujingdu { get; set; }
        public string Xianggui { get; set; }

        public virtual Product ProductNoNavigation { get; set; }
    }
}
