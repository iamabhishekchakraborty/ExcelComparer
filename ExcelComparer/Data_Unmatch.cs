using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExcelComparer_Unmatch
{
    class Datamismatch
    {

       // public string Column { get; set; }
        public string FirstFile_SheetName { get; set; }
        public string SecondFile_SheetName { get; set; }
        public string FirstFile_Data { get; set; }
        public string SecondFile_Data { get; set; }
        public string FirstFile_CellIndex { get; set; }
        public string SecondFile_CellIndex { get; set; }
       
    }
}
