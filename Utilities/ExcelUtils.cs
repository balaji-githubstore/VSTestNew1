using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitedLex.OpenEmrAutomation.Utilities
{
    public class ExcelUtils
    {
        public static object[] GetSheetIntoObjectArray(string fileDetail,string sheetname)
        {
            XLWorkbook book = new XLWorkbook(fileDetail);
            var sheet = book.Worksheet(sheetname);
            var range = sheet.RangeUsed();
            int rowCount = range.RowCount(); //5
            int colCount = range.ColumnCount(); //4
            object[] main = new object[rowCount - 1]; //number of test case
            for (int r = 2; r <= rowCount; r++)
            {
                object[] temp = new object[colCount]; //number of parameter
                for (int c = 1; c <= colCount; c++)
                {
                    string cellValue = range.Cell(r, c).GetString();
                   
                    temp[c - 1] = cellValue;
                }

                main[r - 2] = temp;
            }

            book.Dispose();

            return main;
        }
    }
}
