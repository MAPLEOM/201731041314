using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp21
{
    public interface countchar
    {
        int tjzf(string filename);//统计字符数
        int tjdc(string filename);//统计单词数并按照字典序输出词频
        int tjhs(string filename);//统计行数
        void dis();               //输出结果
    }
    public class A
    {
        public int tjzf(string filename)//统计字符数
        {
            int zfcount = 0;
            int zfchar = 0;
            FileStream F = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader S = new StreamReader(F);
            while ((zfchar = S.Read()) != -1)
            {
                zfcount++;
            }
            F.Close();
            return zfcount - 6;
        }
    }
    public class B
    {
        public int tjdc(string filename)//统计单词数并按照字典序输出词频
        {
            int dccount = 0;
            int zfchar = 0;
            int x = 0;
            int temp = 1;
            string str = null;
            string strc;
            FileStream F = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);//打开文件
            StreamReader S = new StreamReader(F);
            Dictionary<int, string> D = new Dictionary<int, string>();
            Dictionary<string, int> DD = new Dictionary<string, int>();
            while ((zfchar = S.Read()) != -1)
            {
                if (x < 4)
                {
                    if ((zfchar >= 'a' && zfchar <= 'z') || (zfchar >= 'A' && zfchar <= 'Z'))
                    {
                        strc = ((char)zfchar).ToString();
                        str = str + strc;
                        x++;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (x >= 4)
                {
                    if (zfchar >= '0' && zfchar <= '9' || (zfchar >= 'a' && zfchar <= 'z') || (zfchar >= 'A' && zfchar <= 'Z'))
                    {
                        strc = ((char)zfchar).ToString();
                        str = str + strc;
                    }
                    else
                    {
                        x = 0;
                        if (D.ContainsValue(str) || D.ContainsValue(str.ToLower()) || D.ContainsValue(str.ToUpper()))
                        {
                            foreach (KeyValuePair<int, string> pair in D)
                            {
                                if (pair.Value.ToLower() == str.ToLower() && pair.Value.ToUpper() == str.ToUpper() && pair.Value == str)
                                {
                                    temp++;
                                    DD.Remove(str);
                                    DD.Add(str.ToLower(), temp);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            DD.Add(str, 1);
                            D.Add(dccount, str);
                        }
                        str = null;
                        strc = null;
                        dccount++;
                    }
                }
            }
            var result = from pair in DD orderby pair.Key select pair;
            int i=1;
            foreach (KeyValuePair<string, int> pair in result)
            {
                Console.WriteLine("word"+"{0}"+":{1}-----number:{2}",i, pair.Key, pair.Value);
                i++;
            }
            F.Close();
            return dccount;
        }
    }
    public class C
    {
        public int tjhs(string filename)//统计行数
        {
            int hscount = 0;
            int zfchar;
            FileStream F = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            StreamReader S = new StreamReader(F);
            while ((zfchar = S.Read()) != -1)
            {
                if (zfchar == '\n')
                {
                    hscount++;
                }
                else
                {
                    continue;
                }
            }
            F.Close();
            return hscount - 2;
        }
    }
    public class display
    {
        public void dis()
        {
            A a = new A();
            B b = new B();
            C c = new C();
            string x;
            Console.WriteLine("请输入文件名称:");           
            string File = Console.ReadLine();
            string filename = @"D:\" + File;
            Console.WriteLine("请输入操作内容:（-n:统计单词数;-m:统计字符数;-o:统计行数）以上可以混合输入 ");
            x = Console.ReadLine();
            if (x.Contains("-n") && x.Contains("-m") && x.Contains("-o"))
            {
                int words;
                words = b.tjdc(filename);
                Console.WriteLine("words:{0}", words);
                int characters;
                characters = a.tjzf(filename);
                Console.WriteLine("characters:{0}", characters);
                int lines;
                lines = c.tjhs(filename);
                Console.WriteLine("lines:{0}", lines); 
            }
            else if (x.Contains("-m") && x.Contains("-o"))
            {
                int characters;
                characters = a.tjzf(filename);
                Console.WriteLine("characters:{0}", characters);
                int lines;
                lines = c.tjhs(filename);
                Console.WriteLine("lines:{0}", lines);
            }
            else if (x.Contains("-n") && x.Contains("-o"))
            {
                int words;
                words = b.tjdc(filename);
                Console.WriteLine("words:{0}", words);
                int lines;
                lines = c.tjhs(filename);
                Console.WriteLine("lines:{0}", lines);
            }
            else if (x.Contains("-n") && x.Contains("-m"))
            {
                int words;
                words = b.tjdc(filename);
                Console.WriteLine("words:{0}", words);
                int characters;
                characters = a.tjzf(filename);
                Console.WriteLine("characters:{0}", characters);
            }
            else if (x.Contains("-n"))
            {
                int words;
                words = b.tjdc(filename);
                Console.WriteLine("words:{0}", words);
            }
            else if (x.Contains("-m"))
            {
                int characters;
                characters = a.tjzf(filename);
                Console.WriteLine("characters:{0}", characters);
            }
            else if (x.Contains("-o"))
            {
                int lines;
                lines = c.tjhs(filename);
                Console.WriteLine("lines:{0}", lines);
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            display dd = new display();
            dd.dis();
            Console.ReadLine();            
        }
    }
}
