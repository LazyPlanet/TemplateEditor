namespace TemplateEditor
{
    partial class ItemDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.m_dgv_ItemDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgv_ItemDetail
            // 
            this.m_dgv_ItemDetail.AllowUserToAddRows = false;
            this.m_dgv_ItemDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgv_ItemDetail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.m_dgv_ItemDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgv_ItemDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.m_dgv_ItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgv_ItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgv_ItemDetail.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_dgv_ItemDetail.Location = new System.Drawing.Point(10, 10);
            this.m_dgv_ItemDetail.Margin = new System.Windows.Forms.Padding(0);
            this.m_dgv_ItemDetail.Name = "m_dgv_ItemDetail";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.m_dgv_ItemDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.m_dgv_ItemDetail.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dgv_ItemDetail.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.m_dgv_ItemDetail.RowTemplate.Height = 30;
            this.m_dgv_ItemDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgv_ItemDetail.Size = new System.Drawing.Size(564, 567);
            this.m_dgv_ItemDetail.TabIndex = 1;
            // 
            // ItemDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 587);
            this.Controls.Add(this.m_dgv_ItemDetail);
            this.Name = "ItemDetail";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细信息";
            this.Load += new System.EventHandler(this.ItemDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView m_dgv_ItemDetail;
    }
}