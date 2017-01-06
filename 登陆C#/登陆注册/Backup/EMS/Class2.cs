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
    class Class2
    {
        SqlConnection con = new SqlConnection("Data Source=冯云川-PC;Initial Catalog=db_ems;Integrated Security=True");
        public void open()
        {
            con.Open();
        }
        public void close()
        {
            con.Close();
        }
       
        public bool warehouse(jinhuo temp)
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_warehouse_main where warehouse_main = @code";
            cmd.Parameters.Add(new SqlParameter("code", temp.Billcode));
            SqlDataReader jinreader = cmd.ExecuteReader();
            if (jinreader.Read())
            {
                MessageBox.Show("进货编号已存在！");
                return false;
            }
            else
            {
                jinreader.Close();
                cmd.CommandText = "insert into tb_warehouse_main values(@Billdate,@Billcode,@Units,@Handle,@Summary,@Fullpayment,@Payment)";
                cmd.Parameters.Add(new SqlParameter("Billdate", temp.Billdate));
                cmd.Parameters.Add(new SqlParameter("Billcode", temp.Billcode));
                cmd.Parameters.Add(new SqlParameter("Units", temp.Units));
                cmd.Parameters.Add(new SqlParameter("Handle", temp.Handle));
                cmd.Parameters.Add(new SqlParameter("Summary", temp.Summary));
                cmd.Parameters.Add(new SqlParameter("Fullpayment", temp.Fullpayment));
                cmd.Parameters.Add(new SqlParameter("Payment", temp.Payment));
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加商品成功！");
                this.close();
                return true;
            }
        }
    }
        class jinhuo
        {
            private string billdate;

            public string Billdate
            {
                get { return billdate; }
                set { billdate = value; }
            }

           public string billcode;

            public string Billcode
            {
                get { return billcode; }
                set { billcode = value; }
            }
            public string units;

            public string Units
            {
                get { return units; }
                set { units = value; }
            }
            string handle;

            public string Handle
            {
                get { return handle; }
                set { handle = value; }
            }
           public string summary;

            public string Summary
            {
                get { return summary; }
                set { summary = value; }
            }
            private string fullpayment;

            public string Fullpayment
            {
                get { return fullpayment; }
                set { fullpayment = value; }
            }

            private string payment;

            public string Payment
            {
                get { return payment; }
                set { payment = value; }
            }

           
        }
    
}
