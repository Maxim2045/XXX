using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Excel = Microsoft.Office.Interop.Excel;//Для эксель

using Word = Microsoft.Office.Interop.Word;
using System.Windows.Xps.Packaging;
using System.Windows.Xps; //Для вывода неформатируемого текста
using Microsoft.Win32;//Для RichTextBox
using System.IO;
using System.Diagnostics;//Для убивание процессов

namespace WpfAppVedomost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Excel.Application excelapp;
        //private Excel.Window excelWindow;

        private Excel.Workbooks excelappworkbooks;
        private Excel.Workbook excelappworkbook;

        private Excel.Sheets excelsheets;
        private Excel.Worksheet excelworksheet;

        private Excel.Range excelcellsStudentNames;
        private Excel.Range excelcellsStudentNumber;
       
        public MainWindow()
        {
            InitializeComponent();
        }
        public void CloseProcess(string Process_Name)
        {
            Process[] processes = Process.GetProcessesByName(Process_Name); // Получим все процессы 

            foreach (Process process in processes) // В цикле их переберём
            {
                process.Kill(); // завершим процесс
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e) //сохранение
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*"
            };
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
            CloseProcess("WINWORD");
        }
        private void Load_Click(object sender, RoutedEventArgs e) //Загрузка документа(шаблона)
        {
            string StudentName;
            int StudentNumber;
            excelapp = new Excel.Application();
            // excelapp.Visible = true;
            excelappworkbooks = excelapp.Workbooks;
            //Открываем книгу и получаем на нее ссылку
            FileDialog selectExcel = new OpenFileDialog();
            selectExcel.ShowDialog();
            excelappworkbook = excelapp.Workbooks.Open(selectExcel.FileName,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                     Type.Missing, Type.Missing);
            excelsheets = excelappworkbook.Worksheets;
            //Получаем ссылку на лист 1
            excelworksheet = (Excel.Worksheet)excelsheets.get_Item(1);
            int BeginList = 3;
            string Crutch; //Для перевода в нужный вид(А3, А4 и т.д.)
            int iLastRow = excelworksheet.Cells[excelworksheet.Rows.Count, "A"].End[Excel.XlDirection.xlUp].Row-2;
            string[] StudentNames = new string[iLastRow];
            int[] StudentNumbers = new int[iLastRow];

            for (int k = 0; k < iLastRow; k++)
            {
                Crutch = BeginList.ToString();
                var NameCell = string.Join(string.Empty, new string[] { "A", Crutch });
                var NubmerCell = string.Join(string.Empty, new string[] { "B", Crutch });
                excelcellsStudentNames = excelworksheet.get_Range(NameCell, Type.Missing);
                excelcellsStudentNumber = excelworksheet.get_Range(NubmerCell, Type.Missing);
                if (excelcellsStudentNames.Value2 != null && excelcellsStudentNumber.Value2!=null)
                {
                    StudentName = Convert.ToString(excelcellsStudentNames.Value2);
                    StudentNumber = int.Parse(excelcellsStudentNumber.Value2.ToString());
                }
                
                
                else  if (excelcellsStudentNames.Value2 == null)
                    {
                        StudentName = "";
                        StudentNumber = int.Parse(excelcellsStudentNumber.Value2);
                    }
                else
                    {
                        StudentName = Convert.ToString(excelcellsStudentNames.Value2);
                        StudentNumber = 0;
                    }
                
                StudentNames[k] = StudentName;
                StudentNumbers[k] = StudentNumber;
                BeginList++;
            }          
            CloseProcess("Excel");
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //Загружаем документ
            Microsoft.Office.Interop.Word.Document doc = null;
            object fileName = "D:\\Загрузки\\MyApps\\Диплом2019-2020\\XXX\\WpfAppVedomost\\bin\\Debug\\Vedomost.rtf";
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;
            doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);
            //Указываем таблицу в которую будем помещать данные (таблица должна существовать в шаблоне документа!)
            Microsoft.Office.Interop.Word.Table tableVedomost = app.ActiveDocument.Tables[1];
            for (int k = 0; k < iLastRow; k++)
            {
                tableVedomost.Rows.Add();
                tableVedomost.Cell(k + 4, 1).Range.Text =(k + 1).ToString();
                tableVedomost.Cell(k + 4, 2).Range.Text = StudentNames[k].ToString();
                tableVedomost.Cell(k + 4, 3).Range.Text = StudentNumbers[k].ToString();
                                                   
            }
            // app.Visible = true;
            doc.SaveAs("D:\\Загрузки\\MyApps\\Диплом2019-2020\\XXX\\WpfAppVedomost\\bin\\Debug\\Vedomost2.rtf");
            CloseProcess("WINWORD");
        }
       /* private void Print_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument documentToPrint = new PrintDocument();
            printDialog.Document = documentToPrint;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                StringReader reader = new StringReader(docBox.Text);
                documentToPrint.PrintPage += new PrintPageEventHandler(DocumentToPrint_PrintPage);
                documentToPrint.Print();
            }
        }

        private void DocumentToPrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(eintragRichTextBox.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            Font PrintFont = this.eintragRichTextBox.Font;
            SolidBrush PrintBrush = new SolidBrush(Color.Black);

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(Line, PrintFont, PrintBrush, LeftMargin, YPosition, new StringFormat());
                Count++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }*/ //Нашел инфу, что надо самому RichTextBox переписать, так будет быстрее работать. Пока не разобрался, как это делать
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    else
                        doc.Load(fs, DataFormats.Xaml);
                }
            }
            CloseProcess("WINWORD");
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            PasswordWindow passwordWindow = new PasswordWindow();

            if (passwordWindow.ShowDialog() == true)
            {
                if (passwordWindow.Password == "12345678")
                    MessageBox.Show("Авторизация пройдена");
                else
                    MessageBox.Show("Неверный пароль");
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
        }
    }
}
