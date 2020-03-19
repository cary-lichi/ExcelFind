using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

namespace ExcelFind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetProgress("");
        }

        private void Btn_selectUrl_Click(object sender, EventArgs e)
        {//弹出一个选择目录的对话框
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            textBox_url.Text = path.SelectedPath;
        }

        private void Btn_find_Click(object sender, EventArgs e)
        {
            SetProgress("");
            StartProgress();
            listBoxMsg.Items.Clear();
            string path = textBox_url.Text;
            string target = textBox_target.Text;
            string type = textBox_type.Text;

            ThreadStart childref = new ThreadStart(()=> {
                ExcelFindData data = new ExcelFindData();
                ExcelFind.Find(path, type, target, data, this);
                if (data.infoList.Count > 0)
                {
                    foreach (var info in data.infoList)
                    {
                        ICell cell = info.cell;
                        AddBoxMsg(text: $"路径： {info.path} : {cell.Sheet.SheetName}:第{cell.RowIndex}行，第{cell.ColumnIndex}列 内容为：{cell}");
                    }
                }
                else
                {
                    AddBoxMsg($"没有找到和‘{target}’类似的内容");
                }
                Stop();
            });
            Thread childThread = new Thread(childref);
            childThread.Start();
        }
        private void AddBoxMsg(string text)
        {
            listBoxMsg.Items.Add(text);
        }

        private void Btn_replace_Click(object sender, EventArgs e)
        {
            SetProgress("");
            StartProgress();
            listBoxMsg.Items.Clear();
            string path = textBox_url.Text;
            string oldChar = textBox_target.Text;
            string type = textBox_type.Text;
            string newChar = textBox_newChar.Text;
            ThreadStart childref = new ThreadStart(() => {
                IExcelReplace data = new IExcelReplace
                {
                    url = path,
                    ext = type,
                    oldChar = oldChar,
                    newChar = newChar,
                    infoList = new List<string>(),
                    view = this
                };
                ExcelReplace.Replace(data);
                if (data.infoList.Count > 0)
                {
                    AddBoxMsg($"操作成功");
                    AddBoxMsg($"已经把所有的‘{oldChar}’替换成‘{newChar}’");
                    AddBoxMsg($"修改过的文件如下：");
                    foreach (var info in data.infoList)
                    {
                        AddBoxMsg(info);
                    }
                }
                else
                {
                    AddBoxMsg($"没有找到和‘{oldChar}’类似的内容");
                }
                
                Stop();
            });
            Thread childThread = new Thread(childref);
            childThread.Start();
        }

        public string Progress;
        public System.Timers.Timer timer;
        public void SetProgress(string msg)
        {
            Progress = msg;
        }

        private void StartProgress()
        {
            //设置定时间隔(毫秒为单位)
            int interval = 10;
            timer = new System.Timers.Timer(interval)
            {
                //设置执行一次（false）还是一直执行(true)
                AutoReset = true,
                //设置是否执行System.Timers.Timer.Elapsed事件
                Enabled = true
            };
            //绑定Elapsed事件
            timer.Elapsed += new System.Timers.ElapsedEventHandler((object sender, System.Timers.ElapsedEventArgs e) => {
                lab_progress.Text = Progress;
            });
        }

        private void Stop()
        {
            timer.Stop();
            timer = null;
            lab_progress.Text = "";
        }
    }

}
