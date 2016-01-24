using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraBars.Docking2010;


namespace Quan_ly_san_bong
{
    public partial class f01_main_form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Public Interfaces
        public f01_main_form()
        {
            InitializeComponent();
            format_control();
           
            //Start timer
            m_timer.Start();
        }
        #endregion

        #region Members

        #endregion

        #region Data Structures

        #endregion

        #region Private Methods
        private void format_control()
        {
            //Cursor fails
            this.Cursor = Cursors.Arrow;
            this.UseWaitCursor = false;
            //tabbed view for child form
            DocumentManager manager = new DocumentManager();
            manager.MdiParent = this;
            manager.View = new TabbedView();
            //control's font formatting
            m_grp_lich.AppearanceCaption.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            //
            m_lbl_thu.Font = new Font("Comic Sans", 18, FontStyle.Bold);
            //
            m_lbl_ngay.Font = new Font("Comic Sans", 14, FontStyle.Regular);
        }
        private void update()
        {
            System_Info.update();
            info_to_control();
           
        }
        private void info_to_control()
        {
            m_lbl_ngay.Text = string.Format("{0:dd/MM/yyyy}", System_Info.current_date_time.Date);
            m_lbl_thu.Text = System_Info.get_day_of_week(System_Info.current_date_time);
            m_grp_lich.Text = string.Format("{0:hh:mm:ss tt}", System_Info.current_date_time);
        }
        //
        //EVENT HANDLERS
        //
        #endregion

        private void m_timer_Tick(object sender, EventArgs e)
        {
            update();
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fm02_grid_san m_grid_san = new fm02_grid_san();
            m_grid_san.MdiParent = this;
            m_grid_san.Show();
            m_grid_san.Text = "Lịch sân ngày " + string.Format("{0:dd/MM/yyyy}", System_Info.current_date_time.Date);
        }
    }
}
