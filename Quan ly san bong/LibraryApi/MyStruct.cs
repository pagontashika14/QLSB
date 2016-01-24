using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi
{
    public class ChiTietSan
    {
        public bool Success;
        public string Message;
        public List<List<Dictionary<string, object>>> Data;
    }
    public class KhuSan
    {
        public bool Success;
        public string Message;
        public List<Dictionary<string, object>> Data;
    }
    public class GenMaPhieu
    {
        public bool Success;
        public string Message;
        public string Data;
    }
}
