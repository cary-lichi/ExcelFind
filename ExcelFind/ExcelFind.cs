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

    class ExcelFindData
    {
        public List<ExcelFindInfo> infoList = new List<ExcelFindInfo>();
    }

    class ExcelFindInfo
    {
        public ICell cell;
        public string path;
    }

    class ExcelFind
    {
        public static void Find(string url, string ext, string content, ExcelFindData res, Action<string> action )
        {

            List<string> paths = FileUtil.GetAllFileName(url, ext);
            for (int i=0;i< paths.Count;i++)
            {
                string path = paths[i];
                ExportExcel(path, content, res);
                action?.Invoke($"当前进度：{path}  ({i}/{paths.Count}) ");
            }
        }

        private static void ExportExcel(string file, string content, ExcelFindData res)
        {

            if (!File.Exists(file))
            {
                return;
            }

          
            try
            {
                var stream = new FileStream(file, FileMode.Open, FileAccess.Read);
                var workbook = ExcelUtil.NewWorkbook(stream);
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
                                    if (text.Contains(content))
                                    {
                                        ExcelFindInfo info = new ExcelFindInfo
                                        {
                                            cell = cell,
                                            path = file
                                        };
                                        res.infoList.Add(info);
                                    }
                                }
                            }
                        }
                    }
                }
                workbook.Close();
                stream.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
