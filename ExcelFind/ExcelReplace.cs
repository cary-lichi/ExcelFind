using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExcelFind
{
    ///<summary>
    /// 创建人：cary 
    /// 日 期：2020/3/18 11:53:38 
    /// 描 述：
    ///</summary>

    struct IExcelReplace
    {
        public string oldUrl;
        public string newUrl;
        public string ext;
        public Action<string> action;
        public IReplaceText[] replaceList;
        public List<string> infoList;
    }

    struct IReplaceText
    {
        public string oldChar;
        public string newChar;
    }

    class ExcelReplace
    {
        public static void Replace(IExcelReplace data)
        {

            List<string> paths = FileUtil.GetAllFileName(data.oldUrl, data.ext);
            for (int i = 0; i < paths.Count; i++)
            {
                string path = paths[i];
                data.action?.Invoke($"当前进度：{path}  ({i+1}/{paths.Count})");
                ExportExcel(path, data);
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
                                if (ReplaceCellText(cell, data))
                                {
                                    change = true;
                                }
                            }
                        }
                    }
                }

                stream.Close();

                if (change)
                {
                    FileUtil.CheckPath(data.newUrl);
                    string newPath = data.newUrl + @"\" + Path.GetFileName(file);
                    using var fs = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
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

        private static bool ReplaceCellText(ICell cell, IExcelReplace data)
        {
            if (cell == null)
            {
                return false;
            }

            bool change = false;
            try
            {
                if (cell.CellType == CellType.String)
                {
                    string text = cell.ToString();
                    if (data.replaceList.Length > 0)
                    {
                        for (int i = 0; i < data.replaceList.Length; i++)
                        {
                            IReplaceText rep = data.replaceList[i];
                            if (text.Contains(rep.oldChar))
                            {
                                text = text.Replace(rep.oldChar, rep.newChar);
                                cell.SetCellValue(text);
                                change = true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return change;
        }
    }
}
