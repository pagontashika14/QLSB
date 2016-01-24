using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_ly_san_bong
{
    public static class System_Info
    {
        public static DateTime current_date_time { get; set; }
        public static void update()
        {
            current_date_time = DateTime.Now;     
        }
        public static string get_day_of_week(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Monday) return "Thứ hai";
            if (date.DayOfWeek == DayOfWeek.Tuesday) return "Thứ ba";
            if (date.DayOfWeek == DayOfWeek.Wednesday) return "Thứ tư";
            if (date.DayOfWeek == DayOfWeek.Thursday) return "Thứ năm";
            if (date.DayOfWeek == DayOfWeek.Friday) return "Thứ sáu";
            if (date.DayOfWeek == DayOfWeek.Saturday) return "Thứ bảy";
            if (date.DayOfWeek == DayOfWeek.Sunday) return "Chủ nhật";
            else return "";
        }
    }
}
