using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Windows;
using Newtonsoft.Json;

namespace LibraryApi
{
    public class MyNetwork
    {
        public const string URL_SERVICE = @"http://pagontashika14-001-site1.1tempurl.com/QLSanBong.asmx/";
        public const string URL_CHI_TIET_KHU_SAN = URL_SERVICE + @"ChiTietKhuSan";
        public const string URL_DANH_SACH_KHU_SAN = URL_SERVICE + @"DanhSachKhuSan";
        public const string URL_DAT_SAN = URL_SERVICE + "DatSan";
        public const string URL_GEN_MA_PHIEU = URL_SERVICE + "GenMaPhieu";

        public delegate void CompleteHandle(object data);
        static void requestDataWithParam<T>(Dictionary<string, object> param
            , string url
            , CompleteHandle MyDelegate
            )
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                foreach (KeyValuePair<string, object> pair in param)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }
                client.ExecuteAsync(request, response =>
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        T jsonObject = JsonConvert.DeserializeObject<T>(response.Content);
                        MyDelegate(jsonObject);
                    }
                    else
                    {
                        throw new Exception(response.ErrorMessage);
                    }
                });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #region Publish Funtion
        public static void requestChiTietSan(
            decimal id_khu_san,
            string ngay,
            CompleteHandle MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["id_khu_san"] = id_khu_san;
            param["ngay"] = ngay;
            requestDataWithParam<ChiTietSan>(param, URL_CHI_TIET_KHU_SAN, MyDelegate);
        }

        public static void requestDanhSachKhuSan(
           CompleteHandle MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            requestDataWithParam<KhuSan>(param, URL_DANH_SACH_KHU_SAN, MyDelegate);
        }
        public static void requestDatSan(
            string ma_phieu,
            DateTime ngay_dat,
            DateTime ngay_da,
            string ten_khach_hang,
            string so_dien_thoai,
            string gio_bat_dau,
            decimal id_san,
            string dat_coc,
            string da_thanh_toan,
            CompleteHandle MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["ma_phieu"] = ma_phieu;
            param["ngay_dat"] = ngay_dat;
            param["ngay_da"] = ngay_da;
            param["ten_khach_hang"] = ten_khach_hang;
            param["so_dien_thoai"] = so_dien_thoai;
            param["gio_bat_dau"] = gio_bat_dau;
            param["id_san"] = id_san;
            param["dat_coc"] = dat_coc;
            param["da_thanh_toan"] = da_thanh_toan;
            requestDataWithParam<Dictionary<string, object>>(param, URL_DAT_SAN, MyDelegate);
        }
        public static void requstGenMaPhieu(CompleteHandle MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            requestDataWithParam<GenMaPhieu>(param, URL_GEN_MA_PHIEU, MyDelegate);
        }
        #endregion
    }
}
