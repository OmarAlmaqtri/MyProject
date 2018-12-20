using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Final_Project.DAL
{
    class DataAccessLayer
    {
        SqlConnection SqlConnection;
        // هذا لتفعيل الاتصال عند تشغيل المشروع
        public DataAccessLayer()
        {
            SqlConnection = new SqlConnection(@"server=.\SQLEXPRESS;Initial Catalog=Product_DB;Integrated Security=true;");
        }

        // هذا الاجراء لفتح الاتصال بقاعدة البيانات
        public void Open()
        {
            if (SqlConnection.State != ConnectionState.Open)
            {
                SqlConnection.Open();
            }
        }

        // هذا الاجراء لاغلاق الاتصال بقاعدة البيانات

        public void Close()
        {
            if (SqlConnection.State == ConnectionState.Open)
            {
                SqlConnection.Close();
            }
        }

        // داله ارسال واستقبال البيانات من قاعدة البيانات
        public DataTable SelectData(string storesd_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = storesd_procedure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                for (int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // هذا الاجراء ادخال وتعديل او حذف البيانات الى قاعدة البيانات
        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = SqlConnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);
            }
            sqlcmd.ExecuteNonQuery();
        }
    }
}
