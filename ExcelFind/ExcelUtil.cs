using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace ExcelFind
{
    ///<summary>
    /// 创建人：cary 
    /// 日 期：2020/3/18 11:53:02 
    /// 描 述：
    ///</summary>
    class ExcelUtil
    {

        public static IWorkbook NewWorkbook(FileStream stream)
        {
            if (stream.Name.EndsWith(".xlsx"))
            {
                return new XSSFWorkbook(stream);
            }else if (stream.Name.EndsWith(".xls"))
            {
                return new HSSFWorkbook(stream);
            }
            return null;
        }
    }
}
