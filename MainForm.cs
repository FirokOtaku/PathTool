using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PathTool
{
    public partial class MainForm : Form
    {
        const string KeyIsPathToolKey = "IsPathToolKey";
        string pathCurrent = null;
        RegistryKey keyShell = null;
        RegistryKey keyPathTool = null;
        public MainForm()
        {
            InitializeComponent();
            string pathReg="";
            pathCurrent = this.GetType().Assembly.Location;

            keyShell = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\shell",true);
            string[] subKeyNames= keyShell.GetSubKeyNames();

            foreach(string subKeyName in subKeyNames) // 搜寻原本的数据
            {
                RegistryKey subKey = keyShell.OpenSubKey(subKeyName);
                object IsPathToolKey=subKey.GetValue(KeyIsPathToolKey); // 关键的键值对
                if (IsPathToolKey != null && "True".Equals(IsPathToolKey) )
                {
                    keyPathTool = subKey;
                }
            }

            if(keyPathTool==null) // 没找到原本的数据
            {
                btnReg.Text = "注册";
            }
            else // keyPathTool != null // 找到原本的数据
            {
                pathReg = "" + keyPathTool.OpenSubKey("command").GetValue(null);
                btnReg.Text = "移除注册";
            }
            
            tbCurrent.Text = pathCurrent;
            tbReg.Text = pathReg;
        }

        // 注册内容
        public void regThis()
        {
            if(keyPathTool!=null) // 之前有
            {
                keyPathTool.SetValue("Icon", pathCurrent); // 设定图标
                RegistryKey keyPathToolCommand = keyPathTool.GetSubKeyNames().Contains("command")?
                    keyPathTool.OpenSubKey("command",true):
                    keyPathTool.CreateSubKey("command",RegistryKeyPermissionCheck.ReadWriteSubTree);
                keyPathToolCommand.SetValue(null, pathCurrent);
            }
            else // 之前没有
            {
                keyPathTool = keyShell.CreateSubKey("PathTool"); // 创建键值对
                keyPathTool.SetValue(KeyIsPathToolKey, "True", RegistryValueKind.String);
                keyPathTool.SetValue(null, "Path Tool");
                keyPathTool.SetValue("Icon", pathCurrent); // 设定图标

                RegistryKey keyPathToolCommand = keyPathTool.CreateSubKey("command");
                keyPathToolCommand.SetValue(null, pathCurrent+" -execute");
            }
            tbReg.Text = pathCurrent + " -execute";
            btnReg.Text = "移除注册";
        }
        // 移除注册表内容
        public void dereg()
        {
            if(keyPathTool!=null)
            {
                string toRemove = keyPathTool.Name.Substring(keyPathTool.Name.LastIndexOf("\\")+1);
                keyShell.DeleteSubKeyTree( toRemove, false );
                // MessageBox.Show("移除了"+toRemove);
                tbReg.Text = "";
                keyPathTool = null;
            }
            btnReg.Text = "注册";
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this,
@"=== 说明 ===
我们向注册表的 HKEY_CLASSES_ROOT\\Directory\\Background 添加一项数据来将本工具注册至资源管理器右键菜单
成功注册后, 您便可使用资源管理器右键菜单中的Path Tool来快速将某目录增加至/移除自系统的Path环境变量
如果更换本工具位置, 需要重新注册

=== PathTool 1.1 by Firok ===
查看源码、检查更新或提交问题请访问 github.com/351768593/PathTool

=== 感谢以下各位参加测试 ===
● Kirisu
● madflea
● Notsfsssf
● scott
● yyh
", "说明", MessageBoxButtons.OK);        }

        private static void log(object obj)
        {
            Console.WriteLine(obj);
        }

        private void btnRegedit_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine("regedit &exit");
            p.StandardInput.AutoFlush = true;
            p.WaitForExit();
            p.Close();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            switch(btnReg.Text)
            {
                case "注册":
                    regThis();
                    break;
                case "移除注册":
                    dereg();
                    break;
            }
        }
    }
}
