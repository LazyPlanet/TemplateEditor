namespace TemplateEditor
{
    partial class PathSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PathSetting));
            this.m_b_Cancel = new System.Windows.Forms.Button();
            this.m_b_Ok = new System.Windows.Forms.Button();
            this.m_tb_SvnPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tB_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tB_PassWord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_b_Cancel
            // 
            this.m_b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_b_Cancel.Location = new System.Drawing.Point(222, 166);
            this.m_b_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_Cancel.Name = "m_b_Cancel";
            this.m_b_Cancel.Size = new System.Drawing.Size(87, 27);
            this.m_b_Cancel.TabIndex = 3;
            this.m_b_Cancel.Text = "取消";
            this.m_b_Cancel.UseVisualStyleBackColor = true;
            // 
            // m_b_Ok
            // 
            this.m_b_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_b_Ok.Location = new System.Drawing.Point(47, 166);
            this.m_b_Ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_Ok.Name = "m_b_Ok";
            this.m_b_Ok.Size = new System.Drawing.Size(87, 27);
            this.m_b_Ok.TabIndex = 2;
            this.m_b_Ok.Text = "确定";
            this.m_b_Ok.UseVisualStyleBackColor = true;
            this.m_b_Ok.Click += new System.EventHandler(this.m_b_Ok_Click);
            // 
            // m_tb_SvnPath
            // 
            this.m_tb_SvnPath.Location = new System.Drawing.Point(117, 30);
            this.m_tb_SvnPath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tb_SvnPath.Name = "m_tb_SvnPath";
            this.m_tb_SvnPath.ReadOnly = true;
            this.m_tb_SvnPath.Size = new System.Drawing.Size(203, 23);
            this.m_tb_SvnPath.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "SVN 地址";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "用 户 名";
            // 
            // m_tB_UserName
            // 
            this.m_tB_UserName.Location = new System.Drawing.Point(117, 73);
            this.m_tB_UserName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tB_UserName.Name = "m_tB_UserName";
            this.m_tB_UserName.ReadOnly = true;
            this.m_tB_UserName.Size = new System.Drawing.Size(203, 23);
            this.m_tB_UserName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "密     码";
            // 
            // m_tB_PassWord
            // 
            this.m_tB_PassWord.Location = new System.Drawing.Point(117, 116);
            this.m_tB_PassWord.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tB_PassWord.Name = "m_tB_PassWord";
            this.m_tB_PassWord.PasswordChar = '6';
            this.m_tB_PassWord.ReadOnly = true;
            this.m_tB_PassWord.Size = new System.Drawing.Size(203, 23);
            this.m_tB_PassWord.TabIndex = 6;
            // 
            // PathSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 214);
            this.Controls.Add(this.m_tB_PassWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_tB_UserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_tb_SvnPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_b_Cancel);
            this.Controls.Add(this.m_b_Ok);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "PathSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "路径设置";
            this.Load += new System.EventHandler(this.PathSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_b_Cancel;
        private System.Windows.Forms.Button m_b_Ok;
        public System.Windows.Forms.TextBox m_tb_SvnPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox m_tB_UserName;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox m_tB_PassWord;
    }
}