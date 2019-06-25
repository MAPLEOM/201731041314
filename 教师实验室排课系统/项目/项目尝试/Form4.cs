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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
            SqlDataAdapter sq = new SqlDataAdapter("select * from 教师信息表", con1);
            DataSet ds = new DataSet();
            sq.Fill(ds, "教师信息表");
            this.dataGridView1.DataSource = ds.Tables["教师信息表"];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
            SqlDataAdapter sq = new SqlDataAdapter("select * from 管理员信息表", con1);
            DataSet ds = new DataSet();
            sq.Fill(ds, "管理员信息表");
            this.dataGridView1.DataSource = ds.Tables["管理员信息表"];
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
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

        private void Form4_Load(object sender, EventArgs e)
        {
            int w = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int h = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            this.Location = new Point(w / 2 - 250, h / 2 - 180);
        }
    }
}
