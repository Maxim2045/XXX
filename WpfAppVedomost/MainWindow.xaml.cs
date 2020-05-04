using System;
using System.Windows;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Controls;
using System.Drawing;

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
           cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
           cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

        }
        private void CmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                docBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }
        private void CmbFontSize_TextChanged(object sender, TextChangedEventArgs e)
        {
             try
            {
                docBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmbFontSize.Text);
            }
            catch (Exception)
            {
                try
                {
                    docBox.FontSize = int.Parse(cmbFontSize.Text);
                }
                catch(Exception)
                {
                    MessageBox.Show("Редактировование разных кеглей приложение не поддерживает, удалите строку и заново введите");
                }
            }
            
        }
        private void DocBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = docBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = docBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = docBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = docBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmbFontFamily.SelectedItem = temp;
            temp = docBox.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmbFontSize.Text = temp.ToString();
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
            _ = new List<string>();
            List<string> Info = Students.Initialization();                
            InputWord doc = new InputWord();           
            doc.InsertTableInDoc(Info);                                                 
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

        private void Print_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Print print = new Print();
            print.PrintClick(docBox);
        }

        private void Edit_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditClick(docBox);
            CloseProcess("WINWORD");
            //docBox.ScrollToEnd();
        }
    }
}
