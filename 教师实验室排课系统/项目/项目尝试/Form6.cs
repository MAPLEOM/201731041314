using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 项目尝试
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
            con1.Open();   
            SqlDataAdapter sq = new SqlDataAdapter("select * from 教师登录信息表 where 学工号='"+textBox1.Text+"'", con1);
            DataSet ds = new DataSet();
            int temp=sq.Fill(ds, "教师登录信息表");
            if (temp == 0)
            {
                MessageBox.Show("学工号不存在！");
            }
            else
            {               
                string str = "update 教师登录信息表 set 密码='" + textBox3.Text + "'where 学工号='" + textBox1.Text + "'";
                SqlCommand com = new SqlCommand(str, con1);
                com.ExecuteNonQuery();
                DialogResult result = MessageBox.Show("确认要修改该数据吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("修改成功!");
                    Form3 f3 = new Form3();
                    f3.Show();
                }
                else
                {
                    MessageBox.Show("已取消该修改操作!");
                }
            }
        }
        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要返回主界面吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            int w = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int h = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            this.Location = new Point(w / 2 - 250, h / 2 - 180);
        }
    }
}
