using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EntCL
{
    public static class ToFormat
    {
        
        /// <summary>
        /// 格式化指定的DataTable
        /// </summary>
        /// <param name="OldDT">老的DataTable</param>
        /// <param name="NewFormat">指定新DataTable格式
        /// "No”:“编号”,"Name”:“姓名”,"ProjectName”:“项目名称”
        /// "需保留原字段名":"需保留字段名的新名称"
        /// </param>
        /// <param name="NewDT">新DataTable</param>
        public static void ToDataTable(DataTable OldDT, string NewFormat, out DataTable NewDT)
        {
            DataTable OldDTcopy = OldDT.Copy();
            string[] StrArray = NewFormat.Split(',');
            int cl = 0;
            int OldDTcopyCol = OldDTcopy.Columns.Count;
            while (cl < OldDTcopyCol)
            {
                string ColumnName = OldDTcopy.Columns[cl].ToString();
                bool IsEqual = false;
                foreach (string i in StrArray)
                {
                    string[] iArray = i.Split(':');
                    string OldFieldName = iArray[0].ToString();
                    string NewFieldName = iArray[1].ToString();
                    if (ColumnName == OldFieldName)
                    {
                        OldDTcopy.Columns[cl].ColumnName = NewFieldName;
                        IsEqual = true;
                        cl++;
                    }
                }
                if (!IsEqual)
                {
                    OldDTcopy.Columns.Remove(OldDTcopy.Columns[cl]);
                    OldDTcopyCol--;
                }
            }
            NewDT = OldDTcopy;
        }

        /// <summary>
        /// 工龄
        /// </summary>
        /// <param name="InJobDate">ty</param>
        /// <param name="NowDatetime"></param>
        /// <returns></returns>
        public static string LengthOfService(DateTime InJobDate, DateTime NowDatetime)
        {
            string reutrnstr = "";
            string daystr = "";
            int year = NowDatetime.Year - InJobDate.Year;
            int month = NowDatetime.Month - InJobDate.Month;
            int day = NowDatetime.Day - InJobDate.Day;
            if(day != 0)
            {
                daystr = "(" + day + "天)";
            }
            if (month == 0)
            {
                reutrnstr = year.ToString() + "年" + daystr;
            }
            else
            {
                reutrnstr = year.ToString() + "年" + month.ToString() + "月" + daystr;
            }
            return reutrnstr;
        }

    }

}
