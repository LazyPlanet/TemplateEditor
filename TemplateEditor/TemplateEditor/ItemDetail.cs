using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace TemplateEditor
{
    public partial class ItemDetail : Form
    {
        public DataGridViewSelectedRowCollection m_Rows = null;
        public DataGridViewColumnCollection m_Columns = null;

        public ItemDetail()
        {
            InitializeComponent();
        }

        private void ItemDetail_Load(object sender, EventArgs e)
        {
            String[] columns = new String[] {"属性名称", "属性值"};
            foreach (String text in columns)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = text;
                column.Width = 250;
                this.m_dgv_ItemDetail.Columns.Add(column);
            }

            new Thread(new ThreadStart(LoadRow)).Start();
        }

        private void LoadRow()
        {
            this.m_dgv_ItemDetail.Invoke((EventHandler)delegate
            {
                if (this.m_Rows.Count <= 0) return;

                DataGridViewRow view = this.m_Rows[0];

                if (m_Columns.Count != view.Cells.Count)
                {
                    MessageBox.Show("找程序问问吧，我也不知道咋了...", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < m_Columns.Count; ++i)
                {
                    int index = this.m_dgv_ItemDetail.Rows.Add();

                    this.m_dgv_ItemDetail.Rows[index].Cells[0].Value = m_Columns[i].HeaderText.ToString();
                    this.m_dgv_ItemDetail.Rows[index].Cells[1].Value = view.Cells[i].Value;
                }
            });
        }
    }
}
