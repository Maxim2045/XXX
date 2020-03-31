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
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;


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
            PasswordWindow passwordWindow = new PasswordWindow();

            if (passwordWindow.ShowDialog() == true)
            {
                if (passwordWindow.Password == "12345678")
                {
                    MessageBox.Show("Авторизация пройдена");
                    InitializeComponent();
                }
                else
                    MessageBox.Show("Неверный пароль");
            }
            else
            {
                MessageBox.Show("Авторизация не пройдена");
            }
            
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
            SaveFileDialog sfd = new SaveFileDialog()
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
            object fileName = Path.Combine(
    Path.GetDirectoryName(Environment.GetCommandLineArgs()[0])+"\\Vedomost.rtf" //то woo будет содержать строку "d:\folder\keys"
    );
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
            doc.SaveAs(Path.Combine(
    Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.rtf"));
            
           
           CloseProcess("WINWORD");
        }
        private void Print_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                //use either one of the below      
                pd.PrintVisual(docBox as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)docBox.Document).DocumentPaginator), "Печать документа");
            }
        }
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
                    fs.Close();
                }              
            }
            File.Delete(Path.Combine(
    Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.rtf"));
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

        private void SQL_Click(object sender, RoutedEventArgs e)
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Dekanat;Integrated Security=True";
            string sqlExpression = "INSERT INTO Semester (NumberSemester) VALUES (18)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                connection.Close();
            }
            
        }
    }
}
