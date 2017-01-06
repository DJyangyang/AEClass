using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EMS
{
    class datainfo
    {
        SqlConnection con = new SqlConnection("Data Source=冯云川-PC;Initial Catalog=master;Integrated Security=True");
      
        public void open()
        {
            con.Open();
        }
        public DataTable read()
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            con.Close();
            return dt;

        }
        public bool load_enter(string name, string password)
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where fullname=@name and password=@password";
            cmd.Parameters.Add(new SqlParameter("name", name));
            cmd.Parameters.Add(new SqlParameter("password", password));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                //MessageBox.Show("登陆成功！");
                con.Close();
                return true;
            }
            else
            {
                //MessageBox.Show("用户名或密码错误！");
                con.Close();
                return false;
            }
        }
    }
}
