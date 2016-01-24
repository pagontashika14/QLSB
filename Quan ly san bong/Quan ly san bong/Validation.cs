using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_san_bong
{
    class Validation
    {
        public static bool is_valid_ten_nguoi(string t)
        {
            if (String.IsNullOrEmpty(t)) return false;
            else
            {
                foreach (char c in t.ToCharArray())
                {
                    if (Char.IsDigit(c)) return false;
                }
            }
            return true;
        }
        public static bool is_valid_sdt(string s)
        {
            if (String.IsNullOrEmpty(s) | s.Length > 11 & s.Length < 10) return false;
            else
            {
                foreach (char c in s.ToCharArray())
                {
                    if (Char.IsLetter(c)) return false;
                }
            }
            return true;
        }
        public static bool is_valid_tien(string s)
        {
            if (String.IsNullOrEmpty(s)) return false;
            else
            {
                foreach (char c in s.ToCharArray())
                {
                    if (Char.IsLetter(c)) return false;
                }
            }
            return true;
        }
    }
}
