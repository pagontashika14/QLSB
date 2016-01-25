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
    class QUAN
    {
        public int id { get; set; }
        public string ten_quan { get; set; }
        public QUAN()
        {

        }
    }
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
