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
    public partial class PRODUCT_QTE : Form
    {
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
       
        public PRODUCT_QTE()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.dgvProd.DataSource = prd.GET_ALL_PRODUCTS_LESSTHAN();
           
        }

        private void PRODUCT_QTE_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RPT.prtProdLess myReport = new RPT.prtProdLess();
            RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT();
            myForm.crystalReportViewer1.ReportSource = myReport;
            myForm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        
    }
}
