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
        SqlConnection con = new SqlConnection("Data Source=冯云川-PC;Initial Catalog=db_ems;Integrated Security=True");
        public void open()
        {
            con.Open();
        }
        public void close()
        {
            con.Close();
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
        public People adduser1(string username, string password)
        {
            People temp = new People();
            this.open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where fullname = @username and password=@password";
            cmd.Parameters.Add(new SqlParameter("username", username));
            cmd.Parameters.Add(new SqlParameter("password", password));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                temp.Username = reader["fullname"].ToString().Trim();
                temp.Usersex = reader["sex"].ToString().Trim();
                temp.Userdept = reader["dept"].ToString().Trim();
                temp.Usertel = reader["tel"].ToString().Trim();
                temp.Password = reader["password"].ToString().Trim();
               
                temp.Memo = reader["memo"].ToString().Trim();
                return temp;
            }
            else
            {
                return null;
            }
        }
        public People readpw1(string username, string password)
        {
            People temp = new People();
            this.open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where fullname = @username and password=@password";
            cmd.Parameters.Add(new SqlParameter("username", username));
            cmd.Parameters.Add(new SqlParameter("password", password));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                temp.Username = reader["fullname"].ToString().Trim();
                temp.Usersex = reader["sex"].ToString().Trim();
                temp.Userdept = reader["dept"].ToString().Trim();
                temp.Usertel = reader["tel"].ToString().Trim();
                temp.Password = reader["password"].ToString().Trim();
                
                temp.Memo = reader["memo"].ToString().Trim();
                return temp;
            }
            else
            {
                return null;
            }


        }
        public void adduser1(People temp)
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where employeecode = @code";
            cmd.Parameters.Add(new SqlParameter("code", temp.Usercode));
            SqlDataReader tempreader = cmd.ExecuteReader();
            if (tempreader.Read())
            {
                MessageBox.Show("用户编号已存在！");

            }
            else
            {
                tempreader.Close();
                cmd.CommandText = "insert into tb_employee values(@usercode,@username,@sex,@dept,@tel,@memo,@password)";
                cmd.Parameters.Add(new SqlParameter("Usercode", temp.Usercode));
                cmd.Parameters.Add(new SqlParameter("Username", temp.Username));
                cmd.Parameters.Add(new SqlParameter("sex", temp.Usersex));
                cmd.Parameters.Add(new SqlParameter("dept", temp.Userdept));
                cmd.Parameters.Add(new SqlParameter("tel", temp.Usertel));
                cmd.Parameters.Add(new SqlParameter("memo", temp.Memo));
                cmd.Parameters.Add(new SqlParameter("password", temp.Password));
                cmd.ExecuteNonQuery();
                MessageBox.Show("注册成功！");
                this.close();

            }
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
    
        public bool adduser(People temp)
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where employeecode = @code";
            cmd.Parameters.Add(new SqlParameter("code", temp.Usercode));
            SqlDataReader tempreader = cmd.ExecuteReader();
            if (tempreader.Read())
            {
                MessageBox.Show("用户编号已存在！");
                return false;
            }
            else
            {
                tempreader.Close();
                cmd.CommandText = "insert into tb_employee values(@usercode,@username,@sex,@dept,@tel,@memo,@password)";
                cmd.Parameters.Add(new SqlParameter("Usercode", temp.Usercode));
                cmd.Parameters.Add(new SqlParameter("Username", temp.Username));
                cmd.Parameters.Add(new SqlParameter("sex", temp.Usersex));
                cmd.Parameters.Add(new SqlParameter("dept", temp.Userdept));
                cmd.Parameters.Add(new SqlParameter("tel", temp.Usertel));
                cmd.Parameters.Add(new SqlParameter("memo", temp.Memo));
                cmd.Parameters.Add(new SqlParameter("password", temp.Password));
                cmd.ExecuteNonQuery();
                MessageBox.Show("注册成功！");
                this.close();
                return true;
            }
        }
       
        public bool deluser(People temp)
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where employeecode = @code";
            cmd.Parameters.Add(new SqlParameter("code", temp.Usercode));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                cmd.CommandText = "delete from tb_employee where employeecode = @code";
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功删除用户~！");
                this.close();
                return true;
            }
            else
            {
                MessageBox.Show("不存在此用户！");
                this.close();
                return false;
            }
        }
    
     public People search(People temp) 
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from tb_employee where employeecode = @usercode";
            cmd.Parameters.Add(new SqlParameter("usercode",temp.Usercode));
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                temp.Username = reader["fullname"].ToString().Trim();
                temp.Usersex = reader["sex"].ToString().Trim();
                temp.Userdept = reader["dept"].ToString().Trim();
                temp.Usertel = reader["tel"].ToString().Trim();
                temp.Memo = reader["memo"].ToString().Trim();
                temp.Password = reader["password"].ToString().Trim();
                return temp;
            }
            else 
            {
                return null;
            }



        }
        public bool update(People temp) 
        {
            this.open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "update tb_employee set fullname=@username,sex=@sex,dept=@dept,tel=@tel,memo=@memo,password=@password where employeecode=@usercode;";
            cmd.Parameters.Add(new SqlParameter("usercode", temp.Usercode));
            cmd.Parameters.Add(new SqlParameter("username", temp.Username));
            cmd.Parameters.Add(new SqlParameter("sex", temp.Usersex));
            cmd.Parameters.Add(new SqlParameter("dept", temp.Userdept));
            cmd.Parameters.Add(new SqlParameter("tel", temp.Usertel));
            cmd.Parameters.Add(new SqlParameter("memo", temp.Memo));
            cmd.Parameters.Add(new SqlParameter("password", temp.Password));
            cmd.ExecuteNonQuery();
            this.close();
            return true;
        }

    }
    public class People
    {
        public void people() { }
        public void people(string code, string name)
        {
            usercode = code;
            username = name;
        }
        private string usercode;

        public string Usercode
        {
            get { return usercode; }
            set { usercode = value; }
        }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string usersex;

        public string Usersex
        {
            get { return usersex; }
            set { usersex = value; }
        }
        private string userdept;

        public string Userdept
        {
            get { return userdept; }
            set { userdept = value; }
        }
        private string usertel;

        public string Usertel
        {
            get { return usertel; }
            set { usertel = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
       
        private string memo;

        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

    }

    
}
