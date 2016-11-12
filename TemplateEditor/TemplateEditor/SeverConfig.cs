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
using GemBox.Spreadsheet;
using GemBox.Spreadsheet.WinFormsUtilities;
using System.Diagnostics;
using SharpSvn;
using System.Collections;
using System.Threading;

namespace TemplateEditor
{
    public partial class ServerConfig : Form
    {
        /*
        * Global variable 
        * */

        private List<string> m_OperatorFiles = null;

        public int m_NestingCount = 0;
        public int m_PropertyIndex = 0;

        private bool m_OnNesting = true;

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
        public ServerConfig()
        {
            //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            SpreadsheetInfo.SetLicense("EQU2-1000-0000-000U");
            InitializeComponent();
            m_OperatorFiles = new List<string>(){ GetCurrentBinFile(), GetCurrentCsvFile(), GetCurrentLuaFile() };
        }
        /*
        * Load resource 
        * */
        private void DataCreate_Load(object sender, EventArgs e)
        {
            LoadBinFile();
        }
        /*
        * Search files 
        * */
        public void LoadBinFile()
        {
            try
            {
                m_tv_Items.Nodes.Clear();
                DirectoryInfo dirs = new DirectoryInfo(MainPage.m_ServerConfigPath);
                foreach (FileInfo dir in dirs.GetFiles())
                {
                    if (dir.Attributes == FileAttributes.Hidden) continue;
                    
                    FileInfo file = new FileInfo(dir.FullName);

                    if (file.Exists)
                    {
                        if (Path.GetExtension(file.Name.ToString()) != "") continue;
                        
                        TreeNode node = new TreeNode(dir.Name);
                        System.Collections.ObjectModel.Collection<SvnStatusEventArgs> statuses;
                        String path = new StringBuilder(MainPage.m_ServerConfigPath).Append(dir.Name).ToString();
                        SVNMgr.GetStatus(path, out statuses);
                        
                        foreach (SvnStatusEventArgs status in statuses)
                        {
                            if (status.Wedged || status.Modified || (status.LocalLock != null && status.LocalLock.Comment != ""))
                            {
                                node.ImageIndex = 0;
                                node.SelectedImageIndex = 0;
                            }
                        }

                        m_tv_Items.Nodes.Add(node);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载文件失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }
 
        private void m_tv_Items_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {   
                m_cms_Operators.Show(); 
            }
        }
        
        private void PrintColumnText(System.Object configObj, int nest = 0)
        {
            var properties = configObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OrderBy(x => x.MetadataToken);

            foreach (PropertyInfo pi in properties)
            {
                string typeName = pi.PropertyType.ToString();
                if (pi.Name.ToString() == "type_t") continue;

                String fullName = pi.PropertyType.FullName;
                String baseName = pi.PropertyType.BaseType.ToString();

                if (typeName.IndexOf("PB.") != -1 && baseName.IndexOf("System.Enum") == -1)     // Protocol buffer message ...
                {
                    if (fullName.IndexOf("System.Collections.Generic.List") != -1)      // Repeated message items ...
                    {
                        Object countObject = System.Activator.CreateInstance(configObj.GetType());  //采用default值，防止策划配置错误
                        int count = GetRepeatedCount(countObject, pi);

                        String stuff = fullName.Substring(fullName.IndexOf("[[") + 2, fullName.IndexOf(",") - fullName.IndexOf("[[") - 2);

                        for (int i = 0; i < count; ++i)
                        {
                            System.Object subObj = System.Activator.CreateInstance(MainPage.GetAssembly().GetType(stuff));
                            PrintColumnText(subObj, i + 1);
                        }
                    }
                    else
                    {
                        System.Object subObj = System.Activator.CreateInstance(MainPage.GetAssembly().GetType(typeName));
                        PrintColumnText(subObj);
                    }
                }
                else if (fullName.IndexOf("System.Collections.Generic.List") != -1)     // Repeated basic items ...
                {
                    Object countObject = System.Activator.CreateInstance(configObj.GetType());  //采用default值，防止策划配置错误
                    int count = GetRepeatedCount(countObject, pi);

                    for (int i = 0; i < count; ++i)
                    {
                        DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                        if (nest > 0)
                        {
                            String headerText = String.Format("[{0}]-[{1}]", nest, i + 1);
                            column.HeaderText = new StringBuilder(headerText).Append(pi.Name.ToString()).ToString();
                        }
                        else
                        {
                            String headerText = String.Format("[{0}]", i + 1);
                            column.HeaderText = new StringBuilder(headerText).Append(pi.Name.ToString()).ToString();
                        }
                        this.m_dgv_ItemDetail.Columns.Add(column);
                    }
                }
                else
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    if (nest > 0)
                    {
                        String headerText = String.Format("[{0}]", nest);
                        column.HeaderText = new StringBuilder(headerText).Append(pi.Name.ToString()).ToString();
                    }
                    else
                    {
                        column.HeaderText = pi.Name.ToString();
                    }
                    this.m_dgv_ItemDetail.Columns.Add(column);
                }
            }            
        }

        private void m_tv_Items_DoubleClick(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(OpenMessage));
            thread.Start();
        }

        private bool CheckMessage(System.Type typeName)
        {
            if (typeName == null)
            {
                return false;
            }

            Object configObj = System.Activator.CreateInstance(typeName);

            if (configObj.GetType().GetProperty("type_t") == null)
            {
                MessageBox.Show("非法的模板项： " + typeName + " ，请联系对应的服务器程序，告诉他没有定义其中的 [type_t] 变量.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            else if (configObj.GetType().GetProperty("version") == null)
            {
                MessageBox.Show("非法的模板项： " + typeName + " ，请联系对应的服务器程序，告诉他没有定义其中的 [version] 变量.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            else if (configObj.GetType().GetProperty("index") == null)
            {
                MessageBox.Show("非法的模板项： " + typeName + " ，请联系对应的服务器程序，告诉他没有定义其中的 [index] 变量.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            else if (configObj.GetType().GetProperty("comments") == null)
            {
                MessageBox.Show("非法的模板项： " + typeName + " ，请联系对应的服务器程序，告诉他没有定义其中的 [comments] 变量.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void OpenMessage()
        {
            m_tv_Items.Invoke((EventHandler)delegate { 

            m_dgv_ItemDetail.Rows.Clear();
            m_dgv_ItemDetail.Columns.Clear();

            String itemName = GetSelectedFileWithoutExtension();
            if (itemName == null) return;

            System.Type typeName = MainPage.GetMessage(itemName);

            try
            {
                PrintColumnText(System.Activator.CreateInstance(typeName));

                FileStream file = System.IO.File.OpenRead(this.GetSelectedFileFullName());

                if (file.Length == 0)
                {
                    file.Close();
                    return;
                }

                byte[] data = new byte[file.Length];
                file.Read(data, 0, data.Length);
                file.Close();

                ByteBuffer buffer = new ByteBuffer(data);

                while (!buffer.IsTail())
                {
                    buffer.ReadInt();
                    this.m_PropertyIndex = 0;
                    System.Object configObj = ProtoBuf.Serializer.NonGeneric.Deserialize(typeName, new MemoryStream(buffer.ReadBytes()));
                    int row_index = this.m_dgv_ItemDetail.Rows.Add();
                    PrintProperty(configObj, row_index);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            });
        }

        private void PrintProperty(System.Object configObj, int index = 0)
        {
            var properties = configObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OrderBy(x => x.MetadataToken);

            foreach (PropertyInfo pi in properties)
            {
                if (pi.Name.ToString() == "type_t") continue;

                String fullName = pi.PropertyType.FullName;
                String baseName = pi.PropertyType.BaseType.ToString();

                if (fullName.IndexOf("PB.") != -1 && baseName.IndexOf("System.Enum") == -1)
                {
                    if (pi.PropertyType.ToString().IndexOf("System.Collections.Generic.List") != -1)
                    {
                        Object countObject = System.Activator.CreateInstance(configObj.GetType());  //采用default值，防止策划配置错误
                        int count = GetRepeatedCount(countObject, pi);

                        System.Object subObj = pi.GetValue(configObj, null);
                        String stuff = fullName.Substring(fullName.IndexOf("[[") + 2, fullName.IndexOf(",") - fullName.IndexOf("[[") - 2);
                        System.Collections.IList list = (System.Collections.IList)subObj;

                        for (int i = 0; i < count; ++i)
                        {
                            if (i < list.Count)
                            {
                                PrintProperty(list[i], index);
                            }
                            else
                            {
                                System.Object subObj_ = System.Activator.CreateInstance(MainPage.GetAssembly().GetType(stuff));
                                PrintProperty(subObj_, index);
                                //this.m_PropertyIndex++;
                            }
                        }

                        this.m_PropertyIndex--;     // For end of this function, there is : this.m_PropertyIndex++;
                    }
                    else
                    {
                        System.Object subObj = pi.GetValue(configObj, null);
                        if (subObj == null)
                            subObj = System.Activator.CreateInstance(MainPage.GetAssembly().GetType(pi.PropertyType.ToString()));  //这种是新增的结构体，上来是null

                        PrintProperty(subObj, index);

                        this.m_PropertyIndex--;     // For end of this function, there is : this.m_PropertyIndex++;
                    }
                }
                else if (fullName.IndexOf("System.Collections.Generic.List") != -1)
                {
                    Object countObject = System.Activator.CreateInstance(configObj.GetType());  //采用default值，防止策划配置错误
                    int count = GetRepeatedCount(countObject, pi);

                    System.Object subObj = pi.GetValue(configObj, null);

                    System.Collections.IList list = (System.Collections.IList)subObj;

                    for (int i = 0; i < count; ++i)
                    {
                        if (i < list.Count)
                            this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex++].Value = list[i];
                        else
                            this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex++].Value = "";
                    }

                    this.m_PropertyIndex--;     // For end of this function, there is : this.m_PropertyIndex++;
                }
                else
                {
                    this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex].ReadOnly = true;

                    if (pi.PropertyType.ToString().IndexOf("System.Byte[]") >= 0)
                    {
                        String value_ = "";
                        if (pi.GetValue(configObj, null) != null)
                            value_ = Encoding.Default.GetString((Byte[])pi.GetValue(configObj, null));
                        this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex].Value = value_;
                    }
                    else
                    {
                        this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex].Value = pi.GetValue(configObj, null).ToString();
                    }
                }

                this.m_PropertyIndex++;
            }
        }

        public static bool IsUtf8(string filename)
        {
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
                file.Close();
            }

            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return true;

            return false;
        }

        public void m_BImport_Click(object sender, EventArgs e)
        {
            this.Import();
        }

        public void Import()
        {
            try
            {
                m_dgv_ItemDetail.Rows.Clear();
                m_dgv_ItemDetail.Columns.Clear();

                String path = this.GetCurrentCsvFile();

                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);

                if (!IsUtf8(path))
                {
                    System.Text.Encoding gb2312 = System.Text.Encoding.GetEncoding("GB2312");
                    System.Text.Encoding utf8 = System.Text.Encoding.GetEncoding("UTF-8");

                    byte[] data = new byte[file.Length];

                    file.Read(data, 0, data.Length);

                    data = Encoding.Convert(gb2312, utf8, data);

                    String content = utf8.GetString(data);

                    path = "ELEMENT.csv";
                    StreamWriter sw = new StreamWriter(path, false);
                    sw.Write(content);
                    sw.Close();
                }

                file.Close();

                ExcelFile ef = ExcelFile.Load(path);

                DataGridView dgv = new DataGridView();
                DataGridViewConverter.ExportToDataGridView(ef.Worksheets.ActiveWorksheet, dgv, new ExportToDataGridViewOptions() { ColumnHeaders = true });

                String itemName = GetSelectedFileWithoutExtension();
                if (itemName == null) return;

                System.Type typeName = MainPage.GetMessage(itemName);
                if (typeName == null) return;

                PrintColumnText(System.Activator.CreateInstance(typeName));

                int excel_count = dgv.ColumnCount;
                int bin_count = this.m_dgv_ItemDetail.ColumnCount;

                //表头严格检查
                String alter = "1.如果新增字段，按照顺序递增，需要双击编辑器中左侧列表中的【" + itemName.ToString() + "】，打开后点击【导出到CSV文件】，然后刷表编辑;\r\n\r\n" +
                "2.如果新增字段，改变了之前顺序(变量顺序或变量索引)，需要策划自行根据字段顺序调整CSV文件数据(非常不建议程序或者策划有如此之大修改，建议联系程序确认是否调整或者删除原配置顺序);\r\n\r\n" + 
                "3.上面两种之外问题，请联系程序确认解决，更多详细使用方法请查看工具栏【关于】->【帮助】文档。感谢使用。";

                if (excel_count != bin_count)
                {
                    MessageBox.Show(String.Format("      文件【{0}】检查失败，Excel中存储的数据字段个数为【{1}】个，而数据结构中的字段个数为【{2}】个，无法匹配。请确认是否修改了配置文件:\r\n\r\n" + alter, itemName.ToString(), excel_count, bin_count), 
                        "系统提示：请按照指引操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    return;
                }

                for (int i = 0; i < bin_count; ++i)
                {
                    String bin_text = this.m_dgv_ItemDetail.Columns[i].HeaderText;
                    String excel_text = dgv.Columns[i].HeaderText;
                    if (bin_text != excel_text)
                    {
                        MessageBox.Show(String.Format("      文件【{0}】检查失败，Excel中存储的数据字段与数据结构中的字段内容无法匹配，错误字段：Excel中【{1}】-配置文件中【{2}】。请确认是否修改了配置文件:\r\n\r\n" + alter, itemName.ToString(), excel_text, bin_text),
                        "系统提示：请按照指引操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }
                }

                //加载数据
                for (int row_index = 0; row_index < dgv.Rows.Count - 1; ++row_index) //Default datagridview has 1 record
                {
                    int new_index = this.m_dgv_ItemDetail.Rows.Add();
                    for (int column_index = 0; column_index < dgv.Rows[row_index].Cells.Count; ++column_index)
                    {
                        this.m_dgv_ItemDetail.Rows[new_index].Cells[column_index].Value = dgv.Rows[row_index].Cells[column_index].Value;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件导入失败:" + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        public void m_BExport_Click(object sender, EventArgs e)
        {
            if (this.m_dgv_ItemDetail.Rows.Count <= 0 && this.m_dgv_ItemDetail.ColumnCount <= 0)
            {
                MessageBox.Show("请选择您要打开的模板项，然后再进行导出。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return;
            }

            String path = this.GetCurrentCsvFile();

            if (System.IO.File.Exists(path))
            {
                if (MessageBox.Show("文件已经存在，是否覆盖?", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.Cancel)
                {
                    return;
                }
            }

            ExcelFile ef = new ExcelFile();
            ExcelWorksheet ws = ef.Worksheets.Add("Mrg");
            
            try
            {
                DataGridViewConverter.ImportFromDataGridView(ws, this.m_dgv_ItemDetail, new ImportFromDataGridViewOptions() { ColumnHeaders = true });
                ef.Save(path, CsvSaveOptions.CsvDefault);

                Process.Start("Excel.exe", path);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件保存失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);	
            }

        }

        private int GetRepeatedCount(Object configObj, PropertyInfo pi)
        {
            PropertyInfo size_property = configObj.GetType().GetProperty(pi.Name.ToString() + "_count");
            String value = size_property.GetValue(configObj, null).ToString();
            try
            {
                int count = 0;
                Int32.TryParse(value, out count);
                return count;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件保存失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            return -1;
        }

        public void m_BSave_Click(object sender, EventArgs e)
        {
            if (this.SaveFile())
            {
                MessageBox.Show("保存成功。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存失败。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private bool SaveProperty(System.Object configObj, int index)
        {
            try
            {
                var properties = configObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OrderBy(x => x.MetadataToken);

                foreach (PropertyInfo pi in properties)
                {
                    if (pi.Name.ToString() == "type_t") continue;

                    Object objValue = this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex].Value;
                    String baseName = pi.PropertyType.BaseType.ToString();
                    String ptName = pi.PropertyType.Name.ToString();

                    if (objValue == null)       //策划没有配置数据
                    {
                        if (pi.PropertyType.ToString().IndexOf("System.Collections.Generic.List`1[System.String]") != -1)
                        {
                            objValue = "";      //如果repeated里面是string类型，则要手动初始化
                        }
                        else if (pi.PropertyType.ToString().IndexOf("System.Collections.Generic.List`1[System.Int32]") != -1)
                        {
                            objValue = 0;      //如果repeated里面是int类型，则要手动初始化
                        }
                        else if (ptName == "Int32" || ptName == "UInt32" || ptName == "Int64" || ptName == "UInt64" || ptName == "Single")
                        {
                            objValue = 0;
                        }
                        else if (ptName == "List`1")
                        {
                            MessageBox.Show(String.Format("文件保存失败 : 【{0}】不能为空.", this.m_dgv_ItemDetail.Columns[this.m_PropertyIndex].HeaderText), "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return false;
                        }
                        else
                        {
                            this.m_PropertyIndex++;
                            continue;
                        }
                    }

                    String value = objValue.ToString();

                    if (ptName == "String")
                    {
                        pi.SetValue(configObj, value, null);
                    }
                    else if (ptName == "Byte[]")
                    {
                        Byte[] result = Encoding.Default.GetBytes(value);
                        pi.SetValue(configObj, result, null);
                    }
                    else if (ptName == "Int32")
                    {
                        Int32 result = 0;
                        bool success = Int32.TryParse(value, out result);
                        if (success) pi.SetValue(configObj, result, null);
                    }
                    else if (ptName == "UInt32")
                    {
                        UInt32 result = 0;
                        bool success = UInt32.TryParse(value, out result);
                        if (success) pi.SetValue(configObj, result, null);
                    }
                    else if (ptName == "Int64")
                    {
                        Int64 result = 0;
                        bool success = Int64.TryParse(value, out result);
                        if (success) pi.SetValue(configObj, result, null);
                    }
                    else if (ptName == "UInt64")
                    {
                        UInt64 result = 0;
                        bool success = UInt64.TryParse(value, out result);
                        if (success) pi.SetValue(configObj, result, null);
                    }
                    else if (ptName == "Single")
                    {
                        float result = 0;
                        bool success = float.TryParse(value, out result);
                        if (success) pi.SetValue(configObj, result, null);
                    }
                    else if (pi.PropertyType.ToString().IndexOf("PB.") != -1 && baseName.IndexOf("System.Enum") == -1)
                    {
                        if (pi.PropertyType.ToString().IndexOf("System.Collections.Generic.List") != -1)
                        {
                            Object countObject = System.Activator.CreateInstance(configObj.GetType());  //采用default值，防止策划配置错误
                            int count = GetRepeatedCount(countObject, pi);

                            int used_count = GetRepeatedCount(configObj, pi);   //策划实际配置的数组大小

                            if (used_count > count)
                            {
                                MessageBox.Show(String.Format("变量[{0}]允许配置的大小为：{1}，而您配置的大小为：{2}，请与程序对齐其实际使用范围.", pi.Name, count, used_count), "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                return false;
                            }

                            String fullName = pi.PropertyType.FullName;
                            String stuff = fullName.Substring(fullName.IndexOf("[[") + 2, fullName.IndexOf(",") - fullName.IndexOf("[[") - 2);
                            Object instance = Activator.CreateInstance(pi.PropertyType);
                            System.Collections.IList list = (System.Collections.IList)instance;

                            for (int i = 0; i < count; ++i)
                            {
                                System.Object subObj = System.Activator.CreateInstance(MainPage.GetAssembly().GetType(stuff));

                                if (!SaveProperty(subObj, index)) return false;

                                list.Add(subObj);
                            }

                            this.m_PropertyIndex--;     // For end of this function, there is : this.m_PropertyIndex++;

                            pi.SetValue(configObj, list, null);
                        }
                        else
                        {
                            Object subObj = Activator.CreateInstance(pi.PropertyType);

                            if (!SaveProperty(subObj, index)) return false;

                            this.m_PropertyIndex--;     // For end of this function, there is : this.m_PropertyIndex++;

                            pi.SetValue(configObj, subObj, null);
                        }
                    }
                    else if (pi.PropertyType.ToString().IndexOf("System.Collections.Generic.List") != -1)
                    {
                        Object countObject = System.Activator.CreateInstance(configObj.GetType());  //采用default值，防止策划配置错误
                        int count = GetRepeatedCount(countObject, pi);

                        int used_count = GetRepeatedCount(configObj, pi);   //策划实际配置的数组大小

                        if (used_count > count)
                        {
                            MessageBox.Show(String.Format("变量{0}允许配置的大小为：{1}，而您配置的大小为：{2}，请与程序对齐实际使用范围.", pi.Name, count, used_count), "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return false;
                        }

                        String fullName = pi.PropertyType.FullName;

                        String stuff = fullName.Substring(fullName.IndexOf("[[") + 2, fullName.IndexOf(",") - fullName.IndexOf("[[") - 2);
                        Object instance = Activator.CreateInstance(pi.PropertyType);

                        System.Collections.IList list = (System.Collections.IList)instance;

                        for (int i = 0; i < count; ++i)     
                        {
                            Object subValue_ = this.m_dgv_ItemDetail.Rows[index].Cells[this.m_PropertyIndex++].Value;

                            if (subValue_ == null)       //策划没有配置数据
                            {
                                if (stuff == "System.Int32")
                                {
                                    subValue_ = 0;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            String subStringValue_ = subValue_.ToString();

                            if (stuff == "System.String")
                            {
                                list.Add(subStringValue_);
                            }
                            else if (stuff == "System.Byte[]")
                            {
                                Byte[] value_ = Encoding.Default.GetBytes(subStringValue_);
                                list.Add(value_);
                            }
                            else
                            {
                                Int32 result = 0;
                                Int32.TryParse(subStringValue_, out result);
                                list.Add(result);
                            }
                        }

                        this.m_PropertyIndex--;     // For end of this function, there is : this.m_PropertyIndex++;

                        pi.SetValue(configObj, list, null);
                    }
                    else
                    {
                        System.Type type = MainPage.GetAssembly().GetType(pi.PropertyType.ToString());

                        if (type.BaseType.ToString().IndexOf("System.Enum") >= 0)
                        {
                            int result = Enum.Parse(type, value).GetHashCode();
                            pi.SetValue(configObj, result, null);
                        }
                    }

                    this.m_PropertyIndex++;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件保存失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public bool SaveToLua(System.Object configObj, StreamWriter sw)
        {
            if (this.m_OnNesting)
            {
                this.m_NestingCount++;
            }

            sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount).Append("{").ToString());

            var properties = configObj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).OrderBy(x => x.MetadataToken);

            foreach (PropertyInfo pi in properties)
            {
                String value = "";
                if (pi.GetValue(configObj, null) != null)
                    value = pi.GetValue(configObj, null).ToString();

                System.Type type = MainPage.GetAssembly().GetType(pi.PropertyType.ToString());

                String fullName = pi.PropertyType.FullName;
                String ptName = pi.PropertyType.Name.ToString();

                if ((type != null && type.BaseType.ToString().IndexOf("System.Enum") >= 0) || (ptName == "String"))
                {
                    sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append(pi.Name.ToString()).Append(" = \"").Append(value).Append("\",").ToString());
                }
                else if (ptName == "Byte[]")
                {
                    String value_ = "";
                    if (pi.GetValue(configObj, null) != null)
                        value_ = Encoding.Default.GetString((Byte[])pi.GetValue(configObj, null));
                    sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append(pi.Name.ToString()).Append(" = \"").Append(value_).Append("\",").ToString());
                }
                else if (pi.PropertyType.ToString().IndexOf("PB.") != -1)
                {
                    if (fullName.IndexOf("System.Collections.Generic.List") != -1)
                    {
                        System.Object subObj = pi.GetValue(configObj, null);

                        System.Collections.IList list = (System.Collections.IList)subObj;

                        sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append(pi.Name.ToString()).Append(" = {").ToString());

                        this.m_OnNesting = false;

                        this.m_NestingCount = this.m_NestingCount + 2;

                        for (int i = 0; i < list.Count; ++i)
                        {
                            SaveToLua(list[i], sw);
                        }

                        this.m_NestingCount = this.m_NestingCount - 2;

                        this.m_OnNesting = true;

                        sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append("},").ToString());
                    }
                    else
                    {
                        sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append(pi.Name.ToString()).Append(" = ").ToString());

                        System.Object subObj = pi.GetValue(configObj, null);
                        SaveToLua(subObj, sw);

                        this.m_NestingCount = this.m_NestingCount - 1;

                        sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).ToString());
                    }
                }
                else if (pi.PropertyType.ToString().IndexOf("System.Collections.Generic.List") != -1)
                {
                    System.Object instance = pi.GetValue(configObj, null);
                    System.Collections.IList list = (System.Collections.IList)instance;

                    sw.Write(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append(pi.Name.ToString()).Append(" = {").ToString());

                    for (int i = 0; i < list.Count; ++i)
                    {
                        if (list[i].GetType().Name.ToString() == "Byte[]")
                        {
                            String value_ = Encoding.Default.GetString((Byte[])list[i]);
                            sw.Write(new StringBuilder().Append(value_).Append(",").ToString());
                        }
                        else
                        {
                            sw.Write(new StringBuilder().Append(list[i]).Append(",").ToString());
                        }
                    }
                    sw.WriteLine(new StringBuilder().Append("},").ToString());
                }
                else
                {
                    sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount + 1).Append(pi.Name.ToString()).Append(" = ").Append(value).Append(",").ToString());
                }
            }

            sw.WriteLine(new StringBuilder().Append('\t', this.m_NestingCount).Append("},").ToString());

            return true;
        }

        public bool SaveFile()
        {
            if (this.m_dgv_ItemDetail.Rows.Count <= 0)
            {
                MessageBox.Show("文件保存失败 : 如果要保存配置，请点击【从CSV导入】，确保数据正常显示在界面.", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }

            bool has_error = false;

            String itemName = GetSelectedFileWithoutExtension();
            if (itemName == null) return false;

            System.Type typeName = MainPage.GetMessage(itemName);
            if (typeName == null) return false;

            try
            {
                StreamWriter alterWriter = new StreamWriter("Alter.txt", false);
                alterWriter.WriteLine("以下是系统检测到配置版本覆盖GLOBAL版本的数据，这是由于您配置了多版本数据，请确认配置是否需要同步或更新。如果已经知晓请忽略。\r\n");

                Dictionary<int, Object> dics = new Dictionary<int, Object>();
                for (int index = 0; index < this.m_dgv_ItemDetail.Rows.Count; ++index)
                {
                    this.m_PropertyIndex = 0;
                    System.Object configObj = System.Activator.CreateInstance(typeName);

                    if (!SaveProperty(configObj, index)) return false;  //Create message...
                    
                    //Version check
                    PropertyInfo versionProperty = configObj.GetType().GetProperty("version");
                    String versionString = versionProperty.GetValue(configObj, null).ToString();
                    System.Type type = MainPage.GetAssembly().GetType("PB.Version");
                    int version = Enum.Parse(type, versionString).GetHashCode();
                    if (versionString != "GLOBAL" && !MainPage.m_ConfigPath.version.Contains(version))
                    {
                        continue;
                    }

                    //Index check
                    PropertyInfo indexProperty = configObj.GetType().GetProperty("index");
                    String indexString = indexProperty.GetValue(configObj, null).ToString();
                    int _index = 0;
                    Int32.TryParse(indexString, out _index);
                    if (dics.ContainsKey(_index) && versionString == "GLOBAL")   //即：非GLOBAL可以覆盖GLOBAL，GLOBAL不可以覆盖非GLOBAL
                    {
                        continue;
                    }

                    if (dics.ContainsKey(_index))
                    {
                        dics[_index] = configObj;
                        //MessageBox.Show("保存失败：系统检测出重复索引 : [" + _index + "], 这是由于您配置了多个国家版本，请确认配置后重新保存。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        String alter = String.Format(" 配置[{0}] 版本[{1}] 索引[{2}]", itemName, versionString, _index);
                        alterWriter.WriteLine(alter);
                        has_error = true;
                        //return false;
                    }
                    else
                    {
                        dics.Add(_index, configObj);
                    }
                }

                //写入文件
                FileStream binFile = new FileStream(this.GetCurrentBinFile(), FileMode.Truncate, FileAccess.Write);
                StreamWriter swLua = new StreamWriter(this.GetCurrentLuaFile(), false);

                swLua.WriteLine("--Generated by tools. Do not edit it!\r\n");
                swLua.WriteLine("local templates = {\r\n");

                ByteBuffer bf = new ByteBuffer();

                foreach (var ele in dics)
                {
                    this.m_NestingCount = 0;

                    if (!SaveToLua(ele.Value, swLua)) return false;     //Client...
                    swLua.WriteLine("");

                    byte[] content = ProtoUtil.Serialize(ele.Value);    //Sever...
                    bf.WriteInt(content.Length);
                    bf.WriteBytes(content);
                }

                binFile.Write(bf.ToBytes(), 0, bf.ToBytes().Length);
                binFile.Close();

                swLua.WriteLine("}\r\n");   
                swLua.WriteLine("return templates");
                swLua.Close();

                alterWriter.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件保存失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                return false;
            }

            //StreamReader alterReader = new StreamReader("Alter.txt");
            //String line = alterReader.ReadToEnd();
            if (System.IO.File.Exists("Alter.txt") && has_error)
                Process.Start("notepad.exe", "Alter.txt");

            return true;
        }

        private String GetSelectedFileFullName()        
        {
            if (m_tv_Items.SelectedNode == null) return null;
            String fileName = m_tv_Items.SelectedNode.Text.ToString();
            return new StringBuilder().Append(MainPage.m_ServerConfigPath).Append(fileName).ToString();
        }

        public String GetCurrentBinFile()
        {
            return GetSelectedFileFullName();
        }

        public String GetCurrentCsvFile()
        {
            return new StringBuilder(GetSelectedFileFullName()).Append(".csv").ToString();
        }

        public String GetCurrentLuaFile()
        {
            if (m_tv_Items.SelectedNode == null) return null;
            String fileName = m_tv_Items.SelectedNode.Text.ToString();
            return new StringBuilder().Append(MainPage.m_ClientConfigPath).Append(fileName).Append(".lua").ToString();
        }

        public String GetSelectedFileWithoutExtension()
        {
            if (m_tv_Items.SelectedNode == null) return null;
            String fileName = m_tv_Items.SelectedNode.Text.ToString();
            return Path.GetFileNameWithoutExtension(fileName);
        }

        private void m_tmsi_new_Click(object sender, EventArgs e)
        {
            AddItem addItem = new AddItem();
            try
            {
                if (addItem.ShowDialog() == DialogResult.OK)
                {
                    String itemName = addItem.m_tb_Name.Text.ToString();
                    System.Type typeName = MainPage.GetMessage(itemName);
                    if (typeName == null)
                    {
                        MessageBox.Show("请填写正确的配置类型", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        return;
                    }

                    if (!CheckMessage(typeName)) return;

                    String path = new StringBuilder(itemName).ToString();
                    this.m_tv_Items.Nodes.Add(path);
                    
                    String binFile = new StringBuilder(MainPage.m_ServerConfigPath).Append(itemName).ToString();
                    System.IO.File.Create(binFile).Close();
                    SVNMgr.Add(binFile);

                    String csvFile = new StringBuilder(MainPage.m_ServerConfigPath).Append(itemName).Append(".csv").ToString();
                    System.IO.File.Create(csvFile).Close();
                    SVNMgr.Add(csvFile);

                    String luaFile = new StringBuilder(MainPage.m_ClientConfigPath).Append(itemName).Append(".lua").ToString();
                    System.IO.File.Create(luaFile).Close();
                    SVNMgr.Add(luaFile); 
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("创建配置失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void m_tsmi_Save_Click(object sender, EventArgs e)
        {
            if (this.SaveFile())
            {
                MessageBox.Show("保存成功。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存失败。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void m_tmsi_delete_Click(object sender, EventArgs e)
        {
            if (m_tv_Items.SelectedNode == null) return;

            if (System.IO.File.Exists(this.GetSelectedFileFullName()))
            {
                System.IO.File.Delete(this.GetSelectedFileFullName());
            }

            m_tv_Items.Nodes.Remove(m_tv_Items.SelectedNode);
            m_dgv_ItemDetail.Rows.Clear();

            UriBuilder uri = new UriBuilder();
            SVNMgr.Remove(uri.Uri);
        }

        private void m_tmsi_update_Click(object sender, EventArgs e)
        {
            SVNMgr.Update(Directory.GetCurrentDirectory());
        }

        private void m_tmsi_lock_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = SVNMgr.Lock(this.m_OperatorFiles, "Lock Files...");
                
                if (result)
                {
                    this.m_tv_Items.SelectedNode.ImageIndex = 0;
                    this.m_tv_Items.SelectedNode.SelectedImageIndex = 0;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件加锁失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void m_tmsi_unlock_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = SVNMgr.Unlock(this.m_OperatorFiles);

                if (result)
                {
                    this.m_tv_Items.SelectedNode.ImageIndex = 1;
                    this.m_tv_Items.SelectedNode.SelectedImageIndex = 1;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件释放锁失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void m_tmsi_commit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.SaveFile()) return;

                SvnCommitResult result;
                CommitMessage messageDialog = new CommitMessage();

                if (messageDialog.ShowDialog() == DialogResult.OK)
                {
                    SvnCommitArgs ca = new SvnCommitArgs();
                    ca.LogMessage = messageDialog.m_tb_Log.Text.ToString();

                    if (SVNMgr.Commit(this.m_OperatorFiles, ca, out result))
                    {
                        MessageBox.Show("提交成功。", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                        this.m_tv_Items.SelectedNode.ImageIndex = 1;
                        this.m_tv_Items.SelectedNode.SelectedImageIndex = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件提交失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void m_BCreateBranch_Click(object sender, EventArgs e)
        {
            CreateBranch cb = new CreateBranch();

            if (cb.ShowDialog() == DialogResult.OK)
            {
                int count = this.m_dgv_ItemDetail.Rows.Count;
                for (int row_index = 0; row_index < count; ++row_index)
                {
                    String value = this.m_dgv_ItemDetail.Rows[row_index].Cells[1].Value.ToString();
                    if (cb.m_cb_From.Text.ToString() == value)
                    {
                        int new_index = this.m_dgv_ItemDetail.Rows.Add();   //AddCopy does not work...
                        for (int cell_index = 0; cell_index < this.m_dgv_ItemDetail.Rows[row_index].Cells.Count; ++cell_index)
                        {
                            this.m_dgv_ItemDetail.Rows[new_index].Cells[cell_index].Value = this.m_dgv_ItemDetail.Rows[row_index].Cells[cell_index].Value;
                            this.m_dgv_ItemDetail.Rows[new_index].Cells[1].Value = cb.m_cb_To.Text.ToString();
                        }
                    }
                }
            }

        }

        private void m_tmsi_open_Click(object sender, EventArgs e)
        {
            Process.Start("Excel.exe", this.GetCurrentCsvFile());
        }

        private void m_tv_Items_Click(object sender, EventArgs e)
        {
            m_OperatorFiles = new List<string>() { GetCurrentBinFile(), GetCurrentCsvFile(), GetCurrentLuaFile() };
        }

        private void m_dgv_ItemDetail_DoubleClick(object sender, EventArgs e)
        {
            ItemDetail item = new ItemDetail();
            item.m_Rows = this.m_dgv_ItemDetail.SelectedRows;
            item.m_Columns = this.m_dgv_ItemDetail.Columns;
            item.Show();
        }

        /*--------------------------------------------------------------------------------------------------------------------------------------------------*/

    }
}
