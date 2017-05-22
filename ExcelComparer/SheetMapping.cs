using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelComparer_Unmatch
{
    public partial class SheetMapping : Form
    {

        public List<DataTable> file1_sheet = new List<DataTable>();
        public List<DataTable> file2_sheet = new List<DataTable>();

        public List<string> file1_sheetnames = new List<string>();
        public List<string> file2_sheetnames = new List<string>();
        Boolean columnToBeIgnoredValidationFile1 = true;
        Boolean columnToBeIgnoredValidationFile2 = true;
        public Dictionary<int, int> sheetindex;
        public Dictionary<string, string> ColumnNotToBeMatchedFile1;
        public Dictionary<string, string> ColumnNotToBeMatchedFile2;
        public List<ComboBox> comboListFile1 = new List<ComboBox>();
        public List<ComboBox> comboListFile2 = new List<ComboBox>();
        public List<TextBox> TextBoxListFile1 = new List<TextBox>();
        public List<TextBox> TextBoxListFile2 = new List<TextBox>();
        int MaxComboboxlimit,CurrentCountCombobox;
        int  j=30,m=1;
        int gpboxcordinates = 0;

        public SheetMapping()
        {
            InitializeComponent();
           
        }
      
        private void SheetMapping_Load(object sender, EventArgs e)
        {
            
            for (int i = 0; i < file1_sheet.Count; i++)
            {
                file1_sheetnames.Add(file1_sheet[i].TableName);
            }
            for (int i = 0; i < file2_sheet.Count; i++)
            {
                file2_sheetnames.Add(file2_sheet[i].TableName);
            }
            
            if (file1_sheetnames.Count <= file2_sheetnames.Count)
            {
                MaxComboboxlimit = file1_sheetnames.Count;
            }
            else 
            {
                MaxComboboxlimit = file2_sheetnames.Count;
            }
            TextBox Textboxfirst = new TextBox();
            Textboxfirst.Width = 30;

            ComboBox comboFirst=new ComboBox();
            comboFirst.BindingContext = this.BindingContext;
            comboFirst.DataSource = new BindingSource { DataSource = file1_sheetnames };
            comboFirst.Width = 175;
            comboFirst.Name = "cmb" + m;
            comboFirst.SelectedIndex = 0;
            comboListFile1.Add(comboFirst);
            TextBoxListFile1.Add(Textboxfirst);
            gpboxfile1.Controls.Add(comboFirst);
            gpboxfile1.Controls.Add(Textboxfirst);
            comboFirst.Location = new Point(gpboxfile1.Location.X, (gpboxfile1.Location.Y));
            Textboxfirst.Location = new Point(gpboxfile1.Location.X + 180, (gpboxfile1.Location.Y));
            Textboxfirst.CharacterCasing =CharacterCasing.Upper;
            toolTip1.SetToolTip(Textboxfirst, "Specify column to be ignored while Comparing!!!");
            pnlsheetmap.Controls.Add(gpboxfile1);
            

            TextBox TextBoxSecond = new TextBox();
            TextBoxSecond.Width = 30;
            ComboBox comboSecond= new ComboBox();
            comboSecond.BindingContext = this.BindingContext;
            comboSecond.DataSource = new BindingSource { DataSource = file2_sheetnames };
            comboSecond.Width = 175;                
            comboSecond.Name = "cmb" + m;
            comboSecond.SelectedIndex = 0;
            comboListFile2.Add(comboSecond);
            TextBoxListFile2.Add(TextBoxSecond);
            gpboxfile2.Controls.Add(comboSecond);
            gpboxfile2.Controls.Add(TextBoxSecond);
            comboSecond.Location = new Point(gpboxfile2.Location.X - 240, (gpboxfile2.Location.Y));
            TextBoxSecond.Location = new Point(gpboxfile2.Location.X - 55 , (gpboxfile2.Location.Y));
            TextBoxSecond.CharacterCasing = CharacterCasing.Upper;
             toolTip1.SetToolTip(TextBoxSecond,"Specify column to be ignored while Comparing!!!");
            pnlsheetmap.Controls.Add(gpboxfile2);
            comboFirst.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSecond.DropDownStyle = ComboBoxStyle.DropDownList;

            m++;
            CurrentCountCombobox++;
            gpboxcordinates = (gpboxfile2.Location.Y);
         }

        private void btnAddSheetMapping_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MaxComboboxlimit - CurrentCountCombobox > 0)
                {
                    List<string> selectedsheetsfile1 = new List<string>();
                    List<string> selectedsheetsfile2 = new List<string>();
                    var comboBoxesfile1 = gpboxfile1.Controls.OfType<ComboBox>();
                    var comboBoxesfile2 = gpboxfile2.Controls.OfType<ComboBox>();

                    foreach (var item in comboBoxesfile1)
                    {
                        selectedsheetsfile1.Add(item.SelectedItem.ToString());
                        item.Enabled = false;
                    }
                    foreach (var item in comboBoxesfile2)
                    {
                        selectedsheetsfile2.Add(item.SelectedItem.ToString());
                        item.Enabled = false;
                    }
                    TextBox Textboxfirst = new TextBox();
                    Textboxfirst.Width = 30;

                    ComboBox comboFirst = new ComboBox();
                    comboFirst.DataSource = new BindingSource { DataSource = file1_sheetnames.Except(selectedsheetsfile1) };
                    comboFirst.Width = 175;
                    comboFirst.Name = "cmb" + m;
                    comboListFile1.Add(comboFirst);
                    TextBoxListFile1.Add(Textboxfirst);
                    comboFirst.Location = new Point(gpboxfile1.Location.X, (gpboxcordinates + j));
                    Textboxfirst.Location = new Point(gpboxfile1.Location.X + 180, (gpboxcordinates + j));
                    Textboxfirst.CharacterCasing = CharacterCasing.Upper;
                    toolTip1.SetToolTip(Textboxfirst, "Specify column to be ignored while Comparing!!!");
                    gpboxfile1.Controls.Add(comboFirst);
                    gpboxfile1.Controls.Add(Textboxfirst);
                    pnlsheetmap.Controls.Add(gpboxfile1);
                    

                    TextBox TextboxSecond = new TextBox();
                    TextboxSecond.Width = 30;

                    ComboBox comboSecond = new ComboBox();
                    comboSecond.DataSource = new BindingSource { DataSource = file2_sheetnames.Except(selectedsheetsfile2) };
                    comboSecond.Width = 175;
                    comboSecond.Name = "cmb" + m;
                    comboListFile2.Add(comboSecond);
                    TextBoxListFile2.Add(TextboxSecond);
                    comboSecond.Location = new Point(gpboxfile2.Location.X - 240, (gpboxcordinates + j));
                    TextboxSecond.Location = new Point(gpboxfile2.Location.X - 55, (gpboxcordinates + j));
                    TextboxSecond.CharacterCasing = CharacterCasing.Upper;
                    toolTip1.SetToolTip(TextboxSecond, "Specify column to be ignored while Comparing!!!");
                    gpboxfile2.Controls.Add(comboSecond);
                    gpboxfile2.Controls.Add(TextboxSecond);
                    pnlsheetmap.Controls.Add(gpboxfile2);
                    comboFirst.Focus();
                    comboFirst.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboSecond.DropDownStyle = ComboBoxStyle.DropDownList;
                    j = j + 30;
                    CurrentCountCombobox++;
                    m++;
                }
                else
                {
                    MessageBox.Show("All Sheet selected for comparison!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 

                }
                if (CurrentCountCombobox > 1)
                {
                    btnsubtractsheetmap.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnsubtractsheetmap_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (CurrentCountCombobox == 1)
                {
                    MessageBox.Show("Atleast single sheet should be selected for comparison", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//For triangle Warning 

                }
                if (CurrentCountCombobox > 1)
                {
                    int m = gpboxfile1.Controls.Count;
                    gpboxfile1.Controls.RemoveAt(m-1);
                    gpboxfile1.Controls.RemoveAt(m-2);
                    gpboxfile2.Controls.RemoveAt(m-1);
                    gpboxfile2.Controls.RemoveAt(m - 2);

                    comboListFile1.RemoveAt(comboListFile1.Count - 1);
                    comboListFile2.RemoveAt(comboListFile2.Count - 1);
                   

                    TextBoxListFile1.RemoveAt(TextBoxListFile1.Count - 1);
                    TextBoxListFile2.RemoveAt(TextBoxListFile2.Count - 1);

                    comboListFile1[comboListFile1.Count - 1].Enabled = true;
                    comboListFile2[comboListFile2.Count - 1].Enabled = true;
                    btnAddSheetMapping.Enabled = true;
                    CurrentCountCombobox--;

                    m--;
                    j = j - 30;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            
        }

        private void okbutton_Click(object sender, System.EventArgs e)
        {
            try
            {
                sheetindex = new Dictionary<int, int>();
                char[] delimeters = { ';', '-', ',' };
                ColumnNotToBeMatchedFile1 = new Dictionary<string, string>();
                ColumnNotToBeMatchedFile2 = new Dictionary<string, string>();
                var comboBoxesfile1 = gpboxfile1.Controls.OfType<ComboBox>();
                var comboBoxesfile2 = gpboxfile2.Controls.OfType<ComboBox>();


                using (var e1 = comboBoxesfile1.GetEnumerator())
                using (var e2 = comboBoxesfile2.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        int m = 0, n = 0;
                        foreach (var item in file1_sheetnames)
                        {
                            if (item == e1.Current.SelectedItem.ToString())
                            {
                                m = file1_sheetnames.IndexOf(item);
                                break;
                            }

                        }
                        foreach (var item in file2_sheetnames)
                        {
                            if (item == e2.Current.SelectedItem.ToString())
                            {
                                n = file2_sheetnames.IndexOf(item);
                                break;
                            }

                        }
                        sheetindex.Add(m, n);
                    }
                }
 
                using (var e1 = comboBoxesfile1.GetEnumerator())
                using (var e2 = comboBoxesfile2.GetEnumerator())
                using (var e3 = TextBoxListFile1.GetEnumerator())
                using (var e4 = TextBoxListFile2.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext()  && e3.MoveNext()  && e4.MoveNext())
                    {
                       
                        string m = "", n = "",o= "",p= "";
                        m = e1.Current.Text;
                        n = e3.Current.Text.Replace(" ", "");
                        ColumnNotToBeMatchedFile1.Add(m, n);
                        
                        o = e2.Current.Text;
                        p = e4.Current.Text.Replace(" ", "");
                       ColumnNotToBeMatchedFile2.Add(o, p);
                       
                    }
                }

                

                string colnotavailableFile1 = "File1";
                string colnotavailableFile2 = "File2";
                foreach (var sheet in file1_sheet)
                {
                    string sheetname = "";
                    DataColumnCollection columns = sheet.Columns;
                    foreach (var MultipleCol in ColumnNotToBeMatchedFile1)
                    {
                        if (sheet.TableName == MultipleCol.Key)
                        {
                            if (MultipleCol.Value != "")
                            {
                                foreach (var col in MultipleCol.Value.Trim().Split(delimeters).OrderBy(x => x).ToList().Distinct())
                                {
                                    if ((CommonUtility.GetColumnNumber(col) - 1 < sheet.Columns.Count) && (CommonUtility.GetColumnNumber(col) - 1 >= 0))
                                    {
                                    }
                                    else
                                    {
                                        if (sheetname != sheet.TableName + " - ")
                                        {
                                            sheetname = sheet.TableName + " - ";
                                            colnotavailableFile1 = colnotavailableFile1 +Environment.NewLine+ sheetname;
                                        }
                                        columnToBeIgnoredValidationFile1 = false;
                                        colnotavailableFile1 = colnotavailableFile1 + " " + col + "  ";
                                    }
                                }
                            }
                       
                         }
                    }
                }

                foreach (var sheet in file2_sheet)
                {
                    string sheetname = "";
                    DataColumnCollection columns = sheet.Columns;
                    foreach (var MultipleCol in ColumnNotToBeMatchedFile2)
                    {
                        if (sheet.TableName == MultipleCol.Key)
                        {
                            if (MultipleCol.Value != "")
                            {
                                foreach (var col in MultipleCol.Value.Trim().Split(delimeters).OrderBy(x => x).ToList().Distinct())
                                {
                                    if ((CommonUtility.GetColumnNumber(col) - 1 < sheet.Columns.Count) && (CommonUtility.GetColumnNumber(col) - 1 >= 0))
                                    {
                                        //columnToBeIgnoredValidation = true;
                                    }
                                    else
                                    {
                                        if (sheetname != sheet.TableName + " - ")
                                        {
                                            sheetname = sheet.TableName + " - ";
                                            colnotavailableFile2 = colnotavailableFile2 +Environment.NewLine+ sheetname;
                                        }
                                        columnToBeIgnoredValidationFile2 = false;
                                        colnotavailableFile2 = colnotavailableFile2 + " " + col + "  ";
                                    }
                                }
                            }
                            break;
                            }

                    }
                }
                if (columnToBeIgnoredValidationFile1 == true && columnToBeIgnoredValidationFile2 == true)
                    this.Hide();
                else 
                {
                    if (columnToBeIgnoredValidationFile1 == false && columnToBeIgnoredValidationFile2 == false)
                        MessageBox.Show(colnotavailableFile1 + Environment.NewLine + colnotavailableFile2, "No Columns Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else  if (columnToBeIgnoredValidationFile1 == false)
                        MessageBox.Show(colnotavailableFile1, "No Columns Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else if (columnToBeIgnoredValidationFile2 == false)
                        MessageBox.Show(colnotavailableFile2, "No Columns Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    columnToBeIgnoredValidationFile1 = true;
                    columnToBeIgnoredValidationFile2 = true;
                }
                }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SheetMapping_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
                sheetindex = null;
        
        }
      }
    
    }

