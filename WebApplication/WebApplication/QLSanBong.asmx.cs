using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Collections;

namespace WebApplication
{
    /// <summary>
    /// Summary description for QLSanBong
    /// </summary>
    [WebService(Namespace = "http://pagontashika13.com")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class QLSanBong : System.Web.Services.WebService
    {
        void TraKetQua(KetQuaTraVe result)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(result));
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void HelloName(string first_name)
        {
            string last_name = Context.Request["last_name"];
            string name = first_name + " " + last_name;
            var result = new KetQuaTraVe(true, "Thành công", "Xin chào " + name);
            TraKetQua(result);
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DatSan(
            string ma_phieu,
            DateTime ngay_dat,
            DateTime ngay_da,
            string ten_khach_hang,
            string so_dien_thoai,
            decimal gio_bat_dau,
            decimal id_san,
            string dat_coc,
            string da_thanh_toan)
        {
            try
            {
                Function.DatSan(ma_phieu, ngay_dat, ngay_da,
                    ten_khach_hang, so_dien_thoai,
                    gio_bat_dau, id_san, dat_coc, da_thanh_toan);
                var result = new KetQuaTraVe(true, "Đặt sân thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GenMaPhieu()
        {
            try
            {
                var data = Function.genMaPhieu();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DanhSachSan()
        {
            try
            {
                var data = Function.LayDanhSachSanBong();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DanhSachKhungGio()
        {
            try
            {
                var data = Function.LayDanhSachKhungGio();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ChiTietKhuSan(decimal id_khu_san, DateTime ngay)
        {
            try
            {
                var data = Function.ChiTietKhuSan(id_khu_san, ngay);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DanhSachKhuSan()
        {
            try
            {
                var data = Function.LayDanhSachKhuSan();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void HuyToanBoSan(decimal id_phieu_dat)
        {
            try
            {
                Function.HuyToanBoSan(id_phieu_dat);
                var result = new KetQuaTraVe(true, "OK", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DangNhap(string user_name, string password)
        {
            try
            {
                var data = Function.DangNhap(user_name, password);
                var result = new KetQuaTraVe(true, "Đăng nhập thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
    }
}
