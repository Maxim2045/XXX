using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Diagnostics;//Для убивание процессов
using System.Data.SqlClient;


namespace WpfAppVedomost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {     
        public MainWindow()
        {                  
           InitializeComponent();                               
        }
        public void CloseProcess(string Process_Name)
        {
            Process[] processes = Process.GetProcessesByName(Process_Name); 

            foreach (Process process in processes) 
            {
                process.Kill();
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e) //сохранение
        {
            Save save = new Save();
            save.SaveClick(docBox);
            CloseProcess("WINWORD");
        }
        private void Load_Click(object sender, RoutedEventArgs e) //Загрузка документа(шаблона)
        {

            InputExcel Students = new InputExcel();
            int LastRow=Students.Initialization();
            string [] StudentNames = Students.FullNameDataExcel(LastRow);
            int[] StudentNumber = Students.StudentNumberDataExcel(LastRow);
            CloseProcess("Excel");
            InputWord doc = new InputWord();
            doc.DataWord(LastRow, StudentNames, StudentNumber);
            CloseProcess("WINWORD");
        }
        private void Print_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {
                   
                pd.PrintVisual(docBox as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)docBox.Document).DocumentPaginator), "Печать документа");
            }
            else MessageBox.Show("Печать отменена");
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {

            Edit edit = new Edit();
            edit.EditClick(docBox);
            CloseProcess("WINWORD");
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
