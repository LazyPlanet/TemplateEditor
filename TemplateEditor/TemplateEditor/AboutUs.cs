using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TemplateEditor
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            m_l_Description.Text = "祖龙娱乐科技 程序四部\r\n\r\n  祖龙娱乐科技 © 2016 All rights reserved.";
        }
    }
}
