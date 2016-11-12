using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using global::ProtoBuf;
using System.Reflection;

namespace TemplateEditor
{
    public partial class CreateTemplate : Form
    {
        /*
        * Global variable 
        * */
        private int m_ReadIndex = 0;

        private class EnumItem
        {
            int _ItemID;
            string _ItemName;

            public int ItemID
            {
                get { return _ItemID; }
                set { _ItemID = value; }
            }

            public string ItemName
            {
                get { return _ItemName; }
                set { _ItemName = value; }
            }
        }
        /*
         * Constructor 
         * */
        public CreateTemplate()
        {
            InitializeComponent();
        }
        /*
        * Load resource 
        * */
        private void DataCreate_Load(object sender, EventArgs e)
        {
            FillChildNodes();
        }
        /*
        * Search files 
        * */
        public void FillChildNodes()
        {
            try
            {
                m_tv_Items.Nodes.Clear();
                DirectoryInfo dirs = new DirectoryInfo(MainPage.m_TemplatePath);
                foreach (DirectoryInfo dir in dirs.GetDirectories())
                {
                    if (dir.Attributes == FileAttributes.Hidden) continue;
                    TreeNode node = new TreeNode(dir.Name);
                    m_tv_Items.Nodes.Add(node);
                    DirectoryInfo files = new DirectoryInfo(dir.FullName);
                    if (files.Exists)
                    {
                        foreach (FileInfo file in files.GetFiles())
                        {
                            if (Path.GetExtension(file.Name.ToString()) == ".tpk") continue;
                            node.Nodes.Add(file.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        /*
        * Right click
        * */
        private void m_tv_Items_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {   
                m_cms_SelectItem.Show(); 
            }
        }
        /*
        * Click create new items button
        * */
        private void m_tmsi_new_Click(object sender, EventArgs e)
        {
            AddItem item = new AddItem();
            String itemName = "";
            System.Object configObj = null;
            if (item.ShowDialog() == DialogResult.OK)
            {
                if (this.m_tv_Items.SelectedNode == null) return;
                try
                {
                    itemName = this.m_tv_Items.SelectedNode.Text.ToString();
                    //System.Type typeName = System.Type.GetType("PB." + itemName);
                    System.Type typeName = MainPage.GetAssembly().GetType("PB." + itemName);

                    if (typeName != null) configObj = System.Activator.CreateInstance(typeName);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }

                if (configObj == null)
                {
                    MessageBox.Show("请选择正常的模板类型.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                    return;
                }

                configObj = CreateProtoObject(configObj);
                
                String path = item.m_tb_Name.Text.ToString() + ".bin";
                this.m_tv_Items.SelectedNode.Nodes.Add(path);

                StringBuilder builderPath = new StringBuilder();
                String fullName = builderPath.Append(MainPage.m_TemplatePath).Append("\\").Append(itemName).Append("\\").Append(path).ToString();

                using (var file = System.IO.File.Create(fullName.ToString()))
                {
                    ProtoBuf.Serializer.Serialize(file, configObj);
                }
            }
        }

        private System.Object CreateProtoObject(System.Object configObj)
        {
            PropertyInfo[] properties = configObj.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                string typeName = pi.PropertyType.ToString();

                if (typeName.IndexOf("PB") >= 0)
                {
                    System.Type type = System.Type.GetType(typeName);
                    string baseName = type.BaseType.ToString();

                    if (baseName.IndexOf("System.Enum") < 0 && type != null)
                    {
                        System.Object subObj = System.Activator.CreateInstance(type);
                        pi.SetValue(configObj, subObj, null);

                        CreateProtoObject(subObj);
                    }
                }
            }
            return configObj;
        }

        private void PrintProperty(System.Object configObj, bool bSave)
        {
            PropertyInfo[] properties = configObj.GetType().GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                int index = this.m_dgv_ItemDetail.Rows.Add();

                this.m_dgv_ItemDetail.Rows[index].Cells[0].ReadOnly = true;
                this.m_dgv_ItemDetail.Rows[index].Cells[0].Value = NameResource.ResourceManager.GetString(pi.Name.ToString());
                this.m_dgv_ItemDetail.Rows[index].Cells[1].ReadOnly = true;
                this.m_dgv_ItemDetail.Rows[index].Cells[1].Value = pi.PropertyType.ToString();

                string typeName = pi.PropertyType.ToString();
                
                if (typeName.IndexOf("PB") >= 0)
                {
                    System.Type type = System.Type.GetType(typeName);
                    string baseName = type.BaseType.ToString();
                    if (baseName.IndexOf("System.Enum") >= 0)
                    {
                        List<EnumItem> enum_items = new List<EnumItem>();
                        foreach (int enum_value in Enum.GetValues(type))
                            enum_items.Add(new EnumItem { ItemID = enum_value, ItemName = Enum.GetName(type, enum_value) });

                        DataGridViewComboBoxCell cell = new DataGridViewComboBoxCell();
                        cell.DataSource = enum_items;

                        cell.Value = Enum.Parse(type, pi.GetValue(configObj, null).ToString()).GetHashCode();
                        cell.ValueMember = "ItemID";
                        cell.DisplayMember = "ItemName";

                        this.m_dgv_ItemDetail.Rows[index].Cells[2] = cell;
                        if (bSave)
                        {
                            String content = pi.Name.ToString() + " = " + this.m_dgv_ItemDetail.Rows[index].Cells[2].Value.ToString();
                            DataWriter.WriteText(content, this.GetSelectedFullName().Replace(".bin", ".tpk"));
                        }
                    }
                    else
                    {
                        this.m_dgv_ItemDetail.Rows[index].Cells[2].ReadOnly = true;
                        this.m_dgv_ItemDetail.Rows[index].Height = 0;
                        System.Object subObj = pi.GetValue(configObj, null);
                        PrintProperty(subObj, bSave);
                    }
                }
                else
                {
                    this.m_dgv_ItemDetail.Rows[index].Cells[2].Value = pi.GetValue(configObj, null).ToString();
                    if (bSave)
                    {
                        String content = pi.Name.ToString() + " = " + this.m_dgv_ItemDetail.Rows[index].Cells[2].Value.ToString();
                        DataWriter.WriteText(content, this.GetSelectedFullName().Replace(".bin", ".tpk"));
                    }
                }
            }

        }

        /*
        * Open items
        * */
        private void m_tv_Items_DoubleClick(object sender, EventArgs e)
        {
            if (m_tv_Items.SelectedNode == null || m_tv_Items.SelectedNode.Parent == null) return;
            m_dgv_ItemDetail.Rows.Clear();

            String itemName = m_tv_Items.SelectedNode.Parent.Text.ToString();
            //System.Type typeName = System.Type.GetType("PB." + itemName);
            System.Type typeName = MainPage.GetAssembly().GetType("PB." + itemName);

            if (typeName == null) return;
            System.Object configObj = System.Activator.CreateInstance(typeName);

            try
            {
                using (var file = System.IO.File.OpenRead(this.GetSelectedFullName()))
                {
                    configObj = ProtoBuf.Serializer.NonGeneric.Deserialize(typeName, file);
                }
                PrintProperty(configObj, false);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void SaveProperty(System.Object configObj)
        {
            PropertyInfo[] properties = configObj.GetType().GetProperties();
            
            foreach (PropertyInfo pi in properties)
            {
                System.Object objValue = this.m_dgv_ItemDetail.Rows[m_ReadIndex++].Cells[2].Value;
                String propertyName = pi.PropertyType.ToString();

                if (objValue == null)
                {
                    System.Type typeName = System.Type.GetType(propertyName);
                    if (typeName == null)
                    {
                        MessageBox.Show("无法解析的类型：" + propertyName, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        return;
                    }

                    System.Object subObj = System.Activator.CreateInstance(typeName);
                    SaveProperty(subObj);
                    pi.SetValue(configObj, subObj, null);

                    continue;
                }

                String value = objValue.ToString();

                if (pi.PropertyType.ToString().IndexOf("System.String") >= 0)
                {
                    pi.SetValue(configObj, value, null);
                }
                else if (pi.PropertyType.ToString().IndexOf("System.Int32") >= 0)
                {
                    Int32 result = 0;
                    bool success = Int32.TryParse(value, out result);
                    if (success) pi.SetValue(configObj, result, null);
                }
                else if (pi.PropertyType.ToString().IndexOf("System.UInt32") >= 0)
                {
                    UInt32 result = 0;
                    bool success = UInt32.TryParse(value, out result);
                    if (success) pi.SetValue(configObj, result, null);
                }
                else if (pi.PropertyType.ToString().IndexOf("System.Int64") >= 0)
                {
                    Int64 result = 0;
                    bool success = Int64.TryParse(value, out result);
                    if (success) pi.SetValue(configObj, result, null);
                }
                else if (pi.PropertyType.ToString().IndexOf("System.UInt64") >= 0)
                {
                    UInt64 result = 0;
                    bool success = UInt64.TryParse(value, out result);
                    if (success) pi.SetValue(configObj, result, null);
                }
                else
                {
                    System.Type type = System.Type.GetType(pi.PropertyType.ToString());
                    string baseName = type.BaseType.ToString();

                    if (baseName.IndexOf("System.Enum") >= 0)
                    {
                        int result = Enum.Parse(type, value).GetHashCode();
                        pi.SetValue(configObj, result, null);
                    }
                }
            }
        }

        /*
        * Save items
        * */
        private void m_tsmi_Save_Click(object sender, EventArgs e)
        {
            if (m_tv_Items.SelectedNode == null || m_tv_Items.SelectedNode.Parent == null) return;

            this.m_ReadIndex = 0;

            String itemName = m_tv_Items.SelectedNode.Parent.Text.ToString();
            //System.Type typeName = System.Type.GetType("PB." + itemName);
            System.Type typeName = MainPage.GetAssembly().GetType("PB." + itemName);
            if (typeName == null) return;

            System.Object configObj = System.Activator.CreateInstance(typeName);

            SaveProperty(configObj);

            using (var file = System.IO.File.Create(this.GetSelectedFullName()))
            {
                ProtoBuf.Serializer.Serialize(file, configObj);
            }

            m_dgv_ItemDetail.Rows.Clear();
            PrintProperty(configObj, true);
        }

        /*
         * 
         * */
        private String GetSelectedFullName()
        {
            if (m_tv_Items.SelectedNode == null || m_tv_Items.SelectedNode.Parent == null) return null;

            String itemName = m_tv_Items.SelectedNode.Parent.Text.ToString();
            String fileName = m_tv_Items.SelectedNode.Text.ToString();

            StringBuilder fullName = new StringBuilder();
            fullName.Append(MainPage.m_TemplatePath).Append("\\").Append(itemName).Append("\\").Append(fileName);
            return fullName.ToString();
        }

        /*
         * 
         * */
        private Object CreateInstanceFromSelectedNode()
        {
            return null;
        }

        private void m_tmsi_delete_Click(object sender, EventArgs e)
        {
            if (m_tv_Items.SelectedNode == null || m_tv_Items.SelectedNode.Parent == null) return;
            
            if (System.IO.File.Exists(this.GetSelectedFullName()))
            {
                System.IO.File.Delete(this.GetSelectedFullName());
            }

            m_tv_Items.Nodes.Remove(m_tv_Items.SelectedNode);

            m_dgv_ItemDetail.Rows.Clear();
        }
    }
}
