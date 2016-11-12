using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TemplateEditor
{
    class DataWriter
    {
        private static object LogLock = new object();
        
        public static void WriteText(String txt, String filePath = "Error.template")
        {            
            lock (LogLock)
            {
                try
                {
                    StreamWriter sw = new StreamWriter(filePath, true);
                    sw.Write(txt + "\r\n");
                    sw.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Alter", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }
            }                   
        }

    }
}
