namespace TemplateEditor
{
    partial class CreateTemplate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTemplate));
            this.m_tv_Items = new System.Windows.Forms.TreeView();
            this.m_cms_SelectItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tmsi_new = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_lock = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_update = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_commit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_il_Icons = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.m_dgv_ItemDetail = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cms_SelectItem.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // m_tv_Items
            // 
            this.m_tv_Items.ContextMenuStrip = this.m_cms_SelectItem;
            this.m_tv_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tv_Items.ImageIndex = 0;
            this.m_tv_Items.ImageList = this.m_il_Icons;
            this.m_tv_Items.Location = new System.Drawing.Point(0, 0);
            this.m_tv_Items.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tv_Items.Name = "m_tv_Items";
            this.m_tv_Items.SelectedImageIndex = 0;
            this.m_tv_Items.Size = new System.Drawing.Size(323, 662);
            this.m_tv_Items.TabIndex = 0;
            this.m_tv_Items.DoubleClick += new System.EventHandler(this.m_tv_Items_DoubleClick);
            this.m_tv_Items.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_tv_Items_MouseClick);
            // 
            // m_cms_SelectItem
            // 
            this.m_cms_SelectItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tmsi_new,
            this.m_tmsi_delete,
            this.m_tsmi_Save,
            this.m_tmsi_lock,
            this.m_tmsi_update,
            this.m_tmsi_commit});
            this.m_cms_SelectItem.Name = "m_cms_SelectItem";
            this.m_cms_SelectItem.Size = new System.Drawing.Size(101, 136);
            // 
            // m_tmsi_new
            // 
            this.m_tmsi_new.Name = "m_tmsi_new";
            this.m_tmsi_new.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_new.Text = "创建";
            this.m_tmsi_new.Click += new System.EventHandler(this.m_tmsi_new_Click);
            // 
            // m_tmsi_delete
            // 
            this.m_tmsi_delete.Name = "m_tmsi_delete";
            this.m_tmsi_delete.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_delete.Text = "删除";
            this.m_tmsi_delete.Click += new System.EventHandler(this.m_tmsi_delete_Click);
            // 
            // m_tsmi_Save
            // 
            this.m_tsmi_Save.Name = "m_tsmi_Save";
            this.m_tsmi_Save.Size = new System.Drawing.Size(100, 22);
            this.m_tsmi_Save.Text = "保存";
            this.m_tsmi_Save.Click += new System.EventHandler(this.m_tsmi_Save_Click);
            // 
            // m_tmsi_lock
            // 
            this.m_tmsi_lock.Name = "m_tmsi_lock";
            this.m_tmsi_lock.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_lock.Text = "加锁";
            // 
            // m_tmsi_update
            // 
            this.m_tmsi_update.Name = "m_tmsi_update";
            this.m_tmsi_update.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_update.Text = "更新";
            // 
            // m_tmsi_commit
            // 
            this.m_tmsi_commit.Name = "m_tmsi_commit";
            this.m_tmsi_commit.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_commit.Text = "提交";
            // 
            // m_il_Icons
            // 
            this.m_il_Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_il_Icons.ImageStream")));
            this.m_il_Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_il_Icons.Images.SetKeyName(0, "1.png");
            this.m_il_Icons.Images.SetKeyName(1, "2.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(873, 731);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgv_ItemDetail);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(873, 731);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_tv_Items);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 662);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 69);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "搜索";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(42, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(281, 23);
            this.textBox1.TabIndex = 0;
            // 
            // m_dgv_ItemDetail
            // 
            this.m_dgv_ItemDetail.AllowUserToAddRows = false;
            this.m_dgv_ItemDetail.AllowUserToDeleteRows = false;
            this.m_dgv_ItemDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_dgv_ItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgv_ItemDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.m_dgv_ItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgv_ItemDetail.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_dgv_ItemDetail.Location = new System.Drawing.Point(0, 0);
            this.m_dgv_ItemDetail.Margin = new System.Windows.Forms.Padding(0);
            this.m_dgv_ItemDetail.Name = "m_dgv_ItemDetail";
            this.m_dgv_ItemDetail.RowHeadersWidth = 30;
            this.m_dgv_ItemDetail.RowTemplate.Height = 30;
            this.m_dgv_ItemDetail.Size = new System.Drawing.Size(545, 731);
            this.m_dgv_ItemDetail.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "属性名称";
            this.Column1.Name = "Column1";
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "属性类型";
            this.Column2.Name = "Column2";
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "属性值";
            this.Column3.Name = "Column3";
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 200;
            // 
            // CreateTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 731);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DataCreate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataCreate_Load);
            this.m_cms_SelectItem.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView m_tv_Items;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip m_cms_SelectItem;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_new;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_lock;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_commit;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_update;
        private System.Windows.Forms.ToolStripMenuItem m_tsmi_Save;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_delete;
        private System.Windows.Forms.DataGridView m_dgv_ItemDetail;
        private System.Windows.Forms.ImageList m_il_Icons;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;

    }
}