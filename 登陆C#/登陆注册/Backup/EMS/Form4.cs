using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EMS
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            People reguser = new People();
            reguser.Usercode = this.textBox1.Text;
            reguser.Username = this.textBox2.Text;
            reguser.Usersex = this.comboBox1.Text;
            reguser.Userdept = this.comboBox2.Text;
            reguser.Usertel = this.textBox5.Text;
            reguser.Memo = this.textBox6.Text;
            reguser.Password = this.textBox7.Text;
            datainfo data = new datainfo();
            if (data.adduser(reguser))
            {
                this.Close();
            }


        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

    }
}
