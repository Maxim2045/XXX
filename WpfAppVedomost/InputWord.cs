using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WpfAppVedomost
{
    class InputWord //Вставка данных в новую ведомость
    {
        public TableCell Celled(string InputText) //Обработка ячейки
        {          
            var tableCell = new TableCell(); // Ячейка
            var paragraph = new Paragraph(); // Параграф
            var run = new Run();
            var text = new Text(InputText); // Вводимый текст
            
            RunProperties runProperties = new RunProperties();//Форматирование текста
            FontSize fontSize = new FontSize() { Val = "20" };
            runProperties.Append(fontSize);

            run.Append(runProperties);
            run.Append(text);

            paragraph.Append(run);
            tableCell.Append(paragraph);
           
            return tableCell;
        }
        public void InsertTableInDoc(List<string> Info)
        {
            string filepath = Path.Combine(
                            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost.docx"
                                         );
            string filepath2 = Path.Combine(
                            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\NewVedomost.docx"
                                         );
         
                File.Copy(filepath, filepath2); //Создание нового файла ведомости
           
            using (WordprocessingDocument wordDoc2 = WordprocessingDocument.Open(filepath2, true))
            {
                var doc = wordDoc2.MainDocumentPart.Document;
                Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().FirstOrDefault();
                int k = 1;
                for (int i = 0; i < Info.Count; i++)
                {
                    TableRow tr = new TableRow();
                    for (int j = 0; j < 10; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                tr.Append(Celled(k.ToString())); // Номер строки
                                k++;
                                break;
                            case 1:
                                tr.Append(Celled(Info[i].ToString())); // ФИО                              
                                break;
                            case 2:
                                tr.Append(Celled(Info[i + 1].ToString())); // Номер зачетки
                                break;
                            default:
                                tr.Append(Celled("")); // Пустые значения для незаполняемых ячеек
                                break;
                        }
                    }
                    table.Append(tr);
                    i++;
                }
            }           
        }    
    }
}
