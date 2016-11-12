namespace TemplateEditor
{
    partial class VersionManager
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
            this.m_b_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_b_Ok
            // 
            this.m_b_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.m_b_Ok.Location = new System.Drawing.Point(119, 255);
            this.m_b_Ok.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.m_b_Ok.Name = "m_b_Ok";
            this.m_b_Ok.Size = new System.Drawing.Size(77, 33);
            this.m_b_Ok.TabIndex = 6;
            this.m_b_Ok.Text = "确定";
            this.m_b_Ok.UseVisualStyleBackColor = true;
            // 
            // VersionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 303);
            this.Controls.Add(this.m_b_Ok);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "VersionManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "版本控制";
            this.Load += new System.EventHandler(this.VersionManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_b_Ok;

    }
}