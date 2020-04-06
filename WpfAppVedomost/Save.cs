using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using System.Windows.Controls;

namespace WpfAppVedomost
{
    class Save
    {
        public void SaveClick(RichTextBox docBox)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*",
                InitialDirectory = Path.Combine(
                 Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]))  //По их выбору поменяю папку дефолтную
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
            else MessageBox.Show("Файл не сохранен");
            File.Delete(Path.Combine(
           Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.rtf"));
        }
    }
}
