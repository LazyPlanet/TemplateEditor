using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using ProtoBuf;
using SharpSvn;
using System.Threading;
using System.Diagnostics;

namespace TemplateEditor
{
    public partial class MainPage : Form
    {
        /*
         * Global variable 
         * */
        public static CreateTemplate m_DataCreate = null;
        public static ServerConfig m_ServerConfig = null;
        public static TaskManager m_TaskManager = null;
        public static VersionManager m_VersionManager = null;

        public static String m_TemplatePath = "";
        public static String m_SvnPath = "";
        public static Solution.ConfigPath m_ConfigPath = null;

        public static String m_ServerConfigPath = "";
        public static String m_ClientConfigPath = "";
        
        public static String m_ServerConfigRelativePath = "\\DesData\\Server\\configuration\\";
        public static String m_ClientConfigRelativePath = "\\DesData\\Client\\ClientConfig\\Configs\\configuration\\";

        public static Assembly m_Assembly = null;

        Thread m_Thread = null;
        /*
         * Constructor 
         * */
        public MainPage()
        {
            InitializeComponent();

            GenerateCode();
        }
       
        private void MainPage_Load(object sender, EventArgs e)
        {
            m_ServerConfigPath = new StringBuilder(Directory.GetCurrentDirectory()).Append(m_ServerConfigRelativePath).ToString();
            m_ClientConfigPath = new StringBuilder(Directory.GetCurrentDirectory()).Append(m_ClientConfigRelativePath).ToString();

            using (var file = System.IO.File.OpenRead("Config.bin"))
            {
                MainPage.m_ConfigPath = ProtoBuf.Serializer.Deserialize<Solution.ConfigPath>(file);
            }

            if (!LoadDll())
            {
                Application.Exit();
            }

            TSMI_SERVER_CONFIG_Click(sender, e);
        }

        public bool LoadDll()
        {
            String dllName = GenerateDll();

            if (dllName == String.Empty)
            {
                MessageBox.Show("加载动态文件失败，请您不要打开多个工具窗口.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }

            m_Assembly = Assembly.LoadFrom(dllName);
            return true;
        }

        public static Assembly GetAssembly()
        {
            return m_Assembly;
        }

        public static System.Type GetMessage(String itemName)
        {
            return MainPage.GetAssembly().GetType("PB." + itemName);
        }

        private void GenerateCode()
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            p.StartInfo.FileName = "protogen.exe";

            p.StartInfo.Arguments = "-i:ShareProtoc/config_common.proto -o:ConfigCommon.cs";
            
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;

            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            
            p.Start();
            p.WaitForExit();
            p.Close();
        }

        private String GenerateDll()
        {
            String csName = "ConfigCommon.cs";

            if (!File.Exists(csName))
            {
                return String.Empty;
            }

            String dllName = csName.Substring(0, csName.LastIndexOf(".")) + ".dll";

            CodeDomProvider codeDomProvider = new Microsoft.CSharp.CSharpCodeProvider();
            
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = false;
            parameters.OutputAssembly = dllName;

            parameters.GenerateExecutable = false;
            parameters.GenerateInMemory = true;

            parameters.ReferencedAssemblies.Add("mscorlib.dll");
            parameters.ReferencedAssemblies.Add("System.dll");
            parameters.ReferencedAssemblies.Add("System.Core.dll");
            parameters.ReferencedAssemblies.Add("protobuf-net.dll");

            try
            {
                CompilerResults results = codeDomProvider.CompileAssemblyFromFile(parameters, csName);

                if (results.Errors.HasErrors)
                {
                    StringBuilder sb = new StringBuilder();

                    foreach (CompilerError error in results.Errors)
                    {
                        sb.AppendLine(String.Format("Error ({0}): {1}", error.ErrorNumber, error.ErrorText));
                    }

                    return String.Empty;
                }
            }
            catch (System.Exception)
            {
                return String.Empty;
            }

            return dllName;
        }

        /*
         * Create Data
         * */
        private void TSMI_DATA_CREATE_Click(object sender, EventArgs e)
        {
            if (m_DataCreate != null && m_DataCreate.Created)
                m_DataCreate.Focus();
            else
            {
                m_DataCreate = new CreateTemplate();
                m_DataCreate.MdiParent = this;
                m_DataCreate.Show();
            }
        }
        /*
         * Setting path
         * */
        private void TSMI_SETTING_PATH_Click(object sender, EventArgs e)
        {
            PathSetting pathSetting = new PathSetting();
            if (pathSetting.ShowDialog() == DialogResult.OK)
            {
                pathSetting.m_tb_SvnPath.Text = Directory.GetCurrentDirectory();
            }
        }
        /*
         * Server config 
         * */
        private void TSMI_SERVER_CONFIG_Click(object sender, EventArgs e)
        {
            if (m_ServerConfig != null && m_ServerConfig.Created)
                m_ServerConfig.Focus();
            else
            {
                m_ServerConfig = new ServerConfig();
                m_ServerConfig.MdiParent = this;
                m_ServerConfig.Show();
            }
        }

        private void m_TSB_AddItem_Click(object sender, EventArgs e)
        {
            //MainPage.AddItem();
        }

        public static void AddItem()
        {
            AddItem item = new AddItem();

            if (item.ShowDialog() == DialogResult.OK)
            {
                String itemName;
                System.Object configObj = null;
                if (m_ServerConfig.m_tv_Items.SelectedNode == null) return;
                try
                {
                    itemName = m_ServerConfig.m_tv_Items.SelectedNode.Text.ToString();
                    System.Type typeName = MainPage.GetAssembly().GetType("PB." + itemName);
                    if (typeName != null) configObj = System.Activator.CreateInstance(typeName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }

                if (configObj == null)
                {
                    MessageBox.Show("请选择正常的模板类型.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }

                String path = item.m_tb_Name.Text.ToString() + ".bin";
                m_ServerConfig.m_tv_Items.SelectedNode.Nodes.Add(path);

                StringBuilder builderPath = new StringBuilder();
                String fullName = builderPath.Append(MainPage.m_TemplatePath).Append("\\").Append(itemName).Append("\\").Append(path).ToString();

                using (var file = System.IO.File.Create(fullName.ToString()))
                {
                    ProtoBuf.Serializer.Serialize(file, configObj);
                }
            }
        }

        private void TSMI_TASK_MANAGER_Click(object sender, EventArgs e)
        {
            if (m_TaskManager != null && m_TaskManager.Created)
                m_TaskManager.Focus();
            else
            {
                m_TaskManager = new TaskManager();
                m_TaskManager.MdiParent = this;
                m_TaskManager.Show();
            }
        }

        private void TSMI_SETTING_VERSION_Click(object sender, EventArgs e)
        {
            m_VersionManager = new VersionManager();

            if (m_VersionManager.ShowDialog() == DialogResult.OK)
            {
                MainPage.m_ConfigPath.version.Clear();

                System.Type type = MainPage.GetAssembly().GetType("PB.Version");

                for (int i = 0; i < m_VersionManager.Controls.Count; ++i)
                {
                    Control control = m_VersionManager.Controls[i];

                    String name = control.GetType().ToString();

                    if (name == "System.Windows.Forms.CheckBox")
                    {
                        CheckBox check = (CheckBox)control;

                        if (check.Checked)
                        {
                            int version = Enum.Parse(type, check.Text.ToString()).GetHashCode();

                            MainPage.m_ConfigPath.version.Add(version);
                        }
                    }

                }

                using (var file = System.IO.File.Create("Config.bin"))
                {
                    ProtoBuf.Serializer.Serialize(file, MainPage.m_ConfigPath);
                }
            }
        }

        public String GetLocalName(String name)
        {
            String localName = NameResource.ResourceManager.GetString(name);
            
            if (localName == "")
            {
                return name;
            }
            else
            {
                return localName;
            }
        }

        private void ExportBatch()
        {
            try
            {
                int total = 0;
                MainPage.m_ServerConfig.m_tv_Items.Invoke((EventHandler)delegate {

                    foreach (TreeNode node in MainPage.m_ServerConfig.m_tv_Items.Nodes)
                    {
                        MainPage.m_ServerConfig.m_tv_Items.SelectedNode = node;

                        String itemName = MainPage.m_ServerConfig.GetSelectedFileWithoutExtension();

                        if (itemName == null) continue;

                        System.Type typeName = MainPage.GetMessage(itemName);

                        if (typeName == null) continue;

                        MainPage.m_ServerConfig.Import();   //导入CSV文件

                        if (MainPage.m_ServerConfig.SaveFile()) //保存BIN和LUA文件
                        {
                            total += 1;
                        }
                        else
                        {
                            return;
                        }
                    }

                    MessageBox.Show(String.Format("批量导出成功,本次共导出文件{0}个...", total), "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("批量导出失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                m_Thread.Abort();
                return;
            }
        }

        private void TSMI_SETTING_HELP_Click(object sender, EventArgs e)
        {
            Process.Start("AcroRd32.exe", "help.pdf");
        }

        private void TSMI_SETTING_ABOUTUS_Click(object sender, EventArgs e)
        {
            new AboutUs().ShowDialog();
        }

        private void m_TSB_Help_Click(object sender, EventArgs e)
        {
            TSMI_SETTING_HELP_Click(sender, e);
        }

        private void TSMI_CENGDIE_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);    
        }

        private void TSMI_HPINGPU_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);       
        }

        private void TSMI_VPINGPU_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);            
        }

        private void TSMI_FULLSCREEN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void TSMI_HIDE_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void m_TSB_Save_Click(object sender, EventArgs e)
        {
            TSMI_SERVER_CONFIG_Click(sender, e);    //先打开配置主界面
            m_ServerConfig.m_BSave_Click(sender, e);
        }

        private void m_TSB_GeneratePb_Click(object sender, EventArgs e)
        {
            TSMI_SERVER_CONFIG_Click(sender, e);    //先打开配置主界面

            m_Thread = new Thread(new ThreadStart(ExportBatch));
            m_Thread.Start();
        }


        private void m_TSB_Export_Click(object sender, EventArgs e)
        {
            TSMI_SERVER_CONFIG_Click(sender, e);    //先打开配置主界面
            m_ServerConfig.m_BExport_Click(sender, e);
        }

        private void m_TSB_Import_Click(object sender, EventArgs e)
        {
            TSMI_SERVER_CONFIG_Click(sender, e);    //先打开配置主界面
            m_ServerConfig.m_BImport_Click(sender, e);
        }

        private void m_TSB_Update_Click(object sender, EventArgs e)
        {
            TSMI_SERVER_CONFIG_Click(sender, e);    //先打开配置主界面
        }

    }
}
