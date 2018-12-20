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

namespace Final_Project.PL
{
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        int ID, Position;
     
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
            dgList.Columns[0].Visible = false;
            dgList.Columns[5].Visible = false;
        }

        private void FRM_CUSTOMERS_Load(object sender, EventArgs e)
        {

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Navigate(0);
        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "ملفات الصور |*.JPG;*.PNG;*.GIF;*.BMP;";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] Picture;
                if (pbox.Image == null)
                {
                    Picture = new byte[0];
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "without_image", CustName.Text, CustPass.Text);
                    MessageBox.Show("تمت الإضافة بنجاح", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
                    CustName.ReadOnly = true;
                    CustPass.ReadOnly = true;
                    txtTel.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    CustName.Clear();
                    CustPass.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtTel.Clear();
                    txtEmail.Clear();
            
                }

                else
                {
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    Picture = ms.ToArray();
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image", CustName.Text , CustPass.Text);
                    MessageBox.Show("تمت الإضافة بنجاح", "الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
                    CustName.ReadOnly = true;
                    CustPass.ReadOnly = true;
                    txtTel.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    CustName.Clear();
                    CustPass.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtTel.Clear();
                    txtEmail.Clear();
            
                }
            }
            catch
            {
                return;
            }
            finally
            {
                btnAdd.Enabled = false;
                btnNew.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CustName.Clear();
            CustPass.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            
            CustName.Focus();
            btnAdd.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            button1.Enabled = false;
            txtFirstName.ReadOnly=false;
            txtLastName.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtEmail.ReadOnly = false;
            CustName.ReadOnly = false;
            CustPass.ReadOnly = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("يرجئ تحديد العميل");
                return;
            }
            if (MessageBox.Show("هل تريد حذف هذا العميل؟", "الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DELETE_CUSTOMER(ID);
                MessageBox.Show("تم الحذف بنجاح", "الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustName.Clear();
                CustPass.Clear();
                txtTel.Clear();
                txtEmail.Clear();
                pbox.Image = null;
                txtFirstName.Clear();
                txtLastName.Clear();
                this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

          
                if (ID == 0)
                {
                    MessageBox.Show("يرجئ تحديد العميل");
                    return;
                }


                byte[] Picture;
                
                if (pbox.Image == null)
                {
                   
                    Picture = new byte[0];
                    cust.EDIT_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "with_image", ID, CustName.Text, CustPass.Text);
                    MessageBox.Show("تم التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                    this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
                    btnEdit.Text = "تعديل";
                    CustName.ReadOnly = true;
                    CustPass.ReadOnly = true;
                    txtTel.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    btnEdit.Enabled = false;
                    button1.Enabled = true;
                    CustName.Clear();
                    CustPass.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtTel.Clear();
                    txtEmail.Clear();
            
                }
                else
                {
                   
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    Picture = ms.ToArray();
                    cust.EDIT_CUSTOMER(CustName.Text, CustPass.Text, txtTel.Text, txtEmail.Text, Picture, "with_image", ID, CustName.Text, CustPass.Text);
                    this.dgList.DataSource = cust.GET_ALL_CUSTOMERS();
                    CustName.ReadOnly = true;
                    CustPass.ReadOnly = true;
                    txtTel.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    MessageBox.Show("تم التعديل بنجاح", "التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEdit.Text = "تعديل";
                    CustName.ReadOnly = true;
                    CustPass.ReadOnly = true;
                    txtTel.ReadOnly = true;
                    txtEmail.ReadOnly = true;
                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    btnEdit.Enabled = false;
                    button1.Enabled = true;
                    btnAdd.Enabled = true;
                    btnNew.Enabled = true;
                    btnDelete.Enabled = true;
                    CustName.Clear();
                    CustPass.Clear();
                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtTel.Clear();
                    txtEmail.Clear();
                    
                    
                } 
            
            
        }
            catch
            {
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (Position == 0)
            {
                MessageBox.Show("هذا هو أول عنصر");
                return;
            }
            Position -= 1;
            Navigate(Position);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (Position == cust.GET_ALL_CUSTOMERS().Rows.Count - 1)
            {
                MessageBox.Show("هذا هو أخر عنصر");
                return;
            }
            Position += 1;
            Navigate(Position);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Position = cust.GET_ALL_CUSTOMERS().Rows.Count - 1;
            Navigate(Position);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgList.DataSource = cust.Search_CUSTOMER(txtSearch.Text);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CustPass.Focus();
            }
        }

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdd.Focus();
            }
        }

        void Navigate(int Index)
        {
            try
            {
                pbox.Image = null;
                DataRowCollection DRC = cust.GET_ALL_CUSTOMERS().Rows;
                ID = Convert.ToInt32(DRC[Index][0]);
                txtFirstName.Text = DRC[Index][1].ToString();
                txtLastName.Text = DRC[Index][2].ToString();
                txtTel.Text = DRC[Index][3].ToString();
                txtEmail.Text = DRC[Index][4].ToString();
                byte[] Picture = (byte[])DRC[Index][5];
                CustName.Text = DRC[Index][6].ToString();
                CustPass.Text = DRC[Index][7].ToString();
                MemoryStream ms = new MemoryStream(Picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }


        }

        private void dgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                pbox.Image = null;
                ID = Convert.ToInt32 ( dgList.CurrentRow.Cells[0].Value );
                this.txtFirstName.Text = dgList.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = dgList.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = dgList.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = dgList.CurrentRow.Cells[4].Value.ToString();
                this.CustName.Text = dgList.CurrentRow.Cells[6].Value.ToString();
                this.CustPass.Text = dgList.CurrentRow.Cells[7].Value.ToString();
                byte[] picture = (byte[])dgList.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            
            }
            catch
            { 
                return;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                txtTel.ReadOnly = false;
                txtEmail.ReadOnly = false;
                CustName.ReadOnly = false;
                CustPass.ReadOnly = false;
                btnEdit.Enabled = true;
                button1.Enabled = false;
                btnAdd.Enabled = false;
                btnNew.Enabled = false;
                btnDelete.Enabled = false;
        }
    }
}
