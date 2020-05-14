using Microsoft.Win32;
using System;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using Microsoft.Office.Interop.Word;

namespace WpfAppVedomost
{
    class Edit
    {
        public void EditClick(RichTextBox docBox)
        {
            docBox.Document.Blocks.Clear();
            OpenFileDialog ofd = new OpenFileDialog //Выбор файла для редактирования
            {
                Filter = "Word files (*.docx)|*.docx|All files (*.*)|*.*",
                InitialDirectory = Path.Combine(
              Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]))
            };
            if (ofd.ShowDialog() == true)
            {
            Microsoft.Office.Interop.Word.Application wordObject = new Microsoft.Office.Interop.Word.Application();
            object File = ofd.FileName;
            object nullobject = System.Reflection.Missing.Value;
            wordObject.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            _Document docs = wordObject.Documents.Open(ref File, ref nullobject, ref nullobject, ref nullobject, ref nullobject, 
                                                       ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject,
                                                       ref nullobject, ref nullobject, ref nullobject, ref nullobject, ref nullobject);
            docs.ActiveWindow.Selection.WholeStory();
            docs.ActiveWindow.Selection.Copy();
            docBox.Paste();
            docs.Close(ref nullobject, ref nullobject, ref nullobject);
            wordObject.Quit();
            }
            else MessageBox.Show("Отмена редактирования");          
        }
    }
}
