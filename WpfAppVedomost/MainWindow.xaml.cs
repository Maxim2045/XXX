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

        string[] StudentNames = new string[10];
        int[] StudentNumbers = new int[10];
        public MainWindow()
        {
            InitializeComponent();

        }
        private void Save_Click(object sender, RoutedEventArgs e) //сохранение
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*";
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

            for (int k = 0; k < 10; k++)
            {
                Crutch = BeginList.ToString();
                var NameCell = string.Join(string.Empty, new string[] { "A", Crutch });
                var NubmerCell = string.Join(string.Empty, new string[] { "B", Crutch });
                excelcellsStudentNames = excelworksheet.get_Range(NameCell, Type.Missing);
                excelcellsStudentNumber = excelworksheet.get_Range(NubmerCell, Type.Missing);
                StudentName = Convert.ToString(excelcellsStudentNames.Value2);
                StudentNumber = int.Parse(excelcellsStudentNumber.Value2);
                StudentNames[k] = StudentName;
                StudentNumbers[k] = StudentNumber;
                BeginList++;
            }
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog pDialog = new PrintDialog(); //Открытие диалогового окна печати
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

           
            Nullable<Boolean> print = pDialog.ShowDialog();
            if (print == true)
            {
                XpsDocument xpsDocument = new XpsDocument("D:\\FixedDocumentSequence.xps", FileAccess.ReadWrite); //Возможноть выбора страниц
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            //Загружаем документ
            Microsoft.Office.Interop.Word.Document doc = null;
            object fileName = "D:\\Загрузки\\MyApps\\Диплом2019-2020\\Файлы для Диплома\\4361-22 - CopyExxx.rtf";
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;
            doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);
            //Указываем таблицу в которую будем помещать данные (таблица должна существовать в шаблоне документа!)
            Microsoft.Office.Interop.Word.Table tableVedomost = app.ActiveDocument.Tables[1];

            for (int k = 0; k < 10; k++)
            {
                tableVedomost.Cell(k + 4, 2).Range.Text = StudentNames[k].ToString();
                tableVedomost.Cell(k + 4, 3).Range.Text = StudentNumbers[k].ToString();
            }
            // app.Visible = true;
            doc.SaveAs("4361 - 22 CopyExxxx");
            fileName = "D:\\Загрузки\\MyApps\\Диплом2019-2020\\Файлы для Диплома\\4361-22 - CopyExxxx.rtf";
            doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
           ref missing, ref missing, ref missing, ref missing, ref missing,
           ref missing, ref missing, ref missing, ref missing, ref missing,
           ref missing, ref missing, ref missing);
            doc.Close();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                TextRange doc2 = new TextRange(docBox.Document.ContentStart, docBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open))
                {
                    if (Path.GetExtension(ofd.FileName).ToLower() == ".rtf")
                        doc2.Load(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(ofd.FileName).ToLower() == ".txt")
                        doc2.Load(fs, DataFormats.Text);
                    else
                        doc2.Load(fs, DataFormats.Xaml);
                }
            }
        }
    }
}
