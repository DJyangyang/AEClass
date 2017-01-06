using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.ObjectModel;

namespace EMS
{
    public partial class Form2 : Form
    {
        People user = new People();
        Collection<People> peos = new Collection<People>();
        Collection<People> peos1 = new Collection<People>();
        BindingSource datasourceLine = new BindingSource();
        datainfo  data = new datainfo ();
        private System.Windows.Forms.StatusBarPanel statusBarPanel3;
        public Form2 (People user2)
        {
            InitializeComponent();
            
            datasourceLine.DataSource = peos;
            //this.dataGridView1.DataSource = data.read();
            this.dataGridView1.DataSource =datasourceLine;
           // this.仓库管理ToolStripMenuItem.Visible = false;
            this.仓库管理ToolStripMenuItem.Enabled = false;
            user = user2;
            toolStripStatusLabel2.Text = user.Username;
            //toolStripStatusLabel3.Text = timer1;
            if (user.Userdept == "采购部")
            {
                this.销售管理ToolStripMenuItem.Enabled = false;
                this.系统管理ToolStripMenuItem.Enabled = false;
                this.仓库管理ToolStripMenuItem.Enabled = true;
                this.进货管理ToolStripMenuItem.Enabled = true;
                this.管理员ToolStripMenuItem.Enabled = false;
            }
            else if (user.Userdept == "销售部")
            {
                this.销售管理ToolStripMenuItem.Enabled = true;
                this.系统管理ToolStripMenuItem.Enabled = false;
                this.仓库管理ToolStripMenuItem.Enabled = false;
                this.进货管理ToolStripMenuItem.Enabled = false;
                this.管理员ToolStripMenuItem.Enabled = false;
 
            }
            else if (user.Userdept=="管理员")
            {
                this.销售管理ToolStripMenuItem.Enabled = false;
                this.系统管理ToolStripMenuItem.Enabled = false;
                this.仓库管理ToolStripMenuItem.Enabled = false;
                this.进货管理ToolStripMenuItem.Enabled = false;
                this.管理员ToolStripMenuItem.Enabled = true;
            }

        }

        public Form2()
        {
           InitializeComponent();
            datainfo da = new datainfo();
            this.dataGridView1.DataSource = data.read();
            // this.仓库管理ToolStripMenuItem.Visible = false;
            this.仓库管理ToolStripMenuItem.Enabled = false;

        }

        private void 进货管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Data_frm_Activated(object sender, EventArgs e)
        {
            //Dataop data = new Dataop();
            //this.dataGridView1.DataSource = data.read();
            //this.Refresh();
        }

        private void 进货单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_register f4 = new frm_register();
            f4.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

       private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < peos.Count; i++)
            {
                data.adduser1(peos[i]);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             int index = this.dataGridView1.CurrentCell.RowIndex;
             if (index > 0 || index < dataGridView1.RowCount)
             {
                 if ((MessageBox.Show("你确定删除当前记录吗?", "警告！", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)) == DialogResult.Yes)
                 {
                     try
                     {
                         string id = Convert.ToString(this.dataGridView1.Rows[index].Cells[0].Value);
                         //mydatasource.RemoveAt(index);
                         //myuser.delete(id);
                         user.Usercode = id;
                         data.deluser(user);
                         this.dataGridView1.DataSource = data.read();
                         MessageBox.Show("数据删除成功！");

                     }
                     catch
                     {
                         MessageBox.Show("数据删除失败！");
                     }
                 }
             }
             else
                 MessageBox.Show("当前没有可删除数据！");
        }

 
        private void button3_Click(object sender, EventArgs e)
        {
            datainfo data = new datainfo();
            this.dataGridView1.DataSource = data.read();
        }

        private void 管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
