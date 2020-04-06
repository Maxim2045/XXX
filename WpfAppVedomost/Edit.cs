using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Documents;
using System.IO;
using System.Windows.Controls;

namespace WpfAppVedomost
{
    class Edit
    {
        public void EditClick(RichTextBox docBox)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "RichText Files (*.rtf)|*.rtf|All files (*.*)|*.*",
                InitialDirectory = Path.Combine(
               Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]))
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
            else MessageBox.Show("Отмена редактирования");
        }
    }
}
