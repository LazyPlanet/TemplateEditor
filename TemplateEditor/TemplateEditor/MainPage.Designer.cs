namespace TemplateEditor
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.m_menuStrip = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.配置CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模板TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_VIEW = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_FULLSCREEN = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_HIDE = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_DATA = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_DATA_CREATE = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SERVER_CONFIG = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SETTING = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SETTING_VERSION = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SETTING_PATH = new System.Windows.Forms.ToolStripMenuItem();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CENGDIE = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_VPINGPU = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_HPINGPU = new System.Windows.Forms.ToolStripMenuItem();
            this.用户UToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于HToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SETTING_ABOUTUS = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_SETTING_HELP = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.m_TSB_AddItem = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_GeneratePb = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Export = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Import = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Update = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Save = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Setting = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Users = new System.Windows.Forms.ToolStripButton();
            this.m_TSB_Help = new System.Windows.Forms.ToolStripButton();
            this.m_menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_menuStrip
            // 
            this.m_menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑EToolStripMenuItem,
            this.TSMI_VIEW,
            this.TSMI_DATA,
            this.TSMI_SETTING,
            this.窗口ToolStripMenuItem,
            this.用户UToolStripMenuItem,
            this.关于HToolStripMenuItem});
            this.m_menuStrip.Location = new System.Drawing.Point(0, 0);
            this.m_menuStrip.Name = "m_menuStrip";
            this.m_menuStrip.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.m_menuStrip.Size = new System.Drawing.Size(864, 27);
            this.m_menuStrip.TabIndex = 1;
            this.m_menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripMenuItem,
            this.新建NToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
            this.文件ToolStripMenuItem.Text = "文件(&F)";
            // 
            // 打开OToolStripMenuItem
            // 
            this.打开OToolStripMenuItem.Name = "打开OToolStripMenuItem";
            this.打开OToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.打开OToolStripMenuItem.Text = "打开(&O)";
            // 
            // 新建NToolStripMenuItem
            // 
            this.新建NToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置CToolStripMenuItem,
            this.模板TToolStripMenuItem});
            this.新建NToolStripMenuItem.Name = "新建NToolStripMenuItem";
            this.新建NToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.新建NToolStripMenuItem.Text = "新建(&N)";
            // 
            // 配置CToolStripMenuItem
            // 
            this.配置CToolStripMenuItem.Name = "配置CToolStripMenuItem";
            this.配置CToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.配置CToolStripMenuItem.Text = "配置(&C)";
            // 
            // 模板TToolStripMenuItem
            // 
            this.模板TToolStripMenuItem.Name = "模板TToolStripMenuItem";
            this.模板TToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.模板TToolStripMenuItem.Text = "模板(&T)";
            // 
            // 编辑EToolStripMenuItem
            // 
            this.编辑EToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.编辑EToolStripMenuItem.Name = "编辑EToolStripMenuItem";
            this.编辑EToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.编辑EToolStripMenuItem.Text = "编辑(&E)";
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.复制ToolStripMenuItem.Text = "复制(&C)";
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴(&V)";
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.删除ToolStripMenuItem.Text = "删除(&D)";
            // 
            // TSMI_VIEW
            // 
            this.TSMI_VIEW.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_FULLSCREEN,
            this.TSMI_HIDE});
            this.TSMI_VIEW.Name = "TSMI_VIEW";
            this.TSMI_VIEW.Size = new System.Drawing.Size(60, 21);
            this.TSMI_VIEW.Text = "视图(&V)";
            // 
            // TSMI_FULLSCREEN
            // 
            this.TSMI_FULLSCREEN.Name = "TSMI_FULLSCREEN";
            this.TSMI_FULLSCREEN.Size = new System.Drawing.Size(115, 22);
            this.TSMI_FULLSCREEN.Text = "全屏(&F)";
            this.TSMI_FULLSCREEN.Click += new System.EventHandler(this.TSMI_FULLSCREEN_Click);
            // 
            // TSMI_HIDE
            // 
            this.TSMI_HIDE.Name = "TSMI_HIDE";
            this.TSMI_HIDE.Size = new System.Drawing.Size(115, 22);
            this.TSMI_HIDE.Text = "托盘(&T)";
            this.TSMI_HIDE.Click += new System.EventHandler(this.TSMI_HIDE_Click);
            // 
            // TSMI_DATA
            // 
            this.TSMI_DATA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_DATA_CREATE,
            this.TSMI_SERVER_CONFIG});
            this.TSMI_DATA.Name = "TSMI_DATA";
            this.TSMI_DATA.Size = new System.Drawing.Size(61, 21);
            this.TSMI_DATA.Text = "数据(&D)";
            // 
            // TSMI_DATA_CREATE
            // 
            this.TSMI_DATA_CREATE.Enabled = false;
            this.TSMI_DATA_CREATE.Name = "TSMI_DATA_CREATE";
            this.TSMI_DATA_CREATE.Size = new System.Drawing.Size(140, 22);
            this.TSMI_DATA_CREATE.Text = "模板管理(&C)";
            this.TSMI_DATA_CREATE.Click += new System.EventHandler(this.TSMI_DATA_CREATE_Click);
            // 
            // TSMI_SERVER_CONFIG
            // 
            this.TSMI_SERVER_CONFIG.Name = "TSMI_SERVER_CONFIG";
            this.TSMI_SERVER_CONFIG.Size = new System.Drawing.Size(140, 22);
            this.TSMI_SERVER_CONFIG.Text = "配置管理(&S)";
            this.TSMI_SERVER_CONFIG.Click += new System.EventHandler(this.TSMI_SERVER_CONFIG_Click);
            // 
            // TSMI_SETTING
            // 
            this.TSMI_SETTING.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_SETTING_VERSION,
            this.TSMI_SETTING_PATH});
            this.TSMI_SETTING.Name = "TSMI_SETTING";
            this.TSMI_SETTING.Size = new System.Drawing.Size(59, 21);
            this.TSMI_SETTING.Text = "设置(&S)";
            // 
            // TSMI_SETTING_VERSION
            // 
            this.TSMI_SETTING_VERSION.Name = "TSMI_SETTING_VERSION";
            this.TSMI_SETTING_VERSION.Size = new System.Drawing.Size(139, 22);
            this.TSMI_SETTING_VERSION.Text = "版本(&V)";
            this.TSMI_SETTING_VERSION.Click += new System.EventHandler(this.TSMI_SETTING_VERSION_Click);
            // 
            // TSMI_SETTING_PATH
            // 
            this.TSMI_SETTING_PATH.Name = "TSMI_SETTING_PATH";
            this.TSMI_SETTING_PATH.Size = new System.Drawing.Size(139, 22);
            this.TSMI_SETTING_PATH.Text = "模板路径(&P)";
            this.TSMI_SETTING_PATH.Click += new System.EventHandler(this.TSMI_SETTING_PATH_Click);
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_CENGDIE,
            this.TSMI_VPINGPU,
            this.TSMI_HPINGPU});
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
            this.窗口ToolStripMenuItem.Text = "窗口(&W)";
            // 
            // TSMI_CENGDIE
            // 
            this.TSMI_CENGDIE.Name = "TSMI_CENGDIE";
            this.TSMI_CENGDIE.Size = new System.Drawing.Size(141, 22);
            this.TSMI_CENGDIE.Text = "层叠(&C)";
            this.TSMI_CENGDIE.Click += new System.EventHandler(this.TSMI_CENGDIE_Click);
            // 
            // TSMI_VPINGPU
            // 
            this.TSMI_VPINGPU.Name = "TSMI_VPINGPU";
            this.TSMI_VPINGPU.Size = new System.Drawing.Size(141, 22);
            this.TSMI_VPINGPU.Text = "垂直平铺(&V)";
            this.TSMI_VPINGPU.Click += new System.EventHandler(this.TSMI_VPINGPU_Click);
            // 
            // TSMI_HPINGPU
            // 
            this.TSMI_HPINGPU.Name = "TSMI_HPINGPU";
            this.TSMI_HPINGPU.Size = new System.Drawing.Size(141, 22);
            this.TSMI_HPINGPU.Text = "水平平铺(&H)";
            this.TSMI_HPINGPU.Click += new System.EventHandler(this.TSMI_HPINGPU_Click);
            // 
            // 用户UToolStripMenuItem
            // 
            this.用户UToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem});
            this.用户UToolStripMenuItem.Name = "用户UToolStripMenuItem";
            this.用户UToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.用户UToolStripMenuItem.Text = "用户(&U)";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.用户管理ToolStripMenuItem.Text = "用户管理(&U)";
            // 
            // 关于HToolStripMenuItem
            // 
            this.关于HToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_SETTING_ABOUTUS,
            this.TSMI_SETTING_HELP});
            this.关于HToolStripMenuItem.Name = "关于HToolStripMenuItem";
            this.关于HToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.关于HToolStripMenuItem.Text = "关于(&I)";
            // 
            // TSMI_SETTING_ABOUTUS
            // 
            this.TSMI_SETTING_ABOUTUS.Name = "TSMI_SETTING_ABOUTUS";
            this.TSMI_SETTING_ABOUTUS.Size = new System.Drawing.Size(117, 22);
            this.TSMI_SETTING_ABOUTUS.Text = "关于(&A)";
            this.TSMI_SETTING_ABOUTUS.Click += new System.EventHandler(this.TSMI_SETTING_ABOUTUS_Click);
            // 
            // TSMI_SETTING_HELP
            // 
            this.TSMI_SETTING_HELP.Name = "TSMI_SETTING_HELP";
            this.TSMI_SETTING_HELP.Size = new System.Drawing.Size(117, 22);
            this.TSMI_SETTING_HELP.Text = "帮助(&H)";
            this.TSMI_SETTING_HELP.Click += new System.EventHandler(this.TSMI_SETTING_HELP_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_TSB_AddItem,
            this.m_TSB_GeneratePb,
            this.m_TSB_Export,
            this.m_TSB_Import,
            this.m_TSB_Update,
            this.m_TSB_Save,
            this.m_TSB_Setting,
            this.m_TSB_Users,
            this.m_TSB_Help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // m_TSB_AddItem
            // 
            this.m_TSB_AddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_AddItem.Image = global::TemplateEditor.Properties.Resources.Add_512px_1177019_easyicon_net;
            this.m_TSB_AddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_AddItem.Name = "m_TSB_AddItem";
            this.m_TSB_AddItem.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_AddItem.Text = "添加配置";
            this.m_TSB_AddItem.Click += new System.EventHandler(this.m_TSB_AddItem_Click);
            // 
            // m_TSB_GeneratePb
            // 
            this.m_TSB_GeneratePb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_GeneratePb.Image = global::TemplateEditor.Properties.Resources.text_file_800px_1197139_easyicon_net;
            this.m_TSB_GeneratePb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_GeneratePb.Name = "m_TSB_GeneratePb";
            this.m_TSB_GeneratePb.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_GeneratePb.Text = "生成版本";
            this.m_TSB_GeneratePb.Click += new System.EventHandler(this.m_TSB_GeneratePb_Click);
            // 
            // m_TSB_Export
            // 
            this.m_TSB_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Export.Image = global::TemplateEditor.Properties.Resources.cloud_storage_841px_1197063_easyicon_net;
            this.m_TSB_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Export.Name = "m_TSB_Export";
            this.m_TSB_Export.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Export.Text = "导出";
            this.m_TSB_Export.Click += new System.EventHandler(this.m_TSB_Export_Click);
            // 
            // m_TSB_Import
            // 
            this.m_TSB_Import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Import.Image = global::TemplateEditor.Properties.Resources.clouds_841px_1197061_easyicon1;
            this.m_TSB_Import.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Import.Name = "m_TSB_Import";
            this.m_TSB_Import.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Import.Text = "导入";
            this.m_TSB_Import.Click += new System.EventHandler(this.m_TSB_Import_Click);
            // 
            // m_TSB_Update
            // 
            this.m_TSB_Update.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Update.Image = global::TemplateEditor.Properties.Resources.circular_arrows_841px_1197059_easyicon_net;
            this.m_TSB_Update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Update.Name = "m_TSB_Update";
            this.m_TSB_Update.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Update.Text = "更新";
            this.m_TSB_Update.Click += new System.EventHandler(this.m_TSB_Update_Click);
            // 
            // m_TSB_Save
            // 
            this.m_TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Save.Image = global::TemplateEditor.Properties.Resources.save_floppy_373px_1187937_easyicon_net;
            this.m_TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Save.Name = "m_TSB_Save";
            this.m_TSB_Save.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Save.Text = "保存";
            this.m_TSB_Save.Click += new System.EventHandler(this.m_TSB_Save_Click);
            // 
            // m_TSB_Setting
            // 
            this.m_TSB_Setting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Setting.Image = global::TemplateEditor.Properties.Resources.cogwheel_794px_1197065_easyicon_net;
            this.m_TSB_Setting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Setting.Name = "m_TSB_Setting";
            this.m_TSB_Setting.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Setting.Text = "设置";
            // 
            // m_TSB_Users
            // 
            this.m_TSB_Users.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Users.Image = global::TemplateEditor.Properties.Resources.connections_841px_1197070_easyicon_net;
            this.m_TSB_Users.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Users.Name = "m_TSB_Users";
            this.m_TSB_Users.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Users.Text = "用户";
            // 
            // m_TSB_Help
            // 
            this.m_TSB_Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_TSB_Help.Image = global::TemplateEditor.Properties.Resources.help_445px_1194438_easyicon_net;
            this.m_TSB_Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_TSB_Help.Name = "m_TSB_Help";
            this.m_TSB_Help.Size = new System.Drawing.Size(23, 22);
            this.m_TSB_Help.Text = "帮助";
            this.m_TSB_Help.Click += new System.EventHandler(this.m_TSB_Help_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(864, 732);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.m_menuStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.m_menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据编辑器 V1.0";
            this.Load += new System.EventHandler(this.MainPage_Load);
            this.m_menuStrip.ResumeLayout(false);
            this.m_menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 窗口ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_DATA;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SETTING;
        private System.Windows.Forms.ToolStripMenuItem TSMI_DATA_CREATE;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SETTING_PATH;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SERVER_CONFIG;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton m_TSB_Export;
        private System.Windows.Forms.ToolStripButton m_TSB_AddItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CENGDIE;
        private System.Windows.Forms.ToolStripButton m_TSB_Save;
        private System.Windows.Forms.ToolStripButton m_TSB_Update;
        private System.Windows.Forms.ToolStripButton m_TSB_Import;
        private System.Windows.Forms.ToolStripButton m_TSB_Help;
        private System.Windows.Forms.ToolStripButton m_TSB_Setting;
        private System.Windows.Forms.ToolStripButton m_TSB_Users;
        private System.Windows.Forms.ToolStripMenuItem 关于HToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SETTING_ABOUTUS;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SETTING_HELP;
        private System.Windows.Forms.ToolStripMenuItem 用户UToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_VIEW;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton m_TSB_GeneratePb;
        private System.Windows.Forms.ToolStripMenuItem TSMI_SETTING_VERSION;
        private System.Windows.Forms.ToolStripMenuItem TSMI_VPINGPU;
        private System.Windows.Forms.ToolStripMenuItem TSMI_HPINGPU;
        private System.Windows.Forms.ToolStripMenuItem TSMI_FULLSCREEN;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 配置CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模板TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_HIDE;

    }
}

