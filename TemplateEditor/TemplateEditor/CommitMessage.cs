using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TemplateEditor
{
    public partial class CommitMessage : Form
    {
        public CommitMessage()
        {
            InitializeComponent();
        }

        private void m_b_OK_Click(object sender, EventArgs e)
        {
            if (this.m_tb_Log.Text.ToString() == "")
            {
                this.DialogResult = DialogResult.Cancel;

                MessageBox.Show("提交内容，必须填写日志信息", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
    }
}
