using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using global::ProtoBuf;
using System.Windows.Forms;
using System.Reflection;
using GemBox.Spreadsheet;
using System.Diagnostics;
using System.Text.RegularExpressions;
using GemBox.Spreadsheet.WinFormsUtilities;

namespace TemplateEditor
{
    public partial class TaskManager : Form
    {

        public StringBuilder m_Task = new StringBuilder();

        public String m_TaskName = "Task.tkt";
        public String m_TaskCsvName = "Task.csv";

        private String[] m_Base64Array = new String[] { "Base64_Name", "Base64_DelvTaskTalk", "Base64_ResetTaskTalk", "Base64_UnqualifiedTalk", "Base64_TimeLimitTalk",
                                        "Base64_DelvItemTalk", "Base64_ExeTalk", "Base64_AwardTalk", "Base64_TaskNPCTalk", "Base64_Text"};

        public TaskManager()
        {
            //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            InitializeComponent();
        }

        private void TaskManager_Load(object sender, EventArgs e)
        {
            //PrintColumnText(new PB.Task());
        }

        private void PrintColumnText(System.Object configObj)
        {
            PropertyInfo[] properties = configObj.GetType().GetProperties();

            foreach (PropertyInfo pi in properties)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = pi.Name.ToString();

                this.m_dgv_ItemDetail.Columns.Add(column);
            }
        }

        private void m_B_Export_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(this.m_TaskCsvName))
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
                ef.Save(this.m_TaskCsvName, CsvSaveOptions.CsvDefault);

                Process.Start("Excel.exe", this.m_TaskCsvName);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("文件保存失败 : " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void Import()
        {
            try
            {
                m_dgv_ItemDetail.Rows.Clear();
                m_dgv_ItemDetail.Columns.Clear();

                ExcelFile ef = ExcelFile.Load(this.m_TaskCsvName);

                DataGridView dgv = new DataGridView();
                DataGridViewConverter.ExportToDataGridView(ef.Worksheets.ActiveWorksheet, dgv, new ExportToDataGridViewOptions() { ColumnHeaders = true });

                //PrintColumnText(new PB.Task());

                for (int row_index = 0; row_index < dgv.Rows.Count - 1; ++row_index) //Default datagridview has 1 record
                {
                    int new_index = this.m_dgv_ItemDetail.Rows.Add();  
                    for (int column_index = 0; column_index < dgv.Rows[row_index].Cells.Count; ++column_index )
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

        private void m_B_Save_Click(object sender, EventArgs e)
        {
            this.Import();

            StringBuilder taskFile = new StringBuilder();

            StreamReader sr = new StreamReader(m_TaskName, Encoding.Default);

            Regex regex = new Regex("(?<key>[^:]+): (?<value>.+)");
            /*
            PB.Task task = new PB.Task();
            for (int index = 0; index < this.m_dgv_ItemDetail.Rows.Count; ++index)
            {
                int property_index = 0;

                foreach (PropertyInfo pi in task.GetType().GetProperties())
                {
                    String name = pi.Name.ToString();
                    String objValue = this.m_dgv_ItemDetail.Rows[index].Cells[property_index++].Value.ToString();

                    StreamWriter sw = null;

                    if (m_Base64Array.Contains(name))
                    {
                        byte[] bytes = Encoding.GetEncoding("GB2312").GetBytes(objValue);
                        objValue = Convert.ToBase64String(bytes);
                    }

                    if (name == "path")
                    {
                        sw = new StreamWriter(objValue, false);
                    }

                    while ((line = sr.ReadLine()) != null)
                    {
                        Match match = regex.Match(line.ToString());

                        if (match.Success)
                        {
                            String key = match.Groups["key"].Value.ToString();
                            String value = match.Groups["value"].Value.ToString();

                            if (m_Base64Array.Contains(key))
                            {
                                byte[] bytes = Convert.FromBase64String(value);
                                String deco = Encoding.GetEncoding("Utf-16").GetString(bytes);
                            }

                            if (name != key)
                            {
                                sw.WriteLine(line);
                            }
                            else
                            {
                                sw.WriteLine(name + ": " + objValue);
                            }
                        }
                        else
                        {
                            sw.WriteLine(line);
                        }
                    }

                    if (sw != null) sw.Close();
                }
             
            }
            * */

        }

        private void m_B_Import_Click(object sender, EventArgs e)
        {
            this.Import();
        }

    }
}
