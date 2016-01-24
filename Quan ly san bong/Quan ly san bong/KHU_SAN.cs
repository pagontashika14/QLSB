using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_san_bong
{
    class KHU_SAN
    {
        public int id { get; set; }
        public string ten_khu_san { get; set; }
        public string dia_chi { get; set; }
        public KHU_SAN(string id, string ten, string dc)
        {
            this.id = Convert.ToInt16(id);
            this.ten_khu_san = ten;
            this.dia_chi = dc;
        }
    }
}
