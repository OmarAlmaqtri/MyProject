using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project.PL
{
    public partial class FRM_PRODUCTS_LIST : Form
    {
        BL.CLS_PRODUCTS prd = new BL.CLS_PRODUCTS();
        public FRM_PRODUCTS_LIST()
        {
            InitializeComponent();
            this.dgvProducts.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvProducts_DoubleClick_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            BL.CLS_PRODUCTS order = new BL.CLS_PRODUCTS();
            try
            {
                this.dgvProducts.DataSource = order.SearchProduct(txtSearch.Text);
            }
            catch
            {
                return;
            }
        }

        private void dgvProducts_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
