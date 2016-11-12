using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using SharpSvn;
using System.Windows.Forms;
using System.IO;

namespace TemplateEditor
{
    public class SVNMgr
    {
        private static SvnClient m_Client = new SvnClient();
        //private static SvnInfoEventArgs m_ServerAargs = null;
        //private static SvnInfoEventArgs m_ClientAargs = null;

        private static SvnUriTarget m_SvnUrl = null;
        //private static SvnPathTarget m_LocalPath = null;
        
        public SVNMgr()
        {   
            /*
            m_SvnUrl = new SvnUriTarget(MainPage.m_SvnPath);
            m_LocalPath = new SvnPathTarget(MainPage.m_TemplatePath);

            m_Client.GetInfo(m_SvnUrl, out m_ServerAargs);
            m_Client.GetInfo(m_LocalPath, out m_ClientAargs);
            
            m_Client.Authentication.ClearAuthenticationCache();
            m_Client.Authentication.Clear();
            m_Client.Authentication.DefaultCredentials = new System.Net.NetworkCredential(
                "zhenyunheng", "m9xm8vKZ", "http://10.236.100.8/doc/seven_data/trunk"
            );
             * */
        }

        public static bool Lock(String target, String comment)
        {
            try
            {
                return m_Client.Lock(target, comment);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("加锁失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        public static bool Lock(ICollection<string> targets, string comment)
        {
            try
            {
                return m_Client.Lock(targets, comment);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("加锁失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        public static bool UnLock(String target)
        {
            try
            {
                return m_Client.Unlock(target);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("释放锁失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        public static bool Unlock(ICollection<string> targets)
        {
            try
            {
                return m_Client.Unlock(targets);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("释放锁失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        public static bool Commit(String path, out SvnCommitResult result)
        {
            result = null;

            try
            {
                return m_Client.Commit(path, out result);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("提交失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        public static bool Commit(string path, SvnCommitArgs args, out SvnCommitResult result)
        {
            result = null;

            try
            {
                return m_Client.Commit(path, args, out result);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("提交失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        public static bool Commit(ICollection<string> paths, SvnCommitArgs args, out SvnCommitResult result)
        {
            result = null;

            try
            {
                return m_Client.Commit(paths, args, out result);
            }
            catch (SvnException ex)
            {
                MessageBox.Show("提交失败 ： " + ex.Message, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }

            return false;
        }

        public static bool GetStatus(String file, out System.Collections.ObjectModel.Collection<SvnStatusEventArgs> status)
        {
            return m_Client.GetStatus(file, out status);
        }

        public static bool Remove(Uri uri)
        {
            return m_Client.RemoteDelete(uri);
        }

        public static bool Add(String path)
        {
            return m_Client.Add(path);
        }

        public static bool Add(string path, SvnAddArgs args)
        {
            return m_Client.Add(path, args);
        }

        public static bool CheckOut(String file)
        {
            return m_Client.CheckOut(m_SvnUrl, "");
        }

        public static bool Update(String path)
        {
            return m_Client.Update(path);
        }

    }
}
