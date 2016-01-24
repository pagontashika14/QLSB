using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_san_bong
{
    class SAN
    {
        public int id { get; set; }
        public int id_khu_san { get; set; }
        public string ten_san { get; set; }
        public SAN(string id, string id_khu, string ten)
        {
            this.id = Convert.ToInt16(id);
            this.id_khu_san = Convert.ToInt16(id_khu);
            this.ten_san = ten;
        }
    }
}
