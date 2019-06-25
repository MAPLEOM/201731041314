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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
            con1.Open();
            SqlCommand co = con1.CreateCommand();
            co.CommandText= "select * from 排课清单 where 学工号='"+this.label8.Text+"' and 排课教学楼='"+this.comboBox2.Text+"'and 排课教室='" + this.textBox2.Text + "'and 周次='" + this.comboBox1.Text + "'and 星期='" + this.comboBox3.Text + "'and 节次='" + this.comboBox4.Text + "'";
            SqlDataReader hyw = co.ExecuteReader();          
            if (!hyw.Read())
            {
               hyw.Close();
               DialogResult result = MessageBox.Show("排课信息正确吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (result == DialogResult.Yes)
               {
                    SqlConnection con2 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
                    con2.Open();
                    SqlCommand CMD = con2.CreateCommand();
                    CMD.CommandText = "select * from 教室基本信息表 where 教室所在楼='" + this.comboBox2.Text + "'and 教室详细位置='" + this.textBox2.Text + "'and 周次='" + this.comboBox1.Text + "'and 星期='" + this.comboBox3.Text + "'and 节次='" + this.comboBox4.Text + "'";
                    SqlDataReader hyw1 = CMD.ExecuteReader();                   
                    if (!hyw1.Read())
                    {
                        MessageBox.Show("该信息暂不可排课!");     
                    }
                    else
                    {
                        string str1 = "insert into 排课清单(学工号,排课教学楼,排课教室,周次,星期,节次)" + "values('" + label8.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "')";
                        SqlCommand cmd = new SqlCommand(str1, con1);
                        int i = Convert.ToInt32(cmd.ExecuteNonQuery());
                        MessageBox.Show("排课成功!");
                    }
                    con2.Close();
               }
               else
               {
                   MessageBox.Show("已取消排课操作!");
               }
            }
            else
            {
               MessageBox.Show("该教室本时段已排课!");
            }
            con1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            SqlConnection con1 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");         
            SqlDataAdapter sq = new SqlDataAdapter("select * from 排课清单 where 学工号='"+label8.Text+"'",con1);
            DataSet ds = new DataSet();
            sq.Fill(ds, "排课清单");
            f9.dataGridView1.DataSource = ds.Tables["排课清单"];
            con1.Close();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            label8.Text = Form1.Tenmxgh.tempxgh;
            this.Location = new System.Drawing.Point(100, 100);
            Form2.O.isOpenorClose_8 = 1;
            
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要退出？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form8_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2.O.isOpenorClose_8 = 0;
        }
    }
}
