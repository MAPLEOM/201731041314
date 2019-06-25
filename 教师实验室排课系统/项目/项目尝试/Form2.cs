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
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        public static class O
        {
            public static int isOpenorClose_8;
            public static int isOpenorClose_2;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection(@"data source = 132.232.156.108; " +
                        "initial catalog=项目尝试;persist security info=true;" +
                        "user id=sa;password=qq1234@");
            con1.Open();
            string str2 = "update 教室基本信息表 set 教室排课状态=replace(教室排课状态,'未排课','已排课') where 教室详细位置 in (select 排课教室 from 排课清单 )";
            string str3 = "update 教室基本信息表 set 教室排课状态=replace(教室排课状态,'已排课','未排课') where 教室详细位置 not in (select 排课教室 from 排课清单 )";
            SqlCommand cmd1 = new SqlCommand(str2);
            SqlCommand cmd2 = new SqlCommand(str3);
            cmd1.Connection = con1;
            cmd2.Connection = con1;
            int i = Convert.ToInt32(cmd1.ExecuteNonQuery());
            int i1= Convert.ToInt32(cmd2.ExecuteNonQuery());
            SqlDataAdapter sq;
            if (this.comboBox1.SelectedIndex == -1)
            {
                if (this.comboBox2.SelectedIndex == -1)
                {
                    if (this.comboBox3.SelectedIndex == -1)
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 节次='"+this.comboBox6.Text+"'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 星期='"+this.comboBox5.Text+"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 星期='" + this.comboBox5.Text + "' and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 周次='"+this.comboBox4.Text+"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 周次='"+this.comboBox4.Text+"'and 节次='"+this.comboBox6.Text+"'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "' and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='"+ this.comboBox3.Text +"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "' and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.comboBox3.SelectedIndex == -1)
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='"+ this.comboBox2.Text+"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='"+this.comboBox3.Text+"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.comboBox2.SelectedIndex == -1)
                {
                    if (this.comboBox3.SelectedIndex == -1)
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='"+this.comboBox1.Text+"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 节次='"+this.comboBox6.Text+"'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='"+this.comboBox3.Text+"'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3 .Text+ "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "' and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (this.comboBox3.SelectedIndex == -1)
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);

                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);

                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);

                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.comboBox4.SelectedIndex == -1)
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'", con1);

                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                        else
                        {
                            if (this.comboBox5.SelectedIndex == -1)
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                            else
                            {
                                if (this.comboBox6.SelectedIndex == -1)
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'", con1);
                                }
                                else
                                {
                                    sq = new SqlDataAdapter("select * from 教室基本信息表 where 教室所在楼='" + this.comboBox1.Text + "'and 教室所在区='" + this.comboBox2.Text + "'and 教室所在层='" + this.comboBox3.Text + "'and 周次='" + this.comboBox4.Text + "'and 星期='" + this.comboBox5.Text + "'and 节次='" + this.comboBox6.Text + "'", con1);
                                }
                            }
                        }
                    }
                }

            }
            DataSet ds = new DataSet();
            sq.Fill(ds, "教室基本信息表");
            dataGridView1.DataSource = ds.Tables["教室基本信息表"];
            sq.Dispose();
            con1.Close();   
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form2.O.isOpenorClose_2 = 1;
            Form2.O.isOpenorClose_8 = 0;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认要退出系统吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                System.Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }         
        }
        
       
        private void button2_Click(object sender, EventArgs e)
        {
            if (Form2.O.isOpenorClose_8 == 0)    //如果窗体未打开，创建窗体对象并显示
            {
                Form8 f8 = new Form8();
                f8.Show();               
            }
            else
            {
                MessageBox.Show("窗口已打开!");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form2.O.isOpenorClose_2 = 0;        
        }

    }
}
