using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Controls;

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
           cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source); // Список шрифтов
           cmbFontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 }; // Размеры шрифтов

        }
        private void CmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                docBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }
        private void CmbFontSize_TextChanged(object sender, TextChangedEventArgs e) // Обработчик размера шрифта
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
                   // MessageBox.Show("Редактировование разных кеглей приложение не поддерживает, удалите строку и заново введите");
                }
            }
            
        }
        private void DocBox_SelectionChanged(object sender, RoutedEventArgs e) // Обработчик изменения курсива, жирного, подчеркнутого шрифта
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
      /*  public void CloseProcess(string Process_Name) // Киллер процессов для будущего программиста, кто не захочет разбираться с правильным закрытием процессов
        {
            Process[] processes = Process.GetProcessesByName(Process_Name); 

            foreach (Process process in processes) 
            {
                process.Kill();
            }
        }*/
        private void Save_Click(object sender, RoutedEventArgs e) // Сохранение данных с RichTextBox
        {
            Save save = new Save();
            save.SaveClick(docBox);
        }
       
        private void Load_Click(object sender, RoutedEventArgs e) 
        {
            
           
            InputExcel Students = new InputExcel(); // Поучение данных из файла Excel
            _ = new List<string>();
            List<string> Info = Students.Initialization();
          
                if (Info != null)
                {
                    InputWord doc = new InputWord();
              
                // Внесение данных в Word файл 
                     try
                     {
                          doc.InsertTableInDoc(Info);
                          MessageBox.Show("Ведомость успешно создана!");
                     }
                     catch(Exception)
                     {
                    MessageBox.Show("Удалите или переименуйте ранее созданную ведомосость");
                     }
                  
                }
                else
                {
                    MessageBox.Show("Отмена формирования");
                }          
        }
 
        private void Print_Click(object sender, System.Windows.Input.MouseButtonEventArgs e) // Печать данных c RichTextBox
        {
            Print print = new Print();
            print.PrintClick(docBox);
        }
        private void Menu_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MenuWindow window = new MenuWindow();
            window.Show();
            Vedomost.Close();
        }
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow window = new MenuWindow();
            window.Show();
            Vedomost.Close();
        }
        private void Edit_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Edit edit = new Edit();
            edit.EditClick(docBox);
            //docBox.ScrollToEnd(); // Для перевода курсора в конец RichTextBox
        }
    }
}
