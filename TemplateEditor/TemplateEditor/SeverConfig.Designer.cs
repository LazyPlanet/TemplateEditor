namespace TemplateEditor
{
    partial class ServerConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConfig));
            this.m_tv_Items = new System.Windows.Forms.TreeView();
            this.m_cms_Operators = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_tmsi_new = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_delete = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tsmi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_update = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_commit = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_lock = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_unlock = new System.Windows.Forms.ToolStripMenuItem();
            this.m_tmsi_open = new System.Windows.Forms.ToolStripMenuItem();
            this.m_il_Icons = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_dgv_ItemDetail = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_BCreateBranch = new System.Windows.Forms.Button();
            this.m_BExport = new System.Windows.Forms.Button();
            this.m_BSave = new System.Windows.Forms.Button();
            this.m_BImport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cms_Operators.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_tv_Items
            // 
            this.m_tv_Items.ContextMenuStrip = this.m_cms_Operators;
            this.m_tv_Items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tv_Items.HideSelection = false;
            this.m_tv_Items.ImageIndex = 1;
            this.m_tv_Items.ImageList = this.m_il_Icons;
            this.m_tv_Items.Location = new System.Drawing.Point(0, 0);
            this.m_tv_Items.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tv_Items.Name = "m_tv_Items";
            this.m_tv_Items.SelectedImageIndex = 1;
            this.m_tv_Items.Size = new System.Drawing.Size(327, 731);
            this.m_tv_Items.TabIndex = 0;
            this.m_tv_Items.Click += new System.EventHandler(this.m_tv_Items_Click);
            this.m_tv_Items.DoubleClick += new System.EventHandler(this.m_tv_Items_DoubleClick);
            this.m_tv_Items.MouseClick += new System.Windows.Forms.MouseEventHandler(this.m_tv_Items_MouseClick);
            // 
            // m_cms_Operators
            // 
            this.m_cms_Operators.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_tmsi_new,
            this.m_tmsi_delete,
            this.m_tsmi_Save,
            this.m_tmsi_update,
            this.m_tmsi_commit,
            this.m_tmsi_lock,
            this.m_tmsi_unlock,
            this.m_tmsi_open});
            this.m_cms_Operators.Name = "m_cms_SelectItem";
            this.m_cms_Operators.Size = new System.Drawing.Size(101, 180);
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
            this.m_tmsi_delete.Enabled = false;
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
            this.m_tmsi_commit.Click += new System.EventHandler(this.m_tmsi_commit_Click);
            // 
            // m_tmsi_lock
            // 
            this.m_tmsi_lock.Name = "m_tmsi_lock";
            this.m_tmsi_lock.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_lock.Text = "加锁";
            this.m_tmsi_lock.Click += new System.EventHandler(this.m_tmsi_lock_Click);
            // 
            // m_tmsi_unlock
            // 
            this.m_tmsi_unlock.Name = "m_tmsi_unlock";
            this.m_tmsi_unlock.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_unlock.Text = "释放";
            this.m_tmsi_unlock.Click += new System.EventHandler(this.m_tmsi_unlock_Click);
            // 
            // m_tmsi_open
            // 
            this.m_tmsi_open.Name = "m_tmsi_open";
            this.m_tmsi_open.Size = new System.Drawing.Size(100, 22);
            this.m_tmsi_open.Text = "刷表";
            this.m_tmsi_open.Click += new System.EventHandler(this.m_tmsi_open_Click);
            // 
            // m_il_Icons
            // 
            this.m_il_Icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_il_Icons.ImageStream")));
            this.m_il_Icons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_il_Icons.Images.SetKeyName(0, "file_191px_1201735_easyicon.net.png");
            this.m_il_Icons.Images.SetKeyName(1, "file_140px_1201060_easyicon.net.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 731);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_dgv_ItemDetail);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Panel2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.splitContainer1.Size = new System.Drawing.Size(888, 731);
            this.splitContainer1.SplitterDistance = 327;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_tv_Items);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 731);
            this.panel3.TabIndex = 1;
            // 
            // m_dgv_ItemDetail
            // 
            this.m_dgv_ItemDetail.AllowUserToAddRows = false;
            this.m_dgv_ItemDetail.AllowUserToDeleteRows = false;
            this.m_dgv_ItemDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_dgv_ItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgv_ItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgv_ItemDetail.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_dgv_ItemDetail.Location = new System.Drawing.Point(0, 145);
            this.m_dgv_ItemDetail.Margin = new System.Windows.Forms.Padding(0);
            this.m_dgv_ItemDetail.MultiSelect = false;
            this.m_dgv_ItemDetail.Name = "m_dgv_ItemDetail";
            this.m_dgv_ItemDetail.RowHeadersWidth = 30;
            this.m_dgv_ItemDetail.RowTemplate.Height = 30;
            this.m_dgv_ItemDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgv_ItemDetail.Size = new System.Drawing.Size(556, 586);
            this.m_dgv_ItemDetail.TabIndex = 0;
            this.m_dgv_ItemDetail.DoubleClick += new System.EventHandler(this.m_dgv_ItemDetail_DoubleClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_BExport);
            this.panel4.Controls.Add(this.m_BImport);
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(556, 145);
            this.panel4.TabIndex = 1;
            // 
            // m_BCreateBranch
            // 
            this.m_BCreateBranch.Location = new System.Drawing.Point(178, 79);
            this.m_BCreateBranch.Name = "m_BCreateBranch";
            this.m_BCreateBranch.Size = new System.Drawing.Size(104, 26);
            this.m_BCreateBranch.TabIndex = 1;
            this.m_BCreateBranch.Text = "创建海外版本";
            this.m_BCreateBranch.UseVisualStyleBackColor = true;
            this.m_BCreateBranch.Click += new System.EventHandler(this.m_BCreateBranch_Click);
            // 
            // m_BExport
            // 
            this.m_BExport.Location = new System.Drawing.Point(183, 34);
            this.m_BExport.Name = "m_BExport";
            this.m_BExport.Size = new System.Drawing.Size(104, 26);
            this.m_BExport.TabIndex = 0;
            this.m_BExport.Text = "导出到CSV";
            this.m_BExport.UseVisualStyleBackColor = true;
            this.m_BExport.Click += new System.EventHandler(this.m_BExport_Click);
            // 
            // m_BSave
            // 
            this.m_BSave.Location = new System.Drawing.Point(24, 79);
            this.m_BSave.Name = "m_BSave";
            this.m_BSave.Size = new System.Drawing.Size(104, 26);
            this.m_BSave.TabIndex = 0;
            this.m_BSave.Text = "保存";
            this.m_BSave.UseVisualStyleBackColor = true;
            this.m_BSave.Click += new System.EventHandler(this.m_BSave_Click);
            // 
            // m_BImport
            // 
            this.m_BImport.Location = new System.Drawing.Point(29, 34);
            this.m_BImport.Name = "m_BImport";
            this.m_BImport.Size = new System.Drawing.Size(104, 26);
            this.m_BImport.TabIndex = 0;
            this.m_BImport.Text = "从CSV导入";
            this.m_BImport.UseVisualStyleBackColor = true;
            this.m_BImport.Click += new System.EventHandler(this.m_BImport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_BCreateBranch);
            this.groupBox1.Controls.Add(this.m_BSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "控制台";
            // 
            // ServerConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 731);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ServerConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DataCreate_Load);
            this.m_cms_Operators.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ContextMenuStrip m_cms_Operators;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_lock;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_commit;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_update;
        private System.Windows.Forms.ToolStripMenuItem m_tsmi_Save;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_delete;
        private System.Windows.Forms.ImageList m_il_Icons;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button m_BExport;
        private System.Windows.Forms.Button m_BImport;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_new;
        private System.Windows.Forms.Button m_BSave;
        public System.Windows.Forms.DataGridView m_dgv_ItemDetail;
        public System.Windows.Forms.TreeView m_tv_Items;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_unlock;
        private System.Windows.Forms.ToolStripMenuItem m_tmsi_open;
        private System.Windows.Forms.Button m_BCreateBranch;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}