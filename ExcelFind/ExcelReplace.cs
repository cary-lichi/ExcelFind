using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ExcelFind
{
    ///<summary>
    /// 创建人：cary 
    /// 日 期：2020/3/18 11:53:38 
    /// 描 述：
    ///</summary>

    struct IExcelReplace
    {
        public string url;
        public string ext;
        public string oldChar;
        public string newChar;
        public Form1 view;
        public List<string> infoList ;
    }

    class ExcelReplace
    {
        public static void Replace(IExcelReplace data)
        {

            List<string> paths = FileUtil.GetFileName(data.url, data.ext);
            for (int i = 0; i < paths.Count; i++)
            {
                string path = paths[i];
                ExportExcel(path, data);
                data.view.SetProgress($"当前进度：{path}  ({i}/{paths.Count})");
            }
        }

        private static void ExportExcel(string file, IExcelReplace data)
        {

            if (!File.Exists(file))
            {
                return;
            }
            bool change = false;


            try
            {
                FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                IWorkbook workbook = ExcelUtil.NewWorkbook(stream);
                if (workbook == null)
                {
                    return;
                }
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);
                    for (int j = 0; j < sheet.LastRowNum; j++)
                    {
                        IRow row = sheet.GetRow(j);
                        if (row != null)
                        {
                            for (int k = 0; k < row.LastCellNum; k++)
                            {
                                ICell cell = row.GetCell(k);
                                string text = "";
                                if (cell != null)
                                {
                                    text = cell.ToString();
                                    if (text.Contains(data.oldChar))
                                    {
                                        text = text.Replace(data.oldChar, data.newChar);
                                        cell.SetCellValue(text);
                                        change = true;
                                    }
                                }

                            }
                        }
                    }
                }

                stream.Close();
                if (change)
                {
                    using var fs = new FileStream(file, FileMode.Create, FileAccess.Write);
                    data.infoList.Add(file);
                    workbook.Write(fs);
                    fs.Close();
                }
                workbook.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
