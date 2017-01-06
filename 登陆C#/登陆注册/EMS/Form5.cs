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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            People deluser = new People();
            deluser.Usercode = this.textBox1.Text;

            datainfo datadel = new datainfo();
            if (datadel.deluser(deluser))
            {
                this.Close();
            }
            else
            {
                this.textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
