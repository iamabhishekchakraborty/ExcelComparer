using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using ExcelComparer_Unmatch;


namespace ExcelComparer_Unmatch
{
     class UnmatchedData
    {


         public Datamismatch CellCompare(string sheetname1, string sheetname2, string sheet1Data, string sheet2Data, int row, int FirstFilecolumn, int SecondFileColumn)
        {
            Datamismatch newdiff = new Datamismatch();
            try
            {

                newdiff.FirstFile_SheetName = sheetname1;
                newdiff.SecondFile_SheetName = sheetname2;
                newdiff.FirstFile_Data = sheet1Data;
                newdiff.SecondFile_Data = sheet2Data;
                newdiff.FirstFile_CellIndex = "[" + CommonUtility.getcolumnname(FirstFilecolumn) + "," + (row + 1) + "]";
                newdiff.SecondFile_CellIndex = "[" + CommonUtility.getcolumnname(SecondFileColumn) + "," + (row + 1) + "]";
                
            }
            catch (Exception Ex)
            {

                throw Ex;
            }

               return newdiff;
            
            
        }

    }
}
