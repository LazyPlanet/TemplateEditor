namespace TemplateEditor
{
    partial class CreateBranch
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
            this.m_cb_From = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cb_To = new System.Windows.Forms.ComboBox();
            this.m_b_Cancel = new System.Windows.Forms.Button();
            this.m_b_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_cb_From
            // 
            this.m_cb_From.FormattingEnabled = true;
            this.m_cb_From.Location = new System.Drawing.Point(41, 37);
            this.m_cb_From.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_cb_From.Name = "m_cb_From";
            this.m_cb_From.Size = new System.Drawing.Size(140, 25);
            this.m_cb_From.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(200, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "复制到";
            // 
            // m_cb_To
            // 
            this.m_cb_To.FormattingEnabled = true;
            this.m_cb_To.Location = new System.Drawing.Point(259, 36);
            this.m_cb_To.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_cb_To.Name = "m_cb_To";
            this.m_cb_To.Size = new System.Drawing.Size(140, 25);
            this.m_cb_To.TabIndex = 2;
            // 
            // m_b_Cancel
            // 
            this.m_b_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_b_Cancel.Location = new System.Drawing.Point(254, 93);
            this.m_b_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_Cancel.Name = "m_b_Cancel";
            this.m_b_Cancel.Size = new System.Drawing.Size(87, 33);
            this.m_b_Cancel.TabIndex = 5;
            this.m_b_Cancel.Text = "取消";
            this.m_b_Cancel.UseVisualStyleBackColor = true;
            // 
            // m_b_Ok
            // 
            this.m_b_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_b_Ok.Location = new System.Drawing.Point(66, 93);
            this.m_b_Ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.m_b_Ok.Name = "m_b_Ok";
            this.m_b_Ok.Size = new System.Drawing.Size(87, 33);
            this.m_b_Ok.TabIndex = 4;
            this.m_b_Ok.Text = "确定";
            this.m_b_Ok.UseVisualStyleBackColor = true;
            this.m_b_Ok.Click += new System.EventHandler(this.m_b_Ok_Click);
            // 
            // CreateBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 145);
            this.Controls.Add(this.m_b_Cancel);
            this.Controls.Add(this.m_b_Ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_cb_To);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cb_From);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CreateBranch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建海外版本数据分支";
            this.Load += new System.EventHandler(this.CreateBranch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_b_Cancel;
        private System.Windows.Forms.Button m_b_Ok;
        public System.Windows.Forms.ComboBox m_cb_From;
        public System.Windows.Forms.ComboBox m_cb_To;
    }
}