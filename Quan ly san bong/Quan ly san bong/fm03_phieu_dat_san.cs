using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryApi;

namespace Quan_ly_san_bong
{
    public partial class fm03_phieu_dat_san : Form
    {

        #region Public Interfaces
        public fm03_phieu_dat_san()
        {
            InitializeComponent();
            format_control();
            update_member();
        }
        #endregion
        #region Members
        public DateTime ngay_da;
        DateTime ngay_dat;
        public decimal id_khung_gio;
        public decimal id_khu_san;
        string ma_phieu;
        #endregion
        #region Data Structures
        List<KhungGio> v_list_khung_gio = new List<KhungGio>();
        List<KhuSan> v_list_khu_san = new List<KhuSan>();
        List<San> v_list_san_co_the_dat = new List<San>();
        List<San> v_list_san_dat = new List<San>();
        List<List<string>> param_request = new List<List<string>>();
        #endregion
        #region Struct
        class San
        {
            public decimal id { get; set; }
            public string ten_san { get; set; }
            public San(string ten, string id)
            {
                this.id = decimal.Parse(id);
                this.ten_san = ten;
            }
        }
        class KhuSan
        {
            public decimal id { get; set; }
            public string ten_khu_san { get; set; }
            public KhuSan(string id, string ten)
            {
                this.id = decimal.Parse(id);
                this.ten_khu_san = ten;
            }
        }
        class KhungGio
        {
            public int id;
            public string bd_kt { get; set; }
            public KhungGio(string bd_kt, int id)
            {
                this.id = id;
                this.bd_kt = bd_kt;
            }
        }
        #endregion
        #region Private Methods
        private void format_control()
        {
            this.CenterToScreen();
        }
        private void update_member()
        {
            update_list_khung_gio();
            update_list_khu_san();

        }
        //
        //EVENT HANDLERS
        //
        #endregion
        private void update_ma_phieu()
        {
            MyNetwork.requstGenMaPhieu((object data) =>
            {
                this.Invoke(new Action(() =>
                {
                    var mp = (GenMaPhieu)data;
                    ma_phieu = mp.Data.ToString();
                }));
            });
        }
        private void update_list_khu_san()
        {
            MyNetwork.requestDanhSachKhuSan((object data) =>
            {
                this.Invoke(new Action(() =>
                {
                    var mp = (LibraryApi.KhuSan)data;
                    List<Dictionary<string, object>> list_khu_san = new List<Dictionary<string, object>>();
                    list_khu_san = mp.Data;
                    foreach (Dictionary<string, object> item in list_khu_san)
                    {
                        v_list_khu_san.Add(new KhuSan(item["id"].ToString(), item["ten_khu_san"].ToString()));
                        //v_list_khu_san.Add(new { ID = item["id"].ToString(); Ten = item["ten_khu_san"].ToString(); });

                    }
                    data_to_control();
                }));
            });
        }
        private void update_list_khung_gio()
        {
            v_list_khung_gio.Add(new KhungGio("05:00-06:30", 1));
            v_list_khung_gio.Add(new KhungGio("06:30-08:00", 2));
            v_list_khung_gio.Add(new KhungGio("08:00-09:30", 3));
            v_list_khung_gio.Add(new KhungGio("09:30-11:00", 4));
            v_list_khung_gio.Add(new KhungGio("11:00-12:30", 5));
            v_list_khung_gio.Add(new KhungGio("13:00-14:30", 6));
            v_list_khung_gio.Add(new KhungGio("14:30-16:00", 7));
            v_list_khung_gio.Add(new KhungGio("16:00-17:30", 8));
            v_list_khung_gio.Add(new KhungGio("17:30-19:00", 9));
            v_list_khung_gio.Add(new KhungGio("19:00-20:30", 10));
            v_list_khung_gio.Add(new KhungGio("20:30-22:00", 11));
            v_list_khung_gio.Add(new KhungGio("22:00-23:30", 12));
        }
        private void update_list_san_co_the_dat()
        {
            if (id_khu_san != 0)
            {
                MyNetwork.requestChiTietSan(id_khu_san, string.Format("{0:yyyy/MM/dd}", ngay_da), (object data) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        v_list_san_co_the_dat = new List<San>();
                        var khuSan = new LibraryApi.ChiTietSan();
                        khuSan = (LibraryApi.ChiTietSan)data;
                        List<List<Dictionary<string, object>>> list_ks = new List<List<Dictionary<string, object>>>();
                        list_ks = (List<List<Dictionary<string, object>>>)khuSan.Data;
                        foreach (List<Dictionary<string, object>> item in list_ks)
                        {
                            KhungGio kg =(KhungGio)comb_khung_gio.SelectedItem;
                            if (item[kg.id]["ten_khach_hang"].ToString() == "")
                            {
                                v_list_san_co_the_dat.Add(new San(item[0]["ten_san"].ToString(), item[1]["id_san"].ToString()));
                            }
                        }
                        data_to_san_co_the_dat();
                    }));
                });
            }
        }
        private void data_to_control()
        {
            comb_khung_gio.DataSource = v_list_khung_gio;
            comb_khung_gio.DisplayMember = "bd_kt";

            //
            comb_khu_san.DataSource = v_list_khu_san;
            comb_khu_san.DisplayMember = "ten_khu_san";

            //
            //if (v_list_san_co_the_dat.Count > 0)

            //foreach (San item in v_list_san_co_the_dat)
            //{
            //    comb_san.Items.Add(item);
            //}



            //else
            //{
            //    MessageBox.Show("Đã hết sân! Vui lòng chọn khung giờ khác hoặc khu sân khác");
            //}
        }
        private void data_to_san_co_the_dat()
        {
            comb_san.DataSource = v_list_san_co_the_dat;
            comb_san.DisplayMember = "ten_san";
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ngay_da = dateTimePicker1.Value;
            update_list_san_co_the_dat();
        }

        private void comb_khung_gio_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhungGio kg = (KhungGio)(comb_khung_gio.SelectedItem);
            id_khung_gio = decimal.Parse(kg.id.ToString());
            update_list_san_co_the_dat();
        }

        private void comb_khu_san_SelectedIndexChanged(object sender, EventArgs e)
        {
            KhuSan ks = (KhuSan)(comb_khu_san.SelectedItem);
            id_khu_san = decimal.Parse(ks.id.ToString());
            update_list_san_co_the_dat();
        }

        private void comb_san_SelectedIndexChanged(object sender, EventArgs e)
        {
            v_list_san_dat.Add((San)comb_san.SelectedItem);
        }

        private void btn_add_to_pd_Click(object sender, EventArgs e)
        {
            // truyen vao cac param cho cai request
            foreach (var item in v_list_san_dat)
            {
                List<string> l = new List<string>();
                //param ma phieu
                l.Add("");
                //param ngay dat
                l.Add(string.Format("{0:yyyy/MM/dd}", DateTime.Now.Date));
                //param ngay da
                l.Add(string.Format("{0:yyyy/MM/dd}", ngay_dat));
                //param ten khach hang
                if (Validation.is_valid_ten_nguoi(txt_ten_kh.Text)) l.Add(txt_ten_kh.Text);
                else
                {
                    MessageBox.Show("Bạn nhập sai tên người rồi");
                }
                //param so dien thoai
                if (Validation.is_valid_sdt(txt_sdt.Text)) l.Add(txt_sdt.Text);
                {
                    MessageBox.Show("Số điện thoại không hợp lệ");
                }
                //param gio bat dau
                l.Add(id_khung_gio.ToString());
                //param id_san
                l.Add(item.id.ToString());
                //param dat coc
                if (Validation.is_valid_tien(txt_dat_coc.Text)) l.Add(txt_dat_coc.Text);
                //param thanh toan
                l.Add("N");
                param_request.Add(l);
            }
            //update
            update_list_san_co_the_dat();
        }

        private void btn_delete_pd_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

        }

        private void btn_in_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
