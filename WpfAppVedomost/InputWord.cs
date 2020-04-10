using System;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace WpfAppVedomost
{
    class InputWord
    {
        public void DataWord(int LastRow, string[] StudentNames, int [] StudentNumbers)
        {
            Word.Application app = new Word.Application();
            //Загружаем документ
            Word.Document doc = null;
            object fileName = Path.Combine(
                              Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost.rtf"
                                           );
            object falseValue = false;
            object trueValue = true;
            object missing = Type.Missing;
            doc = app.Documents.Open(ref fileName, ref missing, ref trueValue,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing);
            //Указываем таблицу в которую будем помещать данные (таблица должна существовать в шаблоне документа!)
            Word.Table tableVedomost = app.ActiveDocument.Tables[1];
            for (int k = 0; k < LastRow; k++)
            {
                tableVedomost.Rows.Add();
                tableVedomost.Cell(k + 4, 1).Range.Text = (k + 1).ToString();
                tableVedomost.Cell(k + 4, 2).Range.Text = StudentNames[k].ToString();
                tableVedomost.Cell(k + 4, 3).Range.Text = StudentNumbers[k].ToString();
            }
            doc.SaveAs(Path.Combine(
            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.rtf"));
            doc.SaveAs(Path.Combine(
            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.doc"));
        }
    }
}
