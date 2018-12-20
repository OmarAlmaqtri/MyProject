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
    public partial class FRM_WEB : Form
    {
        BL.CLS_ORDERS prd = new BL.CLS_ORDERS();
        DataTable Dt = new DataTable();
        void ResizeDGV()
        {
            this.dgvOrdersWeb.RowHeadersWidth = 81;
            this.dgvOrdersWeb.Columns[0].Width = 200;
            this.dgvOrdersWeb.Columns[1].Width = 98;
            this.dgvOrdersWeb.Columns[2].Width = 90;
            this.dgvOrdersWeb.Columns[3].Width = 95;
            this.dgvOrdersWeb.Columns[4].Width = 95;
            this.dgvOrdersWeb.Columns[5].Width = 100;


        }
        void CreateDataTable()
        {
            Dt.Columns.Add("اسم المنتج");
            Dt.Columns.Add("رقم الفاتورة");
            Dt.Columns.Add("الثمن");
            Dt.Columns.Add("الكمية");
            Dt.Columns.Add("المبلغ");
            Dt.Columns.Add("إجمالي المبلغ");

            dgvOrdersWeb.DataSource = Dt;

        }


        public FRM_WEB()
        {
            InitializeComponent();
            this.dgvOrdersWeb.DataSource = prd.GetOrderDetailsWeb1();
            CreateDataTable();
            ResizeDGV();
            
        }
        
        private void FRM_WEB_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                RPT.WEB myReport = new RPT.WEB();
                RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT();

                myReport.SetParameterValue("@ID_ORDER", Convert.ToInt32(textBox1.Text));
                myForm.crystalReportViewer1.ReportSource = myReport;
                myForm.ShowDialog();
                this.Cursor = Cursors.Default;
                prd.DeleteProductWeb(Convert.ToInt32(textBox1.Text));
                this.dgvOrdersWeb.DataSource = prd.GetOrderDetailsWeb1();
            }
            catch {
                MessageBox.Show("قم بتحديد الفاتورة ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
            }
            
        }

        private void dgvOrdersWeb_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dgvOrdersWeb.CurrentRow.Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        
            this.dgvOrdersWeb.DataSource = prd.GetOrderDetailsWeb1();
        }
    }
}
