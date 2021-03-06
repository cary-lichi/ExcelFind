﻿using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace ExcelFind
{
    public partial class Form1 : Form
    {
        private Thread curThread;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StopProgress();
            listBoxMsg.Items.Clear();
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

            ThreadStart childref = new ThreadStart(() =>
            {
                ExcelFindData data = new ExcelFindData();
                ExcelFind.Find(path, type, target, data, SetProgress);
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
                StopProgress();
            });
            StartThread(childref);
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

            ThreadStart childref = new ThreadStart(() =>
            {
                IExcelReplace data = new IExcelReplace
                {
                    oldUrl = path,
                    newUrl = path,
                    ext = type,
                    replaceList = new IReplaceText[1]
                    {
                        new IReplaceText
                        {
                            oldChar = oldChar,
                            newChar = newChar
                        }
                    },
                    infoList = new List<string>(),
                    action = SetProgress
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
                StopProgress();

            });
            StartThread(childref);
        }

        public string Progress;
        public System.Timers.Timer timer;
        public void SetProgress(string msg)
        {
            Progress = msg;
            UpdateProgess();
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
            timer.Elapsed += new System.Timers.ElapsedEventHandler(UpdateProgess);
        }

        private void UpdateProgess(object sender = null, System.Timers.ElapsedEventArgs e = null)
        {
            lab_progress.Text = Progress;
        }

        private void StopProgress()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
            SetProgress("当前进度：查询完成");
        }

        private void StartThread(ThreadStart childref)
        {
            if (curThread == null || curThread.ThreadState == ThreadState.Stopped)
            {
                curThread = new Thread(childref)
                {
                    IsBackground = true
                };
                curThread.Start();
            }
            else
            {
                MessageBox.Show("正在查询，请稍后...", "提示");
            }
        }
    }

}
