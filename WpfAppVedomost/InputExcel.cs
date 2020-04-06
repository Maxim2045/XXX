using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using Microsoft.Win32;
using System.Windows;

namespace WpfAppVedomost
{
    class InputExcel
    {
        private Excel.Application excelapp;
     
        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;

        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;

        private Excel.Range excelcellsStudentNames;
        private Excel.Range excelcellsStudentNumber;

        public int Initialization()
        {
            excelapp = new Excel.Application();
            excelappworkbooks = excelapp.Workbooks;
            FileDialog selectExcel = new OpenFileDialog
            {
                Filter = "файл Excel (*.xls)|*.xls",
                InitialDirectory = Path.Combine(
                Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]))
            };
            if (selectExcel.ShowDialog() == true)
            {
                try
                {
                    excelappworkbook = excelapp.Workbooks.Open(selectExcel.FileName,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                         Type.Missing, Type.Missing);
                }
                catch(Exception)
                {
                    MessageBox.Show("Выберите файл Excel формата");
                }
                excelsheets = excelappworkbook.Worksheets;
                //Получаем ссылку на лист 1
                excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                int LastRow = excelworksheet.Cells[excelworksheet.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row - 2;
                return LastRow;
            }
            else
            {
                MessageBox.Show("Отмена редактирования");
                return 0;
            }
        }
        public string[] FullNameDataExcel(int LastRow)
        {
            string StudentName;          
            string Crutch;//Для перевода в нужный вид(А3, А4 и т.д.)
            int BeginList = 3;
            string[] StudentNames = new string[LastRow];
            for (int k = 0; k < LastRow; k++)
            {
                Crutch = BeginList.ToString();
                var NameCell = string.Join(string.Empty, new string[] { "A", Crutch });
              
                excelcellsStudentNames = excelworksheet.get_Range(NameCell, Type.Missing);
               
                if (excelcellsStudentNames.Value2 != null )
                {
                    StudentName = Convert.ToString(excelcellsStudentNames.Value2);                 
                }
                else 
                {
                    StudentName = "";                    
                }           
                StudentNames[k] = StudentName;              
                BeginList++;
            }
            return StudentNames;
        }
        public int[] StudentNumberDataExcel(int LastRow)
        {
            int StudentNumber;
            string Crutch;//Для перевода в нужный вид(А3, А4 и т.д.)
            int BeginList = 3;
            int[] StudentNumbers = new int[LastRow];
            for (int k = 0; k < LastRow; k++)
            {
                Crutch = BeginList.ToString();
                var NubmerCell = string.Join(string.Empty, new string[] { "B", Crutch });
                excelcellsStudentNumber = excelworksheet.get_Range(NubmerCell, Type.Missing);
                if (excelcellsStudentNumber.Value2 != null)
                {
                 
                    StudentNumber = int.Parse(excelcellsStudentNumber.Value2.ToString());
                }
             
                else
                {                   
                    StudentNumber = 0;
                }          
                StudentNumbers[k] = StudentNumber;
                BeginList++;
            }
            return StudentNumbers;
        }

    }
}
