using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace ExcelFind
{
    ///<summary>
    /// 创建人：cary 
    /// 日 期：2020/3/18 13:43:00 
    /// 描 述：
    ///</summary>
    class FileUtil
    {
        /// <summary>
        /// 获取指定文件夹下的所有文件
        /// </summary>
        /// <param name="fileDir">指定文件夹</param>
        /// <param name="ext">文件后缀名, 空表示不过滤文件后缀名, 多个可用 "|" 分隔</param>
        /// <param name="subfolder">是否获取子文件夹</param>
        /// <param name="ignoreFile">用于自定义来判断是否需要忽略指定的文件或文件夹</param>
        public static List<string> GetAllFileName(string fileDir, string ext = "", bool subfolder = true, bool ignoreFile = false)
        {
            List<string> path = new List<string>();
            string[] extList = ext.Split("|");
            if (fileDir != "")
            {
                DirectoryInfo root = new DirectoryInfo(fileDir);
                foreach (FileInfo f in root.GetFiles())
                {
                    if (ext == "" || ((IList)extList).Contains(f.Extension))
                    {
                        path.Add(f.FullName);
                    }
                }
            }

            return path;
        }

        public static void CheckPath(string path)
        {
            if (Directory.Exists(path)==false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(path);
            }

        }
    }
}
