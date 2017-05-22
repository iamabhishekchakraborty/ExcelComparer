using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;
using ExcelComparer_Unmatch;
using System.Runtime.InteropServices;
using System.IO;
using Excel;
using System.Collections;
using System.Data.OleDb;
using AcroPDFLib;
//using Acrobat;
using System.Diagnostics;

namespace ExcelComparer_Unmatch
{
    public partial class Form1 : Form
    {

        List<Datamismatch> listofdiffernce;
        Dictionary<int, int> sheetstocompare = new Dictionary<int, int>();
        public Dictionary<string, string> ColumnIgnoredFile1;
        public Dictionary<string, string> ColumnIgnoredFile2;
        string FilePath2 = null, FilePath1 = null;
        BackgroundWorker backgroundThread;
        Microsoft.Office.Interop.Excel.Application app;
        string CancelPending = null;
        List<System.Data.DataTable> AllSheetsFile1;
        List<System.Data.DataTable> AllSheetsFile2;
        char[] delimeters = { ';', '-', ',' };

        public Form1()
        {

            InitializeComponent();
            backgroundThread = new BackgroundWorker();
            backgroundThread.DoWork += new DoWorkEventHandler(Background_DoWork);
            backgroundThread.ProgressChanged += new ProgressChangedEventHandler
                    (Background_ProgressChanged);
            backgroundThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (Background_RunWorkerCompleted);
            backgroundThread.WorkerReportsProgress = true;
            backgroundThread.WorkerSupportsCancellation = true;
            filedlg.Filter = "Excel Files|*.xls;*.xlsx";
            Btn_CompareAgain.Enabled = false;
            txtbox_file1.Enabled = false;
            txtbox_file2.Enabled = false;
            Btn_Cancel.Enabled = false;
            dt_gridview.Visible = false;
            checkbox_case.Text = "Ignore Case";
            comppictureBox.Visible = false;
            lblloading.Visible = false;
            pictureBox2.Visible = false;
            SaveToExcel.Visible = false;
            
        }


        private void Background_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                this.toolStripStatusLabel1.Text = "Canceled!";
                btn_browsefile2.Enabled = false;
                btn_browsefile1.Enabled = false;
                btn_cmpr.Enabled = false;
                Btn_Cancel.Enabled = false;
                comppictureBox.Visible = false;

            }

            else if (!(e.Error == null))
            {
                this.toolStripStatusLabel1.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                this.toolStripStatusLabel1.Text = "Done!";
            }

            try
            {
                if (listofdiffernce.Count > 0)
                {
                    dt_gridview.Visible = true;
                    comppictureBox.Visible = false;
                    dt_gridview.DataSource = listofdiffernce;
                    SaveToExcel.Visible = true;
                }
                else if (e.Cancelled != true)
                {
                    pictureBox2.Visible = false;
                    lblloading.Visible = false;
                    comppictureBox.Visible = false;
                    MessageBox.Show("No Difference Found", "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comppictureBox.Visible = false;
            }

            //Changing the UI Accordingly
            Btn_Cancel.Enabled = false;
            Btn_CompareAgain.Enabled = true;

        }

        private void Background_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            try
            {
                List<object> Argumentlist = e.Argument as List<object>;
                Dictionary<int, int> sheetsindex = (Dictionary<int, int>)Argumentlist[0];
                List<System.Data.DataTable> File1Sheets = (List<System.Data.DataTable>)Argumentlist[1];
                List<System.Data.DataTable> File2Sheets = (List<System.Data.DataTable>)Argumentlist[2];
                CancelPending = "false";
                
                    listofdiffernce = new List<Datamismatch>();
                    UnmatchedData AddUnmatchedDataToList = new UnmatchedData();

                    foreach (var item in sheetsindex)
                    {
                        int diff;
                        System.Data.DataTable dt1 = File1Sheets[item.Key];
                        System.Data.DataTable dt2 = File2Sheets[item.Value];

                        if (dt1.Rows.Count > dt2.Rows.Count)
                        {
                            diff = dt1.Rows.Count - dt2.Rows.Count;
                            for (int k = 0; k < diff; k++)
                            {
                                dt2.Rows.Add();
                            }
                        }
                        else if (dt2.Rows.Count > dt1.Rows.Count)
                        {
                            diff = dt2.Rows.Count - dt1.Rows.Count;
                            for (int k = 0; k < diff; k++)
                            {
                                dt1.Rows.Add();
                            }

                        }

                        if (dt1.Columns.Count > dt2.Columns.Count)
                        {
                            diff = dt1.Columns.Count - dt2.Columns.Count;
                            for (int k = 0; k < diff; k++)
                            {
                                dt2.Columns.Add();
                            }
                        }
                        else if (dt2.Columns.Count > dt1.Columns.Count)
                        {
                            diff = dt2.Columns.Count - dt1.Columns.Count;
                            for (int k = 0; k < diff; k++)
                            {
                                dt1.Columns.Add();
                            }

                        }

                        if (checkbox_case.Checked)
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                if (CancelPending == "false")
                                {
                                    for (int j = 0, m = 0; j < dt1.Columns.Count && m < dt2.Columns.Count; j++, m++)
                                    {

                                        Tuple<int, int> t = ColumnIgnore(dt1, dt2, j, m);
                                        j = t.Item1;
                                        m = t.Item2;
                                        if (j < dt1.Columns.Count && m < dt2.Columns.Count)
                                        {
                                            if (dt1.Rows[i][j].ToString().ToUpper().Trim() != dt2.Rows[i][m].ToString().ToUpper().Trim())
                                            {
                                                listofdiffernce.Add(AddUnmatchedDataToList.CellCompare(dt1.TableName, dt2.TableName, dt1.Rows[i][j].ToString(), dt2.Rows[i][m].ToString(), i + 1, j + 1, m + 1));
                                                backgroundThread.ReportProgress(listofdiffernce.Count());
                                            }
                                        }

                                    }
                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        System.Windows.Forms.Application.DoEvents();
                                        comppictureBox.Enabled = true;
                                    });
                                }
                                else
                                {
                                    e.Cancel = true;
                                }
                            }

                        }
                        else
                        {
                            for (int i = 0; i < dt1.Rows.Count; i++)
                            {
                                if (CancelPending == "false")
                                {
                                    for (int j = 0, m = 0; j < dt1.Columns.Count && m < dt2.Columns.Count; j++, m++)
                                    {
                                        Tuple<int, int> t = ColumnIgnore(dt1, dt2, j, m);
                                        j = t.Item1;
                                        m = t.Item2;
                                        if (j < dt1.Columns.Count && m < dt2.Columns.Count)
                                        {
                                            if (dt1.Rows[i][j].ToString().Trim() != dt2.Rows[i][m].ToString().Trim())
                                            {
                                                listofdiffernce.Add(AddUnmatchedDataToList.CellCompare(dt1.TableName, dt2.TableName, dt1.Rows[i][j].ToString(), dt2.Rows[i][m].ToString(), i + 1, j + 1, m + 1));
                                                backgroundThread.ReportProgress(listofdiffernce.Count());
                                            }

                                        }
                                        
                                    }

                                    this.Invoke((MethodInvoker)delegate
                                    {
                                        System.Windows.Forms.Application.DoEvents();
                                        comppictureBox.Enabled = true;
                                    });
                                }
                                else
                                {
                                    e.Cancel = true;
                                }
                            }
                        }

                    }
                
                if (CancelPending == "true")
                {
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was cancelled.
                    e.Cancel = true;
                    return;
                }
                else if (CancelPending != "false")
                {
                    throw new Exception(CancelPending);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "ExcelComparer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void Background_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            // This function fires on the UI thread so it's safe to edit
            // the UI control directly, no funny business with Control.Invoke :)
            // Update the progressBar with the integer supplied to us from the
            // ReportProgress() function.  

            toolStripStatusLabel1.Text = "Comparing Data!!!...DifferenceFound......(" + e.ProgressPercentage.ToString() + ")!!!";
        }

        
        private Tuple<int, int> ColumnIgnore(System.Data.DataTable dt1, System.Data.DataTable dt2, int j, int m)
        {
            foreach (var MultipleCol in ColumnIgnoredFile1)
            {
                if (dt1.TableName == MultipleCol.Key)
                    if (MultipleCol.Value != "")
                    {
                        foreach (var col in MultipleCol.Value.Trim().Split(delimeters).OrderBy(x => x).ToList().Distinct())
                        {
                            if ((CommonUtility.GetColumnNumber(col) - 1) == j)
                            {
                                j++;
                               
                            }
                        }
                    }
            }

            foreach (var MultipleCol in ColumnIgnoredFile2)
            {
                if (dt2.TableName == MultipleCol.Key)
                    if (MultipleCol.Value != "")
                    {
                        foreach (var col in MultipleCol.Value.Trim().Split(delimeters).OrderBy(x => x).ToList().Distinct())
                        {
                            if ((CommonUtility.GetColumnNumber(col) - 1) == m)
                            {
                                m++;
                             
                            }
                        }
                    }
            }

            return Tuple.Create(j, m);
        }


        private void btn_browsefile1_Click_1(object sender, EventArgs e)
        {
            try
            {

                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    FilePath1 = filedlg.FileName;
                    txtbox_file1.Text = FilePath1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "ExcelComparer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_browsefile2_Click(object sender, EventArgs e)
        {
            try
            {
                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    FilePath2 = filedlg.FileName;
                    txtbox_file2.Text = FilePath2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "ExcelComparer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btn_cmpr_Click(object sender, EventArgs e)
        {
            if (FilePath1 == null || FilePath2 == null)
            {
                if (FilePath1 == null && FilePath2 == null)
                    MessageBox.Show("Please Select files", "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 
                else
                {
                    if (FilePath2 == null)
                        MessageBox.Show("Please Select file2", "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 
                    else if (FilePath1 == null)
                        MessageBox.Show("Please Select file1", "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 
                }
            }

            else
            {
                try
                {
                    if (FilePath1 != FilePath2)
                    {
                        pictureBox2.Visible = true;
                        lblloading.Visible = true;
                        this.toolStripStatusLabel1.Text = "Loading Data!!!Please wait for some time for large files";
                        IExcelDataReader excelReaderFile1;
                        IExcelDataReader excelReaderFile2;
                        List<System.Data.DataTable> AllSheetsFile1 = new List<System.Data.DataTable>();
                        List<System.Data.DataTable> AllSheetsFile2 = new List<System.Data.DataTable>();
                        DataSet resultFile1 = new DataSet();
                        DataSet resultFile2 = new DataSet();

                        FileStream streamFile1 = new FileStream(FilePath1, FileMode.Open, FileAccess.Read);
                        FileStream streamFile2 = new FileStream(FilePath2, FileMode.Open, FileAccess.Read);


                        if (Path.GetExtension(FilePath1) == ".xlsx")
                        {
                            lblloading.Text = "Loading First File....Please Wait..Large files may take some time to load";
                            System.Windows.Forms.Application.DoEvents();
                            excelReaderFile1 = ExcelReaderFactory.CreateOpenXmlReader(streamFile1);
                            excelReaderFile1.IsFirstRowAsColumnNames = true;
                            System.Windows.Forms.Application.DoEvents();
                            resultFile1 = excelReaderFile1.AsDataSet();
                        }
                        if (Path.GetExtension(FilePath1) == ".xls")
                        {
                            lblloading.Text = "Loading First File....Please Wait..Large files may take some time to load";
                            System.Windows.Forms.Application.DoEvents();
                            excelReaderFile1 = ExcelReaderFactory.CreateBinaryReader(streamFile1);
                            excelReaderFile1.IsFirstRowAsColumnNames = true;
                            System.Windows.Forms.Application.DoEvents();
                            resultFile1 = excelReaderFile1.AsDataSet();
                        }

                        if (Path.GetExtension(FilePath2) == ".xlsx")
                        {
                            lblloading.Text = "Loading Second File....Please Wait..Large files may take some time to load";
                            System.Windows.Forms.Application.DoEvents();
                            excelReaderFile2 = ExcelReaderFactory.CreateOpenXmlReader(streamFile2);
                            System.Windows.Forms.Application.DoEvents();
                            excelReaderFile2.IsFirstRowAsColumnNames = true;
                            resultFile2 = excelReaderFile2.AsDataSet();

                        } 
                        if (Path.GetExtension(FilePath2) == ".xls")
                        {
                            lblloading.Text = "Loading Second File....Please Wait..Large files may take some time to load";
                            System.Windows.Forms.Application.DoEvents();
                            excelReaderFile2 = ExcelReaderFactory.CreateBinaryReader(streamFile2);
                            System.Windows.Forms.Application.DoEvents();
                            excelReaderFile2.IsFirstRowAsColumnNames = true;
                            System.Windows.Forms.Application.DoEvents();
                            resultFile2 = excelReaderFile2.AsDataSet();
                        } 

                        if (resultFile1.Tables.Count > 0 && resultFile2.Tables.Count > 0)
                        {
                            foreach (System.Data.DataTable table1 in resultFile1.Tables)
                            {
                                AllSheetsFile1.Add(table1);
                            }
                            foreach (System.Data.DataTable table2 in resultFile2.Tables)
                            {
                                AllSheetsFile2.Add(table2);
                            }
                            this.toolStripStatusLabel1.Text = "Please select Sheets to compare";
                            pictureBox2.Visible = false;
                            lblloading.Visible = false;

                            Listsheets(AllSheetsFile1, AllSheetsFile2);

                            comppictureBox.Visible = true;

                            if (sheetstocompare.Count > 0)
                            {
                                btn_browsefile2.Enabled = false;
                                btn_browsefile1.Enabled = false;
                                checkbox_case.Enabled = false;
                                btn_cmpr.Enabled = false;
                                this.toolStripStatusLabel1.Text = "Comparing Data...";
                                Btn_Cancel.Enabled = true;
                                List<object> arguments = new List<object>();
                                arguments.Add(sheetstocompare);
                                arguments.Add(AllSheetsFile1);
                                arguments.Add(AllSheetsFile2);
                                backgroundThread.RunWorkerAsync(arguments);
                            }
                            else
                            {
                                comppictureBox.Visible = false;
                                this.toolStripStatusLabel1.Text = "";
                                MessageBox.Show("No Sheet Selected!!!Please Select the sheet", "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 
                             }
                        }
                        else
                        {
                            pictureBox2.Visible = false;
                            lblloading.Visible = false;
                            MessageBox.Show("Blank Excel present", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtbox_file1.Text = "";
                            txtbox_file2.Text = "";

                        }

                    }
                    else
                    {
                        pictureBox2.Visible = false;
                        lblloading.Visible = false;
                        MessageBox.Show("Same Excel selected!!!Please Select two different files to compare!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 
                        txtbox_file1.Text = "";
                        txtbox_file2.Text = "";

                    }
                }

                catch (Exception ex)
                {
                    pictureBox2.Visible = false;
                    lblloading.Visible = false;
                   toolStripStatusLabel1.Text = "";
                   txtbox_file1.Text = "";
                   txtbox_file2.Text = "";
                   MessageBox.Show("Exception: " + ex.Message, "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        //Display the sheet form and let user to select sheets to compare data
        private void Listsheets(List<System.Data.DataTable> Worksheets1, List<System.Data.DataTable> Worksheets2)
        {

            List<string> wb1_sheets = new List<string>();
            List<string> wb2_sheets = new List<string>();

            try
            {
                for (int i = 0; i < Worksheets1.Count; i++)
                {
                    wb1_sheets.Add(Worksheets1[i].TableName);
                }
                for (int i = 0; i < Worksheets2.Count; i++)
                {
                    wb2_sheets.Add(Worksheets2[i].TableName);
                }

                SheetMapping sheetmap = new SheetMapping();
                sheetmap.file1_sheet = Worksheets1;
                sheetmap.file2_sheet = Worksheets2;
                sheetmap.ShowDialog();
                if (sheetmap.sheetindex != null)
                    sheetstocompare = sheetmap.sheetindex;
                AllSheetsFile1 = sheetmap.file1_sheet;
                AllSheetsFile2 = sheetmap.file2_sheet;
                ColumnIgnoredFile1 = sheetmap.ColumnNotToBeMatchedFile1;
                ColumnIgnoredFile2 = sheetmap.ColumnNotToBeMatchedFile2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.toolStripStatusLabel1.Text = "";
            }

        }

        private void Btn_CompareAgain_Click_1(object sender, EventArgs e)
        {
            listofdiffernce = null;
            dt_gridview.DataSource = null;
            FilePath1 = null;
            FilePath2 = null;
            txtbox_file1.Text = null;
            txtbox_file2.Text = null;
            Btn_Cancel.Enabled = false;
            btn_cmpr.Enabled = true;
            btn_browsefile2.Enabled = true;
            btn_browsefile1.Enabled = true;
            Btn_CompareAgain.Enabled = false;
            checkbox_case.Enabled = true;
            checkbox_case.Checked = false;
            dt_gridview.Visible = false;
            SaveToExcel.Visible = false;
            this.toolStripStatusLabel1.Text = "";
            sheetstocompare.Clear();
            CancelPending = "false";
        }

        private void Btn_Cancel_Click_1(object sender, EventArgs e)
        {
            if (backgroundThread.IsBusy)
            {
                // Notify the worker thread that a cancel has been requested.
                // The cancel will not actually happen until the thread in the
                // DoWork checks the m_oWorker.CancellationPending flag. 
                backgroundThread.CancelAsync();
                backgroundThread.Dispose();
                CancelPending = "true";
            }
        }



        private void SaveToExcel_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (listofdiffernce != null)
                {
                    if (listofdiffernce.Count > 0)
                    {
                        app = new Microsoft.Office.Interop.Excel.Application();
                        Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                        Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                        app.Visible = true;
                        app.DefaultSaveFormat = XlFileFormat.xlOpenXMLWorkbook;
                        worksheet = workbook.Sheets[1];
                        worksheet.Name = "DifferenceReport";
                        worksheet = workbook.ActiveSheet;


                        for (int i = 1; i < dt_gridview.Columns.Count + 1; i++)
                        {
                            worksheet.Cells[1, i] = dt_gridview.Columns[i - 1].HeaderText;
                        }
                        for (int i = 0; i <= dt_gridview.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dt_gridview.Columns.Count; j++)
                            {
                                if (dt_gridview.Rows[i].Cells[j].Value != null)
                                {
                                    worksheet.Cells[i + 2, j + 1] = dt_gridview.Rows[i].Cells[j].Value.ToString();
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, j + 1] = "";
                                }
                            }
                        }

                        worksheet.Activate();
                        worksheet.Columns.AutoFit();

                    }
                    else
                    {

                        MessageBox.Show("No Records to Export To Excel");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message, "Excel Report Comparer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

       
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.Document_Pdf1;
            MemoryStream ms = new MemoryStream(PDF);

            //Create PDF File From Binary of resources folders help.pdf
            FileStream f = new FileStream("Document_Pdf.Pdf", FileMode.OpenOrCreate);

            //Write Bytes into Our Created help.pdf
            ms.WriteTo(f);
            f.Close();
            ms.Close();

            // Finally Show the Created PDF from resources 
            Process.Start("Document_Pdf.pdf");
        }


    }


}



