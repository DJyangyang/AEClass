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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        People tempuser = new People();
        private void button1_Click(object sender, EventArgs e)
        {
            People updateuser = new People();
            updateuser.Usercode = this.textBox1.Text;
            datainfo  updateop = new datainfo ();
            if (updateop.search(updateuser) != null)
            {
                textBox2.Text = updateuser.Username;
                comboBox1.SelectedItem = updateuser.Usersex;
                comboBox2.Text = updateuser.Userdept;
                textBox5.Text = updateuser.Usertel;
                textBox6.Text = updateuser.Memo;
                textBox7.Text = updateuser.Password;
                tempuser = updateuser;
            }
            else
            {
                MessageBox.Show("不存在这个用户，请输入其他编号继续操作！");
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                this.Refresh();
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             People updateuser = new People();
            if (textBox1.Text != "" && comboBox1.SelectedItem != null)
            {
                updateuser.Usercode = this.textBox1.Text;
                updateuser.Username = this.textBox2.Text;
                updateuser.Usersex = this.comboBox1.SelectedItem.ToString();
                updateuser.Userdept = this.comboBox2.Text;
                updateuser.Usertel = this.textBox5.Text;
                updateuser.Password = this.textBox7.Text;
                updateuser.Memo = this.textBox6.Text;
                if (updateuser == tempuser)
                {
                    MessageBox.Show("用户数据没有修改，无需保存！");
                }
                else 
                {
                    datainfo  updateop = new datainfo ();
                    if(updateop.update(updateuser))
                    {
                        MessageBox.Show("修改成功");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("请先查询用户数据，再来修改~！");
                textBox1.Focus();

            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“db_emsDataSet.tb_employee”中。您可以根据需要移动或移除它。
            this.tb_employeeTableAdapter.Fill(this.db_emsDataSet.tb_employee);

        }
    }
}
