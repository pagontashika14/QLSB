using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Function
    {
        #region Public Method
        public static void DatSan(
            string ma_phieu,
            DateTime ngay_dat,
            DateTime ngay_da,
            string ten_khach_hang,
            string so_dien_thoai,
            string gio_bat_dau,
            decimal id_san,
            string dat_coc,
            string da_thanh_toan
            )
        {
            if (!coSanBong(id_san))
            {
                throw new Exception("Không có sân bóng này");
            }
            var phieu = new GD_PHIEU_DAT_SAN();
            var phieuChiTiet = new GD_PHIEU_DAT_SAN_CHI_TIET();
            phieu.NGAY_DAT = ngay_dat;
            phieu.NGAY_DA = ngay_da;
            phieu.TEN_KHACH_HANG = ten_khach_hang;
            phieu.SO_DIEN_THOAI = so_dien_thoai;
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                phieu.MA_PHIEU = ma_phieu;
                var san = context.DM_SAN.Where(s => s.ID == id_san).First();
                var gio = context.DM_KHUNG_GIO.Where(s => s.GIO_BAT_DAU == gio_bat_dau).First();
                phieuChiTiet.ID_SAN = id_san;
                phieuChiTiet.ID_KHUNG_GIO = gio.ID;
                phieuChiTiet.GIA = XemGia(san.DM_KHU_SAN.ID,ngay_dat,gio.GIO_BAT_DAU);
                phieuChiTiet.DAT_COC = dat_coc;
                phieuChiTiet.DA_THANH_TOAN = da_thanh_toan;
                phieuChiTiet.HUY_SAN = "N";
                phieu.GD_PHIEU_DAT_SAN_CHI_TIET.Add(phieuChiTiet);
            }
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                if (context.GD_PHIEU_DAT_SAN.Where(s => s.MA_PHIEU == ma_phieu).ToList().Count == 0)
                {
                    context.GD_PHIEU_DAT_SAN.Add(phieu);
                    context.SaveChanges();
                }
                else
                {
                    var phieuDaCo = context.GD_PHIEU_DAT_SAN.Where(s => s.MA_PHIEU == ma_phieu).First();
                    phieuDaCo.GD_PHIEU_DAT_SAN_CHI_TIET.Add(phieuChiTiet);
                    context.SaveChanges();
                }
            }
        }
        public static string genMaPhieu()
        {
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                var phieuCaoNhat = context.GD_PHIEU_DAT_SAN.OrderByDescending(s => s.MA_PHIEU).First();
                long iden = long.Parse(phieuCaoNhat.MA_PHIEU.Substring(3)) + 1;
                string identity = iden.ToString();
                long length = identity.Length;
                for (int i = 0; i < phieuCaoNhat.MA_PHIEU.Length - 2 - length; i++)
                {
                    identity = "0" + identity;
                }
                identity = "PX" + identity;
                return identity;
            }
        }
        public static List<Dictionary<string, object>> LayDanhSachSanBong()
        {
            var danhSach = new List<Dictionary<string, object>>();
            List<DM_SAN> listEntity;
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                listEntity = context.DM_SAN.ToList();

                foreach (DM_SAN item in listEntity)
                {
                    var san = new Dictionary<string, object>();
                    san["id"] = item.ID;
                    san["ten_san"] = item.TEN_SAN;
                    //san["ten_khu_san"] = item.DM_KHU_SAN.TEN_KHU_SAN;
                    var khuSan = context.DM_KHU_SAN.Where(s => s.ID == item.ID_KHU_SAN).First();
                    san["ten_khu_san"] = khuSan.TEN_KHU_SAN;
                    danhSach.Add(san);
                }

            }
            return danhSach;
        }
        public static List<Dictionary<string, object>> LayDanhSachKhungGio()
        {
            var danhSach = new List<Dictionary<string, object>>();
            List<DM_KHUNG_GIO> listEntity;
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                listEntity = context.DM_KHUNG_GIO.ToList();

                foreach (DM_KHUNG_GIO item in listEntity)
                {
                    var gio = new Dictionary<string, object>();
                    gio["id"] = item.ID;
                    gio["gio_bat_dau"] = item.GIO_BAT_DAU;
                    danhSach.Add(gio);
                }
            }
            return danhSach;
        }
        public static List<List<Dictionary<string, object>>> ChiTietKhuSan(decimal id_khu_san, DateTime date)
        {
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                var item = new Dictionary<string, object>();
                var khu_san = context.DM_KHU_SAN.Where(s => s.ID == id_khu_san).First();
                List<DM_SAN> dsSan = khu_san.DM_SAN.OrderBy(s => s.TEN_SAN).ToList();
                int hang = dsSan.Count;
                List<DM_KHUNG_GIO> dsKhungGio = context.DM_KHUNG_GIO.OrderBy(s => s.GIO_BAT_DAU).ToList();
                int cot = dsKhungGio.Count + 1;
                var bang = new List<List<Dictionary<string, object>>>();
                var dsPhieu = context.GD_PHIEU_DAT_SAN.Where(s => s.NGAY_DA == date).ToList();
                for (int i = 0; i < hang; i++)
                {
                    var san = new List<Dictionary<string, object>>();
                    for (int j = 0; j < cot; j++)
                    {
                        var cell = new Dictionary<string, object>();
                        if (j == 0)
                        {
                            cell["ten_san"] = dsSan[i].TEN_SAN;
                        }
                        else
                        {
                            cell["id_san"] = dsSan[i].ID;
                            cell["ten_khach_hang"] = "";
                            cell["id_phieu_dat"] = "";
                            cell["gia"] = XemGia(dsSan[i].ID_KHU_SAN, date, dsKhungGio[j-1].GIO_BAT_DAU);
                        }
                        san.Add(cell);
                    }
                    bang.Add(san);
                }
                foreach (GD_PHIEU_DAT_SAN phieu in dsPhieu)
                {
                    var chiTiet = phieu.GD_PHIEU_DAT_SAN_CHI_TIET.ToList();
                    foreach (GD_PHIEU_DAT_SAN_CHI_TIET phieuChiTiet in chiTiet)
                    {
                        if (phieuChiTiet.DM_SAN.ID_KHU_SAN == id_khu_san)
                        {
                            int i;
                            for (i = 0; i < hang; i++)
                            {
                                if (phieuChiTiet.ID_SAN == dsSan[i].ID) break;
                            }
                            int j;
                            for (j = 0; j < cot - 1; j++)
                            {
                                if (phieuChiTiet.ID_KHUNG_GIO == dsKhungGio[j].ID) break;
                            }
                            bang[i][j + 1]["ten_khach_hang"] = phieu.TEN_KHACH_HANG;
                            bang[i][j + 1]["id_phieu_dat"] = phieu.ID;
                            //bang[i][j + 1]["gia"] = XemGia(id_khu_san,date,phieuChiTiet.DM_KHUNG_GIO.GIO_BAT_DAU);
                            bang[i][j + 1]["gia"] = "";
                        }
                    }
                }
                return bang;
            }
        }
        public static string XemGia(decimal idKhuSan, DateTime time, string gio)
        {
            bool isT7Cn = time.DayOfWeek == DayOfWeek.Sunday || time.DayOfWeek == DayOfWeek.Saturday;
            string t7cn = isT7Cn ? "Y" : "N";
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                var dsLoaiHang = context.DM_LOAI_HANG.Where(s => s.ID_KHU_SAN == idKhuSan)
                    .OrderBy(s => s.GIO_BAT_DAU).ToList();
                foreach (var item in dsLoaiHang)
                {
                    if (int.Parse(gio) > int.Parse(item.GIO_BAT_DAU))
                    {
                        var hang_hoa = item.DM_HANG_HOA
                            .Where(s => s.T7_CN == t7cn)
                            .OrderByDescending(s => s.NGAY_LUU_HANH).First();
                        return hang_hoa.GIA;
                    }
                }
            }
            return "0";
        }
        public static List<Dictionary<string, object>> LayDanhSachKhuSan()
        {
            var danhSach = new List<Dictionary<string, object>>();
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                var listKhuSan = context.DM_KHU_SAN.ToList();
                foreach (var item in listKhuSan)
                {
                    var khuSan = new Dictionary<string, object>();
                    khuSan["id"] = item.ID;
                    khuSan["ten_khu_san"] = item.TEN_KHU_SAN;
                    khuSan["so_dien_thoai"] = item.SO_DIEN_THOAI;
                    khuSan["dia_chi"] = item.DIA_CHI;
                    danhSach.Add(khuSan);
                }
                return danhSach;
            }
        }
        #endregion
        #region Private Method
        static bool coSanBong(decimal id)
        {
            var san = new DM_SAN();
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                san = context.DM_SAN.Where(s => s.ID == id).First();
            }
            if (san == null)
            {
                return false;
            }
            return true;
        }
        static bool coKhungGio(decimal id)
        {
            var khungGio = new DM_KHUNG_GIO();
            using (var context = new DB_9EEDEC_QLSBEntities())
            {
                khungGio = context.DM_KHUNG_GIO.Where(s => s.ID == id).First();
            }
            if (khungGio == null)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}