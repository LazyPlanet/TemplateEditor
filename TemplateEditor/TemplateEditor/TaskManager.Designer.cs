namespace TemplateEditor
{
    partial class TaskManager
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
            this.m_BCreateBranch = new System.Windows.Forms.Button();
            this.m_BExport = new System.Windows.Forms.Button();
            this.m_BSave = new System.Windows.Forms.Button();
            this.m_BImport = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_B_Export = new System.Windows.Forms.Button();
            this.m_B_Save = new System.Windows.Forms.Button();
            this.m_B_Import = new System.Windows.Forms.Button();
            this.m_dgv_ItemDetail = new System.Windows.Forms.DataGridView();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // m_BCreateBranch
            // 
            this.m_BCreateBranch.Location = new System.Drawing.Point(203, 119);
            this.m_BCreateBranch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_BCreateBranch.Name = "m_BCreateBranch";
            this.m_BCreateBranch.Size = new System.Drawing.Size(150, 47);
            this.m_BCreateBranch.TabIndex = 6;
            this.m_BCreateBranch.Text = "创建海外版本";
            this.m_BCreateBranch.UseVisualStyleBackColor = true;
            // 
            // m_BExport
            // 
            this.m_BExport.Location = new System.Drawing.Point(203, 33);
            this.m_BExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_BExport.Name = "m_BExport";
            this.m_BExport.Size = new System.Drawing.Size(150, 47);
            this.m_BExport.TabIndex = 5;
            this.m_BExport.Text = "导出到CSV";
            this.m_BExport.UseVisualStyleBackColor = true;
            // 
            // m_BSave
            // 
            this.m_BSave.Location = new System.Drawing.Point(23, 119);
            this.m_BSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_BSave.Name = "m_BSave";
            this.m_BSave.Size = new System.Drawing.Size(150, 47);
            this.m_BSave.TabIndex = 4;
            this.m_BSave.Text = "保存到BIN";
            this.m_BSave.UseVisualStyleBackColor = true;
            // 
            // m_BImport
            // 
            this.m_BImport.Location = new System.Drawing.Point(23, 33);
            this.m_BImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_BImport.Name = "m_BImport";
            this.m_BImport.Size = new System.Drawing.Size(150, 47);
            this.m_BImport.TabIndex = 3;
            this.m_BImport.Text = "从CSV导入";
            this.m_BImport.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_B_Export);
            this.panel4.Controls.Add(this.m_B_Save);
            this.panel4.Controls.Add(this.m_B_Import);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(908, 80);
            this.panel4.TabIndex = 7;
            // 
            // m_B_Export
            // 
            this.m_B_Export.Location = new System.Drawing.Point(170, 22);
            this.m_B_Export.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_B_Export.Name = "m_B_Export";
            this.m_B_Export.Size = new System.Drawing.Size(100, 35);
            this.m_B_Export.TabIndex = 0;
            this.m_B_Export.Text = "导出到CSV";
            this.m_B_Export.UseVisualStyleBackColor = true;
            this.m_B_Export.Click += new System.EventHandler(this.m_B_Export_Click);
            // 
            // m_B_Save
            // 
            this.m_B_Save.Location = new System.Drawing.Point(317, 22);
            this.m_B_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_B_Save.Name = "m_B_Save";
            this.m_B_Save.Size = new System.Drawing.Size(100, 35);
            this.m_B_Save.TabIndex = 0;
            this.m_B_Save.Text = "保存";
            this.m_B_Save.UseVisualStyleBackColor = true;
            this.m_B_Save.Click += new System.EventHandler(this.m_B_Save_Click);
            // 
            // m_B_Import
            // 
            this.m_B_Import.Location = new System.Drawing.Point(23, 22);
            this.m_B_Import.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_B_Import.Name = "m_B_Import";
            this.m_B_Import.Size = new System.Drawing.Size(100, 35);
            this.m_B_Import.TabIndex = 0;
            this.m_B_Import.Text = "从CSV导入";
            this.m_B_Import.UseVisualStyleBackColor = true;
            this.m_B_Import.Click += new System.EventHandler(this.m_B_Import_Click);
            // 
            // m_dgv_ItemDetail
            // 
            this.m_dgv_ItemDetail.AllowUserToAddRows = false;
            this.m_dgv_ItemDetail.AllowUserToDeleteRows = false;
            this.m_dgv_ItemDetail.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_dgv_ItemDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgv_ItemDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dgv_ItemDetail.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_dgv_ItemDetail.Location = new System.Drawing.Point(0, 80);
            this.m_dgv_ItemDetail.Margin = new System.Windows.Forms.Padding(0);
            this.m_dgv_ItemDetail.Name = "m_dgv_ItemDetail";
            this.m_dgv_ItemDetail.RowHeadersWidth = 30;
            this.m_dgv_ItemDetail.RowTemplate.Height = 30;
            this.m_dgv_ItemDetail.Size = new System.Drawing.Size(908, 630);
            this.m_dgv_ItemDetail.TabIndex = 8;
            // 
            // TaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 710);
            this.Controls.Add(this.m_dgv_ItemDetail);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.m_BCreateBranch);
            this.Controls.Add(this.m_BExport);
            this.Controls.Add(this.m_BSave);
            this.Controls.Add(this.m_BImport);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TaskManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TaskManager_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgv_ItemDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_BCreateBranch;
        private System.Windows.Forms.Button m_BExport;
        private System.Windows.Forms.Button m_BSave;
        private System.Windows.Forms.Button m_BImport;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button m_B_Export;
        private System.Windows.Forms.Button m_B_Save;
        private System.Windows.Forms.Button m_B_Import;
        private System.Windows.Forms.DataGridView m_dgv_ItemDetail;

    }
}