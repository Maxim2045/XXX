using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WpfAppVedomost
{
    class InputWord
    {
        public TableCell Celled(string InputText)
        {
           
            var tc = new TableCell();
            var paragraph = new Paragraph();
            var run = new Run();
            var text = new Text(InputText);

            
            RunProperties runProperties1 = new RunProperties();
            FontSize fontSize1 = new FontSize() { Val = "20" };
            runProperties1.Append(fontSize1);

            run.Append(runProperties1);
            run.Append(text);

            paragraph.Append(run);
            tc.Append(paragraph);
           
            return tc;
        }
        public  void InsertTableInDoc(List<string> Info)
        {
            string filepath = Path.Combine(
                            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost.docx"
                                         );
            string filepath2 = Path.Combine(
                            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\NewVedomost.docx"
                                         );
            try
            {
                File.Copy(filepath, filepath2);
            }
            catch (Exception)
            {
                MessageBox.Show("Удалите или перемеименуйте ранее созданную ведомость");
            }
            using (WordprocessingDocument wordDoc2 = WordprocessingDocument.Open(filepath2, true))
            {
                var doc = wordDoc2.MainDocumentPart.Document;
                Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().FirstOrDefault();
                
                int k = 1;
                for (int i = 0; i < Info.Count; i++)
                   {
                    TableRow tr = new TableRow();
                    for (int j=0;j<10;j++)
                    {
                        
                        switch (j)
                        {
                            case 0:

                                tr.Append(Celled(k.ToString()));
                                k++;
                                break;
                            case 1:
                                tr.Append(Celled(Info[i].ToString()));
                                
                                break;
                            case 2:
                                tr.Append(Celled(Info[i+1].ToString()));
                                break;
                            default:
                                tr.Append(Celled(""));                              
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
