namespace TemplateEditor
{
    partial class AddItem
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
            this.m_tb_Name = new System.Windows.Forms.TextBox();
            this.m_b_Ok = new System.Windows.Forms.Button();
            this.m_b_Cancel = new System.Windows.Forms.Button();
            this.m_l_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_tb_Name
            // 
            this.m_tb_Name.Location = new System.Drawing.Point(105, 46);
            this.m_tb_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tb_Name.Name = "m_tb_Name";
            this.m_tb_Name.Size = new System.Drawing.Size(189, 23);
            this.m_tb_Name.TabIndex = 0;
            // 
            // m_b_Ok
            // 
            this.m_b_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_b_Ok.Location = new System.Drawing.Point(33, 106);
            this.m_b_Ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_Ok.Name = "m_b_Ok";
            this.m_b_Ok.Size = new System.Drawing.Size(87, 33);
            this.m_b_Ok.TabIndex = 1;
            this.m_b_Ok.Text = "确定";
            this.m_b_Ok.UseVisualStyleBackColor = true;
            this.m_b_Ok.Click += new System.EventHandler(this.m_b_Ok_Click);
            // 
            // m_b_Cancel
            // 
            this.m_b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_b_Cancel.Location = new System.Drawing.Point(208, 106);
            this.m_b_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_Cancel.Name = "m_b_Cancel";
            this.m_b_Cancel.Size = new System.Drawing.Size(87, 33);
            this.m_b_Cancel.TabIndex = 1;
            this.m_b_Cancel.Text = "取消";
            this.m_b_Cancel.UseVisualStyleBackColor = true;
            // 
            // m_l_Name
            // 
            this.m_l_Name.AutoSize = true;
            this.m_l_Name.Location = new System.Drawing.Point(27, 50);
            this.m_l_Name.Name = "m_l_Name";
            this.m_l_Name.Size = new System.Drawing.Size(56, 17);
            this.m_l_Name.TabIndex = 2;
            this.m_l_Name.Text = "模板名称";
            // 
            // AddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 158);
            this.Controls.Add(this.m_l_Name);
            this.Controls.Add(this.m_b_Cancel);
            this.Controls.Add(this.m_b_Ok);
            this.Controls.Add(this.m_tb_Name);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "AddItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "增加模板";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_b_Ok;
        private System.Windows.Forms.Button m_b_Cancel;
        private System.Windows.Forms.Label m_l_Name;
        public System.Windows.Forms.TextBox m_tb_Name;
    }
}