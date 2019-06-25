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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace 项目尝试
{    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int w = System.Windows.Forms.SystemInformation.WorkingArea.Width;
        public int h = System.Windows.Forms.SystemInformation.WorkingArea.Height;
        public static class Tenmxgh
        {
            public static string tempxgh;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {   
            if (comboBox1.Text == "教师")
            {
                SqlConnection con = new SqlConnection(@"data source = 132.232.156.108; " +
                            "initial catalog=项目尝试;persist security info=true;" +
                            "user id=sa;password=qq1234@");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select 学工号,密码 from 教师登录信息表 where 学工号='" + this.comboBox2.Text + "'and 密码='" + this.textBox2.Text + "'";
                SqlDataReader hyw = cmd.ExecuteReader();
                if (hyw.Read())
                {
                    string username = this.comboBox2.Text.Trim();
                    string password = this.textBox2.Text.Trim();
                    Dictionary<string, User> users = new Dictionary<string, User>();
                    User user = new User();
                    FileStream fs = new FileStream("data.bin", FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    user.XGH = username;
                    if (this.checkBox1.Checked)       //  如果单击了记住密码的功能
                    {   //  在文件中保存密码
                        user.MM = password;
                    }
                    else
                    {   //  不在文件中保存密码
                        user.MM = "";
                    }

                    //  选在集合中是否存在用户名 
                    if (users.ContainsKey(user.XGH))
                    {
                        users.Remove(user.XGH);
                    }
                    users.Add(user.XGH, user);
                    //要先将User类先设为可以序列化(即在类的前面加[Serializable])
                    bf.Serialize(fs, users);
                    //user.Password = this.PassWord.Text;
                    fs.Close();
                    MessageBox.Show("登陆成功!");
                    Form1.Tenmxgh.tempxgh = comboBox2.Text;
                    this.Hide();
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {                  
                    MessageBox.Show("输入用户名或密码错误！");
                    textBox2.Text = "";
                }
                con.Close();
                hyw.Close();
            }
            else if (comboBox1.Text == "管理员")
            {
                SqlConnection con = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "select 学工号,密码 from 管理员登录信息表 where 学工号='" + this.comboBox2.Text + "'and 密码='" + this.textBox2.Text + "'";
                SqlDataReader hyw = cmd.ExecuteReader();
                if (hyw.Read())
                {
                    string username = this.comboBox2.Text.Trim();
                    string password = this.textBox2.Text.Trim();
                    Dictionary<string, User> users = new Dictionary<string, User>();
                    User user = new User();
                    FileStream fs = new FileStream("data.bin", FileMode.Create);
                    BinaryFormatter bf = new BinaryFormatter();
                    user.XGH = username;
                    if (this.checkBox1.Checked)       //  如果单击了记住密码的功能
                    {   //  在文件中保存密码
                        user.MM = password;
                    }
                    else
                    {   //  不在文件中保存密码
                        user.MM = "";
                    }

                    //  选在集合中是否存在用户名 
                    if (users.ContainsKey(user.XGH))
                    {
                        users.Remove(user.XGH);
                    }
                    users.Add(user.XGH, user);
                    //要先将User类先设为可以序列化(即在类的前面加[Serializable])
                    bf.Serialize(fs, users);
                    //user.Password = this.PassWord.Text;
                    fs.Close();
                    Form1.Tenmxgh.tempxgh = comboBox2.Text;
                    MessageBox.Show("登陆成功!");
                    this.Hide();
                    Form3 form3 = new Form3();
                    form3.Show();
                }
                else
                {              
                    MessageBox.Show("输入用户名或密码错误！");
                    textBox2.Text = "";
                }
                con.Close();
                hyw.Close();
                
            }
            else
            {
                MessageBox.Show("输入信息有误！");
            }      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要退出？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
            else
            {
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(w / 2 - 250, h / 2 - 180);
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            Dictionary<string, User> users = new Dictionary<string, User>();
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();  
                users = bf.Deserialize(fs) as Dictionary<string, User>;
                foreach (User user in users.Values)
                {
                    this.comboBox2.Items.Add(user.XGH);
                }
                for (int i = 0; i < users.Count; i++)
                {
                    if (this.comboBox2.Text != "")
                    {
                        if (users.ContainsKey(this.comboBox2.Text))
                        {
                            this.textBox2.Text = users[this.comboBox2.Text].MM;
                            this.checkBox1.Checked = true;
                        }
                    }
                }
            }
            fs.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  首先读取记住密码的配置文件
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                Dictionary<string, User> users = new Dictionary<string, User>();
                users = bf.Deserialize(fs) as Dictionary<string, User>;
                for (int i = 0; i < users.Count; i++)
                {
                    if (this.comboBox2.Text != "")
                    {
                        if (users.ContainsKey(comboBox2.Text) && users[comboBox2.Text].MM != "")
                        {
                            this.textBox2.Text = users[comboBox2.Text].MM;
                            this.checkBox1.Checked = true;
                        }
                        else
                        {
                            this.textBox2.Text = "";
                            this.checkBox1.Checked = false;
                        }
                    }
                }
            }
            fs.Close();
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            if (i % 2 == 0)
            {
                textBox2.PasswordChar = new char();
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
        public int i=0;//用于记录显示密码按钮点击的次数;
        private void button3_Click(object sender, EventArgs e)
        {
            i++;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            System.Environment.Exit(0);
        }
    }
}
