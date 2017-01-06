using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication3
{
    public partial class f_login : Form
    {
        public Boolean l=false;
        public f_main f1;  //窗体对象
        public f_login()
        {
            InitializeComponent();
        }

        private void f_login_Load(object sender, EventArgs e)
        {
            txtuserpwd.Focus();
        }

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                txtuserpwd.Focus();
            }
        }
        private Boolean login(string username,string userpwd)　　//登陆方法
        {
            if (username == "qq" && userpwd == "1")
            {
                l = true;  //验证用户
                f1.textBox1.Text = username;　　//将用户名返回给from1窗体中的textBoxt1
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtuserpwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (txtusername.Text != "" && txtuserpwd.Text != "")
                {
                    if (login(txtusername.Text, txtuserpwd.Text))
                    {
                        this.Close();　　//关闭登陆窗体
                    }
                    else
                    {
                        MessageBox.Show("登陆信息错误，请重新输入！");
                    }
                }
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text != "" && txtuserpwd.Text != "")
            {
                if (login(txtusername.Text, txtuserpwd.Text))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("登陆信息错误，请重新输入！");
                }
            }
        }

        private void f_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!l)
            {
                //Application.Exit();
                f1.Close();
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }
    }
}