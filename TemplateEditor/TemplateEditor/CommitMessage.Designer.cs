namespace TemplateEditor
{
    partial class CommitMessage
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
            this.m_tb_Log = new System.Windows.Forms.TextBox();
            this.m_b_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_tb_Log
            // 
            this.m_tb_Log.Location = new System.Drawing.Point(15, 29);
            this.m_tb_Log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_tb_Log.Name = "m_tb_Log";
            this.m_tb_Log.Size = new System.Drawing.Size(394, 23);
            this.m_tb_Log.TabIndex = 0;
            // 
            // m_b_OK
            // 
            this.m_b_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_b_OK.Location = new System.Drawing.Point(433, 26);
            this.m_b_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_OK.Name = "m_b_OK";
            this.m_b_OK.Size = new System.Drawing.Size(87, 28);
            this.m_b_OK.TabIndex = 1;
            this.m_b_OK.Text = "确定";
            this.m_b_OK.UseVisualStyleBackColor = true;
            this.m_b_OK.Click += new System.EventHandler(this.m_b_OK_Click);
            // 
            // CommitMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 75);
            this.Controls.Add(this.m_b_OK);
            this.Controls.Add(this.m_tb_Log);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "CommitMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "提交日志";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_b_OK;
        public System.Windows.Forms.TextBox m_tb_Log;
    }
}