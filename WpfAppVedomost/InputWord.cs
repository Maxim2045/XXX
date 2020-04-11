using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace WpfAppVedomost
{
    class InputWord
    {
        public  void InsertTableInDoc(int LastRow, string[] StudentNames, int[] StudentNumbers)
        {
            // Open a WordprocessingDocument for editing using the filepath.

            // Assign a reference to the existing document body.
            string filepath = Path.Combine(
                            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost.docx"
                                         );
            using (WordprocessingDocument wordDoc2 = WordprocessingDocument.Open(filepath, true))
            {
                var doc = wordDoc2.MainDocumentPart.Document;
                Table table = doc.MainDocumentPart.Document.Body.Elements<Table>().FirstOrDefault();
         
                for (int i = 0; i < LastRow; i++)
                {
                    TableRow tr = new TableRow();
                    TableCell tablecell1 = new TableCell(new Paragraph(new Run(new Text((i+1).ToString()))));
                    TableCell tablecell2 = new TableCell(new Paragraph(new Run(new Text(StudentNames[i]))));
                    TableCell tablecell3 = new TableCell(new Paragraph(new Run(new Text(StudentNumbers[i].ToString()))));
                    TableCell tablecell4 = new TableCell(new Paragraph(new Run(new Text())));
                    TableCell tablecell5 = new TableCell(new Paragraph(new Run(new Text())));
                    TableCell tablecell6 = new TableCell(new Paragraph(new Run(new Text())));
                    TableCell tablecell7 = new TableCell(new Paragraph(new Run(new Text())));
                    TableCell tablecell8 = new TableCell(new Paragraph(new Run(new Text())));
                    TableCell tablecell9 = new TableCell(new Paragraph(new Run(new Text())));
                    TableCell tablecell10 = new TableCell(new Paragraph(new Run(new Text())));

                    tr.Append(tablecell1, tablecell2, tablecell3, tablecell4, tablecell5, tablecell6, tablecell7, tablecell8, tablecell9, tablecell10);
                    table.AppendChild(tr);
                }

            }


        }
      /*  public void DataWord(int LastRow, string[] StudentNames, int [] StudentNumbers)
        {
           
            object fileName = Path.Combine(
                              Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost.rtf"
                                           );
            
            for (int k = 0; k < LastRow; k++)
            {
                tableVedomost.Rows.Add();/*
                tableVedomost.Cell(k + 4, 1).Range.Text = (k + 1).ToString();
                tableVedomost.Cell(k + 4, 2).Range.Text = StudentNames[k].ToString();
                tableVedomost.Cell(k + 4, 3).Range.Text = StudentNumbers[k].ToString();
                doc.Content.Text = "ADadsefsf";

            }
            doc.SaveAs(Path.Combine(
            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.rtf"));
            doc.SaveAs(Path.Combine(
            Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Vedomost2.doc"));
        }*/
    }
}
