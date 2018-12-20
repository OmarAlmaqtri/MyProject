using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Final_Project.PL
{
    public partial class FRM_ORDERS : Form
    {
        DateTime date = DateTime.Now;
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        DataTable Dt = new DataTable();
        void CalculateAmount()
        {
            if (txtPrice.Text != string.Empty && txtQty.Text != string.Empty)
                txtAmount.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQty.Text)).ToString();
        }
        void CalculateTotalAmount()
        {
            if (txtDiscount.Text != string.Empty && txtAmount.Text != string.Empty)
            {
                double Discount = Convert.ToDouble(txtDiscount.Text);
                double Amount = Convert.ToDouble(txtAmount.Text);
                double TotalAmount = Amount - (Amount * (Discount / 100));
                txtTotalAmount.Text = TotalAmount.ToString();
            }
        }


        void ClearBoxes()
        {
            txtIDProduct.Clear();
            txtNameProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtAmount.Clear();
            txtDiscount.Clear();
            txtTotalAmount.Clear();
            btnBrowse.Focus();
        }

        void ClearData()
        {
            txtOrderID.Clear();
            txtDesOrder.Clear();
            
           // dtOrder.ResetText();
            txtCustomerID.Clear();
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            ClearBoxes();
            Dt.Clear();
            dgvProducts.DataSource = null;
            txtSumTotals.Clear();
            pbox.Image = null;
         
            btnNew.Enabled = true;
            btnPrint.Enabled = true;


        }

        void CreateDataTable()
        {
            Dt.Columns.Add("معرف المنتج");
            Dt.Columns.Add("إسم المنتج");
            Dt.Columns.Add("الثمن");
            Dt.Columns.Add("الكمية");
            Dt.Columns.Add("المبلغ");
            Dt.Columns.Add("نسبة الخصم (%)");
            Dt.Columns.Add("إجمالي المبلغ");

            dgvProducts.DataSource = Dt;

        }

        void ResizeDGV()
        {
            this.dgvProducts.RowHeadersWidth = 81;
            this.dgvProducts.Columns[0].Width = 98;
            this.dgvProducts.Columns[1].Width = 200;
            this.dgvProducts.Columns[2].Width = 85;
            this.dgvProducts.Columns[3].Width = 95;
            this.dgvProducts.Columns[4].Width = 95;
            this.dgvProducts.Columns[5].Width = 100;
            this.dgvProducts.Columns[6].Width = 111;

        }


        public FRM_ORDERS()
        {
            InitializeComponent();
            timer1.Start();
            CreateDataTable();
            ResizeDGV();
            txtSalesMan.Text = Program.SalesMan;
            
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            label19.Text = txtOrderID.Text;
            btnNew.Enabled = false;
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();
            frm.ShowDialog();
            if (frm.dgvCustomers.CurrentRow.Cells[5].Value is DBNull)
            {
                MessageBox.Show("هذا العميل لا يتوفر له صورة");
                this.txtCustomerID.Text = frm.dgvCustomers.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgvCustomers.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgvCustomers.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgvCustomers.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgvCustomers.CurrentRow.Cells[4].Value.ToString();
                pbox.Image = null;
                return;
            }
            this.txtCustomerID.Text = frm.dgvCustomers.CurrentRow.Cells[0].Value.ToString();
            this.txtFirstName.Text = frm.dgvCustomers.CurrentRow.Cells[1].Value.ToString();
            this.txtLastName.Text = frm.dgvCustomers.CurrentRow.Cells[2].Value.ToString();
            this.txtTel.Text = frm.dgvCustomers.CurrentRow.Cells[3].Value.ToString();
            this.txtEmail.Text = frm.dgvCustomers.CurrentRow.Cells[4].Value.ToString();
            byte[] custPicture = (byte[])frm.dgvCustomers.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(custPicture);
            pbox.Image = Image.FromStream(ms);
        }

        private void FRM_ORDERS_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtIDProduct.Text = frm.dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtNameProduct.Text = frm.dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = frm.dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtQty.Focus();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeprator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeprator)
            {
                e.Handled = true;
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtQty.Text != string.Empty)
            {
                txtDiscount.Focus();
            }
        }
        public int i=0;
        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {

            CalculateAmount();
            CalculateTotalAmount();
            txtDiscount.Text = i.ToString();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (order.VerifyQty(txtIDProduct.Text, Convert.ToInt32(txtQty.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("الكمية المدخلة لهذا المنتج غير متاحة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                for (int i = 0; i < dgvProducts.Rows.Count - 1; i++)
                {
                    if (dgvProducts.Rows[i].Cells[0].Value.ToString() == txtIDProduct.Text)
                    {
                        MessageBox.Show("هذا المنتج تم إدخاله مسبقاً", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                DataRow r = Dt.NewRow();
                r[0] = txtIDProduct.Text;
                r[1] = txtNameProduct.Text;
                r[2] = txtPrice.Text;
                r[3] = txtQty.Text;
                r[4] = txtAmount.Text;
                r[5] = txtDiscount.Text;
                r[6] = txtTotalAmount.Text;

                Dt.Rows.Add(r);

                dgvProducts.DataSource = Dt;
                ClearBoxes();

                txtSumTotals.Text =
                    (from DataGridViewRow row in dgvProducts.Rows
                     where row.Cells[6].FormattedValue.ToString() != string.Empty
                     select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
            }
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIDProduct.Text = this.dgvProducts.CurrentRow.Cells[0].Value.ToString();
                txtNameProduct.Text = this.dgvProducts.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = this.dgvProducts.CurrentRow.Cells[2].Value.ToString();
                txtQty.Text = this.dgvProducts.CurrentRow.Cells[3].Value.ToString();
                txtAmount.Text = this.dgvProducts.CurrentRow.Cells[4].Value.ToString();
                txtDiscount.Text = this.dgvProducts.CurrentRow.Cells[5].Value.ToString();
                txtTotalAmount.Text = this.dgvProducts.CurrentRow.Cells[6].Value.ToString();
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
                txtQty.Focus();
            }
            catch
            {
                return;
            }
        }

        private void dgvProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

            txtSumTotals.Text =
                (from DataGridViewRow row in dgvProducts.Rows
                 where row.Cells[6].FormattedValue.ToString() != string.Empty
                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString(); 
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts_DoubleClick(sender, e);
            }
            catch
            {
                MessageBox.Show("الرجاء تحديد المنتج المراد تعديل بياناتة", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void حذفالسطرالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProducts.Rows.RemoveAt(dgvProducts.CurrentRow.Index);
            }
            catch
            {
                MessageBox.Show("الرجاء تحديد المنتج المراد حذفه", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            try
            {
                Dt.Clear();
                dgvProducts.Refresh();
            }
            catch
            {
                MessageBox.Show("لايوجد منتجات لحذفها", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ///Check Value

            if (txtOrderID.Text == string.Empty || txtCustomerID.Text == string.Empty || dgvProducts.Rows.Count < 1 || txtDesOrder.Text == string.Empty)
            {
                MessageBox.Show("ينبغي تسجيل المعلومات المهمه", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ///إضافة معلومات الفاتورة
            order.ADD_ORDER(Convert.ToInt32(txtOrderID.Text), dtOrder.Value, Convert.ToInt32(txtCustomerID.Text), txtDesOrder.Text, txtSalesMan.Text);

            ///إضافة المنتجات المدخلة
            for (int i = 0; i < dgvProducts.Rows.Count - 1; i++)
            {
                order.ADD_ORDER_DETAILS(dgvProducts.Rows[i].Cells[0].Value.ToString(),
                   Convert.ToInt32(txtOrderID.Text),
                   Convert.ToInt32(dgvProducts.Rows[i].Cells[3].Value),
                   dgvProducts.Rows[i].Cells[2].Value.ToString(),
                   Convert.ToInt32(dgvProducts.Rows[i].Cells[5].Value),
                   dgvProducts.Rows[i].Cells[4].Value.ToString(),
                   dgvProducts.Rows[i].Cells[6].Value.ToString());

            }
            MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            if (txtOrderID.Text == string.Empty || txtCustomerID.Text == string.Empty || dgvProducts.Rows.Count < 1 || txtDesOrder.Text == string.Empty)
            {
                MessageBox.Show("ينبغي تسجيل المعلومات المهمه", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ///إضافة معلومات الفاتورة
            order.ADD_ORDER(Convert.ToInt32(txtOrderID.Text), dtOrder.Value, Convert.ToInt32(txtCustomerID.Text), txtDesOrder.Text, txtSalesMan.Text);

            ///إضافة المنتجات المدخلة
            for (int i = 0; i < dgvProducts.Rows.Count - 1; i++)
            {
                order.ADD_ORDER_DETAILS(dgvProducts.Rows[i].Cells[0].Value.ToString(),
                   Convert.ToInt32(txtOrderID.Text),
                   Convert.ToInt32(dgvProducts.Rows[i].Cells[3].Value),
                   dgvProducts.Rows[i].Cells[2].Value.ToString(),
                   Convert.ToInt32(dgvProducts.Rows[i].Cells[5].Value),
                   dgvProducts.Rows[i].Cells[4].Value.ToString(),
                   dgvProducts.Rows[i].Cells[6].Value.ToString());

            }
           // MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearData();
            this.Cursor = Cursors.WaitCursor;
            RPT.REP_ORDER report = new RPT.REP_ORDER();
            RPT.FRM_ORD frm = new RPT.FRM_ORD();
            report.SetParameterValue("@ID_ORDER", Convert.ToInt32(label19.Text));
            frm.crystalReportViewer1.ReportSource = report;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtSalesMan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
