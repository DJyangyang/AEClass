using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        datainfo da = new datainfo();
        private void button1_Click(object sender, EventArgs e)
        {
            if (da.load_enter(this.textBox1.Text, this.textBox2.Text))
            {
                string username = this.textBox1.Text;
                string password = this.textBox2.Text;
                datainfo  dp = new datainfo ();
                People user1 = new People();
                user1 = dp.readpw1(username, password);
                Form2 f2 = new Form2(user1);
                f2.Show();
                
            }
            else
            {
                MessageBox.Show("用户名或者密码错误，请重新输入！");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public frm_register frmregister = new frm_register();
        private void btn_register_Click(object sender, EventArgs e)
        {
            frmregister.ShowDialog();
        }
    }
}
