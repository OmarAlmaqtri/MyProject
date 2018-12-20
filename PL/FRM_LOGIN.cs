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
    public partial class FRM_LOGIN : Form
    {
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public static string User_name;
        public FRM_LOGIN()
        {
            InitializeComponent();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            FRM_MAIN.getMainForm.تسجيلالدخولToolStripMenuItem.Enabled = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtID.Text, txtPwD.Text);
            if (Dt.Rows.Count > 0)
            {
                User_name = txtID.Text;
                if (Dt.Rows[0][2].ToString() == "مدير")
                {

                    FRM_MAIN.getMainForm.المدراءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المستخدمينToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.المشرفينToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.تسجيلالدخولToolStripMenuItem.Enabled = false;
                    Program.SalesMan = Dt.Rows[0]["FULLNAME"].ToString();
                    this.Close();
                }
                else if (Dt.Rows[0][2].ToString() == "عادي")
                {
                    FRM_MAIN.getMainForm.المستخدمينToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.تسجيلالدخولToolStripMenuItem.Enabled = false;
                    Program.SalesMan = Dt.Rows[0]["FULLNAME"].ToString();
                    this.Close();
                }
                else if (Dt.Rows[0][2].ToString() == "مشرف")
                {
                    FRM_MAIN.getMainForm.المشرفينToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.تسجيلالدخولToolStripMenuItem.Enabled = false;
                    this.Close();
                }
            }
 
            else
            {
                MessageBox.Show("هناك خطأ في البيانات المدخلة");
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        private void txtPwD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPwD.Text != string.Empty)
            {
                btnLogin.Focus();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
