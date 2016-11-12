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
    public partial class CreateBranch : Form
    {
        private class EnumItem
        {
            int _ItemID;
            string _ItemName;

            public int ItemID
            {
                get { return _ItemID; }
                set { _ItemID = value; }
            }

            public string ItemName
            {
                get { return _ItemName; }
                set { _ItemName = value; }
            }
        }

        public CreateBranch()
        {
            InitializeComponent();
        }

        private void CreateBranch_Load(object sender, EventArgs e)
        {
            System.Type type = MainPage.GetAssembly().GetType("PB.Version");

            foreach (int enum_value in Enum.GetValues(type))
            {
                this.m_cb_From.Items.Add(Enum.GetName(type, enum_value));
                this.m_cb_To.Items.Add(Enum.GetName(type, enum_value));
            }
        }

        private void m_b_Ok_Click(object sender, EventArgs e)
        {
            if (m_cb_From.Text.ToString() == "" || m_cb_To.Text.ToString() == "")
            {
                MessageBox.Show("请选择目标和源数据", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
