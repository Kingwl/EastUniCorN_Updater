using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml;
using System.Diagnostics;
using System.Net;

namespace UniCorN_Updater
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public string StartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName); //获取启动目录的地址
        public string UpMode = "0";
        public string DownUrl = "";
        public string CheckUrl = "";
        public WebClient downclient = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
            XmlDocument localset = new XmlDocument();
            
            try
            {
                localset.Load(StartupPath + @"\upset.xml");
            }
            catch
            {
                MessageBox.Show("本地配置文件丢失，本程序将自动退出！");
                this.Close();
            }
            
            XmlNode localver = localset.SelectSingleNode("/setting/ver");
            XmlNode checkurl = localset.SelectSingleNode("/setting/checkurl");
            //****************************************************************************
            XmlDocument upset = new XmlDocument();
            try
            {
                upset.Load(checkurl.InnerText);
            }
            catch
            {
                MessageBox.Show("未能检测到更新配置文件，程序将自动退出！");
                this.Close();
            }
            XmlNode newver = upset.SelectSingleNode("/setting/ver");
            XmlNode downloadurl = upset.SelectSingleNode("/setting/downloadurl");
            XmlNode upmode = upset.SelectSingleNode("/setting/upmode");
            XmlNode more = upset.SelectSingleNode("/setting/more");
            //****************************************************************************
            try
            {
                if (localver.InnerText != newver.InnerText)
                {
                    MessageBox.Show("检测到新版本！");
                    LabelNew.Content = newver.InnerText;
                    LabelNow.Content = localver.InnerText;
                    TbxNewText.Text = more.InnerText;
                    UpMode = upmode.InnerText;
                    DownUrl = downloadurl.InnerText;
                    CheckUrl = checkurl.InnerText;
                }
                else if (localver.InnerText == newver.InnerText)
                {
                    MessageBox.Show("当前为最新版本！更新程序将自动退出！");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("配置异常，程序将自动退出！");
                this.Close();
            }

         }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            
            TbxNewText.Text = TbxNewText.Text + "\r开始更新……";
            System.Windows.Forms.Application.DoEvents();
            if (UpMode == "0")
            {
                TbxNewText.Text = TbxNewText.Text + "\r下载更新文件……";
                System.Windows.Forms.Application.DoEvents();

                WebClient checkclient = new WebClient();
                checkclient.DownloadFile(CheckUrl, StartupPath + @"\" + System.IO.Path.GetFileName(CheckUrl));

                //WebClient downclient = new WebClient();
                downclient.DownloadProgressChanged += downclient_DownloadProgressChanged;
                Uri uri = new Uri(DownUrl);
                downclient.DownloadFileAsync(uri, StartupPath + @"\" + System.IO.Path.GetFileName(DownUrl));
                downclient.DownloadFileCompleted += downclient_DownloadFileCompleted;
            }
            else if (UpMode == "1")
            {
                MessageBox.Show("根据服务器端设置,更新程序将自动帮你打开网盘下载页面，请手动下载更新文件！");
                System.Diagnostics.Process.Start(DownUrl);
            }
        }

        void downclient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            downclient.CancelAsync();
            Process myProcess = new Process();
            TbxNewText.Text = TbxNewText.Text + "\r开始自解压……";
            System.Windows.Forms.Application.DoEvents();
            
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = System.IO.Path.GetFileName(DownUrl);
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                myProcess.WaitForExit();

                try
                {
                    TbxNewText.Text = TbxNewText.Text + "\r清理临时文件……";
                    System.Windows.Forms.Application.DoEvents();

                    File.Delete(StartupPath + @"\" + System.IO.Path.GetFileName(DownUrl));
                    
                    TbxNewText.Text = TbxNewText.Text + "\r更新完成……";
                    System.Windows.Forms.Application.DoEvents();

                    XmlDocument localset = new XmlDocument();
                    localset.Load(StartupPath + @"\upset.xml");
                    XmlNode localver = localset.SelectSingleNode("/setting/ver");
                    LabelNow.Content = localver.InnerText;
                }
                catch (Exception c)
                {

                    MessageBox.Show(c.Message);
                }
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
        }

        void downclient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            PBdownloading.Value = e.ProgressPercentage;
        }
    }
}
