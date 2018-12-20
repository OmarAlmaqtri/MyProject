using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;


namespace Final_Project.PL
{
    public partial class FRM_CATEGORIES : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"server=.\s2008;Initial Catalog=Product_DB;Integrated Security=true;");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;
        public int x;
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select id_cat as'رقم الصنف', DESCRIPTION_CAT as'الصنف' from categories", sqlcon);
            da.Fill(dt);
            dgList.DataSource = dt;
            txtID.DataBindings.Add("text", dt, "رقم الصنف");
            txtDes.DataBindings.Add("text", dt, "الصنف");
            bmb = this.BindingContext[dt];
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            txtDes.ReadOnly = false;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            txtID.Text = id.ToString();
            txtDes.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            bmb.Position += 1;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("تمت الإضافة بنجاح", "إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            txtDes.ReadOnly = true;
            lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {



            if (MessageBox.Show("هل تريد فعلاً حذف القسم المحدد؟", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                MessageBox.Show("تم الحذف بنجاح", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmdb = new SqlCommandBuilder(da);
                da.Update(dt);
                bmb.RemoveAt(bmb.Position);
                bmb.EndCurrentEdit();
                lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
            }
            else
            {
                MessageBox.Show("تم إلغاء عملية الحذف", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDes.ReadOnly == true)
            {
                txtDes.ReadOnly = false;
                btnEdit.Text = "حفظ التعديل";
            }
            else
            {
                bmb.EndCurrentEdit();
                cmdb = new SqlCommandBuilder(da);
                da.Update(dt);
                MessageBox.Show("تم التعديل بنجاح", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblPosition.Text = (bmb.Position + 1) + " / " + bmb.Count;
                txtDes.ReadOnly = true;
                btnEdit.Text = "تعديل";
            }
        }

        private void btnPrintCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
              
                RPT.rpt_single_category rpt = new RPT.rpt_single_category();
             
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.SetParameterValue("@id", Convert.ToInt32(txtID.Text));
               
                frm.crystalReportViewer1.ReportSource = rpt;
           
                frm.ShowDialog(); 
                this.Cursor = Cursors.Default;
            }
            catch {
                MessageBox.Show("الرجاء تحديد القسم", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }


        private void btnPrinAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
               
                RPT.rpt_all_categories rpt = new RPT.rpt_all_categories();
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
                rpt.Refresh();
                frm.crystalReportViewer1.ReportSource = rpt;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            catch {
                MessageBox.Show("الرجاء تحديث المعلومات", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblPosition_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FRM_CATEGORIES_Load(object sender, EventArgs e)
        {

        }
    }
}
