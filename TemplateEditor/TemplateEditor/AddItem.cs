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
    public partial class AddItem : Form
    {
        public AddItem()
        {
            InitializeComponent();
        }

        private void m_b_Ok_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(m_tb_Name.Text.ToString().Trim()))
            {
                MessageBox.Show("Input template name first.", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
        }

    }
}
