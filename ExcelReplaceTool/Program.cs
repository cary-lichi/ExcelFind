using ExcelFind;
using System;
using System.Collections.Generic;

namespace ExcelReplaceTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Log("命令格式如下：");
            Log(@"ExcelFind.exe 目标路径$$输出路径$$旧字符1,新字符1;旧字符2,新字符2");
            if (args == null || args.Length == 0)
            {
                Log("请输入正确参数");
                return;
            }
            try
            {


                string str = args[0];
                string[] list = str.Split("$$");
                string oldUrl = list[0];
                string newUrl = list[1];
                string[] textList = list[2].Split(";");
                IReplaceText[] replaceList = new IReplaceText[textList.Length];
                for (int i = 0; i < textList.Length; i++)
                {
                    string[] chars = textList[i].Split(",");
                    replaceList[i] = new IReplaceText
                    {
                        oldChar = chars[0],
                        newChar = chars[1]
                    };
                }
                IExcelReplace data = new IExcelReplace
                {

                    oldUrl = oldUrl,
                    newUrl = newUrl,
                    ext = "",
                    replaceList = replaceList,
                    infoList = new List<string>(),
                    action = Log
                };
                Log("开始替换，进度如下：");
                ExcelReplace.Replace(data);
                if (data.infoList.Count > 0)
                {
                    Log("替换成功，已被替换路径如下");
                    foreach (string info in data.infoList)
                    {
                        Log(info);
                    }
                }
                else
                {
                    Log("没有找到可更换的文件");
                }
            }
            catch (Exception e)
            {
                Log(e.ToString());
            }

        }
        static void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
