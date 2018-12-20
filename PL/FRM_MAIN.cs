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
    public partial class FRM_MAIN : Form
    {
            private static FRM_MAIN frm;
            static void frm_FromClosed(object sender, FormClosedEventArgs e)
            {
                frm = null; 
            }

                public static FRM_MAIN getMainForm
            {
                get 
                {
                    if (frm == null)
                    {
                        frm = new FRM_MAIN();
                        frm.FormClosed += new FormClosedEventHandler(frm_FromClosed);
                    }
                    return frm;
                }
            }
       public FRM_MAIN()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.المستخدمينToolStripMenuItem.Enabled = false;
            this.المدراءToolStripMenuItem.Enabled = false;
            this.المشرفينToolStripMenuItem.Enabled = false;
        }

        private void ملفToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm = new FRM_LOGIN();
            frm.ShowDialog();
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {

        }

        private void ادارةالمنتجاتToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS frm = new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void ادارةالاصنافToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_CATEGORIES frm = new FRM_CATEGORIES();
            frm.ShowDialog();
        }

        private void ادارةالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
            frm.ShowDialog();
        }

        private void اضافةبيعجديدToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void ادارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS_LIST frm = new FRM_ORDERS_LIST();
            frm.ShowDialog();
        }


        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm = new FRM_LOGIN();
            this.المستخدمينToolStripMenuItem.Enabled = false;
            this.المدراءToolStripMenuItem.Enabled = false;
            this.المشرفينToolStripMenuItem.Enabled = false;
            frm.ShowDialog();
        }

        private void الحجوزاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_WEB frm = new FRM_WEB();
            frm.ShowDialog();
        }

        private void ادارةالمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USERS_LIST frm = new FRM_USERS_LIST();
            frm.ShowDialog();
        }

        private void التقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports_Ditiles frm = new Reports_Ditiles();
            frm.ShowDialog();
        }

        private void كميةالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PRODUCT_QTE frm = new PRODUCT_QTE();
            frm.ShowDialog();
        }

        private void FRM_MAIN_Activated(object sender, EventArgs e)
        {
        
        }
    }
}
