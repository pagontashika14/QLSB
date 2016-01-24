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
using System.Threading;


namespace Quan_ly_san_bong
{
    public partial class fm02_grid_san : Form
    {

        #region Public Interfaces
        public fm02_grid_san()
        {
            InitializeComponent();
            format_control();
        }
        #endregion
        #region Members
        string v_current_view_mode = "ten_khach_hang";
        decimal v_current_id_khu_San;
        DateTime v_current_date;
        #endregion
        #region Data Structures
        List<string> v_list_khung_gio = new List<string> {"05:00-06:30",
                                                          "06:30-08:00",
                                                          "08:00-09:30",
                                                          "09:30-11:00",
                                                          "11:00-12:30",
                                                          "13:00-14:30",
                                                          "14:30-16:00",
                                                          "16:00-17:30",
                                                          "17:30-19:00",
                                                          "19:00-20:30",
                                                          "20:30-22:00",
                                                          "22:00-23:30" };
        List<List<Dictionary<string, object>>> v_list_san = new List<List<Dictionary<string, object>>>();
        List<Dictionary<string, object>> v_list_khu_san = new List<Dictionary<string, object>>();
        List<List<Dictionary<string, object>>> v_list_phieu_Dat = new List<List<Dictionary<string, object>>>();
        #endregion
        #region Private Methods
        //
        //EVENT HANDLERS
        //
        private void format_control()
        {
            MyNetwork.requestDanhSachKhuSan((object data) => 
            {
                this.Invoke(new Action(() => 
                {
                    var khuSan = new KhuSan();
                    khuSan = (KhuSan)data;
                    v_list_khu_san = khuSan.Data;
                    List<ComboboxKhuSan> list = new List<ComboboxKhuSan>();
                    foreach (Dictionary<string, object> item in v_list_khu_san)
                    {
                        var cbItem = new ComboboxKhuSan();
                        cbItem.ID =decimal.Parse(item["id"].ToString());
                        cbItem.TenKhuSan = item["ten_khu_san"].ToString();
                        list.Add(cbItem);
                    }
                    comboBox1.DataSource = list;
                    comboBox1.DisplayMember = "TenKhuSan";
                    comboBox1.ValueMember = "ID";
                }));
            });
            
        }
        private void update_member()
        {
            if (comboBox1.SelectedItem != null & dateTimePicker1.Value != null)
            {
                decimal id_khu_san = v_current_id_khu_San;
                string time = string.Format("{0:yyyy/MM/dd}", v_current_date);
                MyNetwork.requestChiTietSan(id_khu_san, time, (object data) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        var san = new ChiTietSan();
                        san = (ChiTietSan)data;
                        v_list_san = san.Data;
                        draw_grid();
                    }));
                });
                this.Text = "Lịch đặt sân ngày " + string.Format("{0:dd/MM/yyy}", dateTimePicker1.Value);
            }
        }

        private void draw_grid()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            RowStyle b = new RowStyle();
            b.SizeType = SizeType.Absolute;
            b.Height = 40;
            tableLayoutPanel1.RowStyles.Add(b);
            //
            for (int i = 1; i < 13; i++)
            {
                Label lb = new Label();
                lb.Text = v_list_khung_gio[i - 1];
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.Dock = DockStyle.Fill;
                tableLayoutPanel1.Controls.Add(lb, i, 0);
            }
            //
            for (int i = 0; i <v_list_san.Count; i++)
            {
                RowStyle a = new RowStyle();
                a.SizeType = SizeType.Absolute;
                a.Height = 80;
                tableLayoutPanel1.RowStyles.Add(a);
                for (int j = 0; j < 13; j++)
                {
                    if (j == 0)
                    {
                        Label l = new Label();
                        l.Text = v_list_san[i][j]["ten_san"].ToString();
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        if (i == v_list_san.Count - 1)
                        {
                            l.Height = 80;
                        }
                        else
                        {
                            l.Dock = DockStyle.Fill;
                        }
                        tableLayoutPanel1.Controls.Add(l, j, i+1);
                    }
                    else
                    {
                        Button bt = new Button();
                        if (i == v_list_san.Count - 1)
                        {
                            bt.Height = 80;
                        }
                        else
                        {
                            bt.Dock = DockStyle.Fill;
                        }
                        tableLayoutPanel1.Controls.Add(bt, j, i + 1);
                        bt.Text = v_list_san[i][j][v_current_view_mode].ToString();
                        bt.Click += new EventHandler(this.grid_bt_click);
                        //bt.Dock = DockStyle.Fill;
                    }
                }
            }
        }
        private void grid_bt_click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            this.contextMenuStrip1.Show(ptLowerLeft);
        }
        #endregion
        #region Struct
        class ComboboxKhuSan
        {
            public decimal ID { get; set; }
            public string TenKhuSan { get; set; }
        }
        #endregion
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            v_current_date = (DateTime)dateTimePicker1.Value;
            update_member();
        }

        private void accordionControl1_Click(object sender, EventArgs e)
        {

        }
        private void view_theo_gia_Click(object sender, EventArgs e)
        {
            v_current_view_mode = "gia";
            draw_grid();
        }

        private void view_kh_click(object sender, EventArgs e)
        {
            v_current_view_mode = "ten_khach_hang";
            draw_grid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = new ComboboxKhuSan();

            item = (ComboboxKhuSan)comboBox1.SelectedItem;
            v_current_id_khu_San = item.ID;
            //v_current_id_khu_San = decimal.Parse(dic["id"].ToString());
            update_member();
        }

        private void data_to_form()
        {

        }
        private void đặtSânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fm03_phieu_dat_san m_pd = new fm03_phieu_dat_san();
            m_pd.Show();
            data_to_form();
        }
    }
}
