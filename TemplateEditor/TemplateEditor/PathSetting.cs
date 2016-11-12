using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TemplateEditor
{
    public partial class PathSetting : Form
    {
        public PathSetting()
        {
            InitializeComponent();
        }

        private void PathSetting_Load(object sender, EventArgs e)
        {
            this.m_tb_SvnPath.Text = MainPage.m_SvnPath;
        }

        private void m_b_Ok_Click(object sender, EventArgs e)
        {
            String path = "";
            if (String.IsNullOrEmpty(path))
            {
                //MessageBox.Show("请选择存储路径.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                //this.DialogResult = DialogResult.None;
                //return;
            }

            String svnPath = m_tb_SvnPath.Text.ToString().Trim();
            if (svnPath != "")
            {
                //Process.Start(@"svn", @"checkout " + svnPath);
            }
        }

        private void m_b_Browser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //this.m_tb_Path.Text = dialog.SelectedPath.ToString();
            }
        }

    }
}
