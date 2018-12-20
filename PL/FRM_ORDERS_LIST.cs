using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Final_Project.PL
{
    public partial class FRM_ORDERS_LIST : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        public FRM_ORDERS_LIST()
        {
            InitializeComponent();
            this.dgvOrders.DataSource = order.SearchOrders("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // this.Cursor = Cursors.WaitCursor;
           // int order_ID = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
           // RPT.rpt_orders report = new RPT.rpt_orders();
           // RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
           // report.SetDataSource(order.GetOrderDetails(order_ID));
           // frm.crystalReportViewer1.ReportSource = report;
           // frm.ShowDialog();
           // this.Cursor = Cursors.Default;
            this.Cursor = Cursors.WaitCursor;
            int order_ID = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
            RPT.REP_ORDER report = new RPT.REP_ORDER();
            RPT.FRM_ORD frm = new RPT.FRM_ORD();
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgvOrders.DataSource = order.SearchOrders(txtSearch.Text);
            }
            catch
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FRM_ORDERS_LIST_Load(object sender, EventArgs e)
        {

        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
