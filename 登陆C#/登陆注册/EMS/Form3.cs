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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            jinhuo reguser =new jinhuo();
            reguser.Billdate = this.textBox1.Text;
            reguser.Billcode = this.textBox2.Text;
            reguser.Units = this.textBox3.Text;
            reguser.Handle = this.textBox4.Text;
            reguser.Summary = this.textBox5.Text;
            reguser.Fullpayment = this.textBox6.Text;
            reguser.Payment = this.textBox7.Text;
            Class2 data = new Class2();
            if (data.warehouse(reguser))
            {
                this.Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
