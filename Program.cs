using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // args = new string[]{  "-execute" };
            try
            {
                if (args.Length > 0)
                {
                    string currentPath = System.Environment.CurrentDirectory;

                    string path = Environment.GetEnvironmentVariable("path");
                    // MessageBox.Show("当前运行目录为 " + currentPath);
                    // MessageBox.Show("path: " + path);
                    string[] pathsRaw = path.Split(new char[] { ';' }, StringSplitOptions.None);


                    List<string> pathsList = new List<string>(pathsRaw);
                    List<string>.Enumerator en = pathsList.GetEnumerator();
                    bool has = false;
                    while (en.MoveNext())
                    {
                        string value = en.Current;
                        
                        if (currentPath == value)
                        {
                            has = true;
                            break;
                        }
                    }

                    if (has)
                    {
                        DialogResult result = MessageBox.Show("当前目录\n" + currentPath + "\n已经存在于path中, 是否移除?", "是否移除", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes) // 确定 移除
                        {
                            pathsList.Remove(currentPath);

                            Environment.SetEnvironmentVariable("path", combine(pathsList), EnvironmentVariableTarget.Machine);
                        }
                        else // 取消 退出
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("当前目录\n" + currentPath + "\n不存在于path中, 是否添加?", "是否添加", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes) // 确定 添加
                        {
                            pathsList.Add(currentPath);

                            Environment.SetEnvironmentVariable("path", combine(pathsList), EnvironmentVariableTarget.Machine);
                        }
                        else // 取消 退出
                        {
                            Application.Exit();
                        }
                    }
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message,"错误");
            }
        }

        public static string combine (List<string> strs)
        {
            StringBuilder content = new StringBuilder();

            for(var i=0;i<strs.Count-1; i++)
            {
                string str = strs[i];
                content.Append(str).Append(';');
            }
            if(strs.Count > 0)
            {
                content.Append(strs[strs.Count - 1]);
            }

            return content.ToString();
        }
    }
}
