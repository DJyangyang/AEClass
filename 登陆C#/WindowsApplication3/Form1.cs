using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication3
{
    public partial class f_main : Form
    {
        public f_main()
        {
            InitializeComponent();
        }

        private void f_main_Load(object sender, EventArgs e)
        {
            f_login f = new f_login();
            f.f1 = this;
            f.ShowDialog();
        }
    }
}