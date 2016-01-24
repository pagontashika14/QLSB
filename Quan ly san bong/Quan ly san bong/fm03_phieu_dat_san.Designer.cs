namespace Quan_ly_san_bong
{
    partial class fm03_phieu_dat_san
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm03_phieu_dat_san));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ten_kh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comb_khu_san = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_dat_coc = new System.Windows.Forms.TextBox();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_in = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comb_khung_gio = new System.Windows.Forms.ComboBox();
            this.comb_san = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_add_to_pd = new DevExpress.XtraEditors.SimpleButton();
            this.btn_delete_pd = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên khách hàng";
            // 
            // txt_ten_kh
            // 
            this.txt_ten_kh.Location = new System.Drawing.Point(113, 21);
            this.txt_ten_kh.Name = "txt_ten_kh";
            this.txt_ten_kh.Size = new System.Drawing.Size(199, 20);
            this.txt_ten_kh.TabIndex = 1;
            
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(343, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Số điện thoại";
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(417, 21);
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(121, 20);
            this.txt_sdt.TabIndex = 3;
            
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khu sân";
            // 
            // comb_khu_san
            // 
            this.comb_khu_san.FormattingEnabled = true;
            this.comb_khu_san.Location = new System.Drawing.Point(112, 118);
            this.comb_khu_san.Name = "comb_khu_san";
            this.comb_khu_san.Size = new System.Drawing.Size(200, 21);
            this.comb_khu_san.TabIndex = 5;
            this.comb_khu_san.SelectedIndexChanged += new System.EventHandler(this.comb_khu_san_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày đá";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(112, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Đặt cọc";
            // 
            // txt_dat_coc
            // 
            this.txt_dat_coc.Location = new System.Drawing.Point(113, 170);
            this.txt_dat_coc.Name = "txt_dat_coc";
            this.txt_dat_coc.Size = new System.Drawing.Size(199, 20);
            this.txt_dat_coc.TabIndex = 11;
            
            // 
            // btn_save
            // 
            this.btn_save.Image = ((System.Drawing.Image)(resources.GetObject("btn_save.Image")));
            this.btn_save.Location = new System.Drawing.Point(138, 476);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(115, 32);
            this.btn_save.TabIndex = 12;
            this.btn_save.Text = "Lưu lại";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_in
            // 
            this.btn_in.Image = ((System.Drawing.Image)(resources.GetObject("btn_in.Image")));
            this.btn_in.Location = new System.Drawing.Point(288, 476);
            this.btn_in.Name = "btn_in";
            this.btn_in.Size = new System.Drawing.Size(110, 32);
            this.btn_in.TabIndex = 13;
            this.btn_in.Text = "In phiếu đặt";
            this.btn_in.Click += new System.EventHandler(this.btn_in_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_cancel.Image")));
            this.btn_cancel.Location = new System.Drawing.Point(433, 476);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(105, 32);
            this.btn_cancel.TabIndex = 14;
            this.btn_cancel.Text = "Hủy";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Sân";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(343, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Khung giờ";
            // 
            // comb_khung_gio
            // 
            this.comb_khung_gio.FormattingEnabled = true;
            this.comb_khung_gio.Location = new System.Drawing.Point(417, 69);
            this.comb_khung_gio.Name = "comb_khung_gio";
            this.comb_khung_gio.Size = new System.Drawing.Size(121, 21);
            this.comb_khung_gio.TabIndex = 17;
            this.comb_khung_gio.SelectedIndexChanged += new System.EventHandler(this.comb_khung_gio_SelectedIndexChanged);
            // 
            // comb_san
            // 
            this.comb_san.FormattingEnabled = true;
            this.comb_san.Location = new System.Drawing.Point(417, 118);
            this.comb_san.Name = "comb_san";
            this.comb_san.Size = new System.Drawing.Size(121, 21);
            this.comb_san.TabIndex = 18;
            this.comb_san.SelectedIndexChanged += new System.EventHandler(this.comb_san_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(30, 271);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(508, 186);
            this.listBox1.TabIndex = 19;
            // 
            // btn_add_to_pd
            // 
            this.btn_add_to_pd.Image = ((System.Drawing.Image)(resources.GetObject("btn_add_to_pd.Image")));
            this.btn_add_to_pd.Location = new System.Drawing.Point(113, 219);
            this.btn_add_to_pd.Name = "btn_add_to_pd";
            this.btn_add_to_pd.Size = new System.Drawing.Size(129, 32);
            this.btn_add_to_pd.TabIndex = 21;
            this.btn_add_to_pd.Text = "Thêm vào phiếu";
            this.btn_add_to_pd.Click += new System.EventHandler(this.btn_add_to_pd_Click);
            // 
            // btn_delete_pd
            // 
            this.btn_delete_pd.Image = ((System.Drawing.Image)(resources.GetObject("btn_delete_pd.Image")));
            this.btn_delete_pd.Location = new System.Drawing.Point(346, 219);
            this.btn_delete_pd.Name = "btn_delete_pd";
            this.btn_delete_pd.Size = new System.Drawing.Size(116, 32);
            this.btn_delete_pd.TabIndex = 22;
            this.btn_delete_pd.Text = "Xóa khỏi phiếu";
            this.btn_delete_pd.Click += new System.EventHandler(this.btn_delete_pd_Click);
            // 
            // fm03_phieu_dat_san
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 520);
            this.Controls.Add(this.btn_delete_pd);
            this.Controls.Add(this.btn_add_to_pd);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.comb_san);
            this.Controls.Add(this.comb_khung_gio);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_in);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txt_dat_coc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comb_khu_san);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_sdt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ten_kh);
            this.Controls.Add(this.label1);
            this.Name = "fm03_phieu_dat_san";
            this.Text = "fm03_phieu_dat_san";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ten_kh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_sdt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comb_khu_san;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_dat_coc;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.SimpleButton btn_in;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comb_khung_gio;
        private System.Windows.Forms.ComboBox comb_san;
        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraEditors.SimpleButton btn_add_to_pd;
        private DevExpress.XtraEditors.SimpleButton btn_delete_pd;
    }
}