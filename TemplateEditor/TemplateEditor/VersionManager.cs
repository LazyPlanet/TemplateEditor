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
    public partial class VersionManager : Form
    {
        public VersionManager()
        {
            InitializeComponent();
        }

        private void VersionManager_Load(object sender, EventArgs e)
        {
            System.Type type = MainPage.GetAssembly().GetType("PB.Version");

            int index = 0;
            foreach (int enum_value in Enum.GetValues(type))
            {
                String name = Enum.GetName(type, enum_value);

                CheckBox check = new CheckBox();
                check.Text = name;
                check.Location = new Point(30 * (index % 2 == 0 ? 1 : 4), 35 * (index / 2 + 1) );
                check.Size = new System.Drawing.Size(78, 20);

                //int version = Enum.Parse(type, check.Text.ToString()).GetHashCode();

                if (name == "GLOBAL" || MainPage.m_ConfigPath.version.Contains(enum_value))
                {
                    check.Checked = true;
                }

                index++;

                this.Controls.Add(check);
            }
        }

    }
}
