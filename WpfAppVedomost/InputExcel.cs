using System;
using System.IO;
using Microsoft.Win32;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;


namespace WpfAppVedomost
{
    class InputExcel
    {

        public List<string> Initialization()
        {
            List<string> Info = new List<string>();//Лист для данных о студентах
            FileDialog selectExcel = new OpenFileDialog //Выбор файла с данными о студентах
            {
                Filter = "файл Excel (*.xlsx)|*.xlsx",
                InitialDirectory = Path.Combine(
                Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]))
            };
            try
            {
                if (selectExcel.ShowDialog() == true)
                {
                    using (SpreadsheetDocument doc = SpreadsheetDocument.Open(selectExcel.FileName, false))
                    {
                        Sheet sheet = doc.WorkbookPart.Workbook.Sheets.GetFirstChild<Sheet>();
                        Worksheet worksheet = (doc.WorkbookPart.GetPartById(sheet.Id.Value) as WorksheetPart).Worksheet;
                        IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Descendants<Row>();
                        int counter = 0;
                        int counter2 = 0;
                        foreach (Row row in rows)
                        {
                            counter2 = 0;//Счетчик для разделения данных, так как в одном и том же листе хранятся все данные о студентах
                            counter++;//Счетчик для пропуска первых двух строк в файле с данными, так как они содержат названия полей

                            switch (counter)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                default:

                                    foreach (Cell cell in row.Descendants<Cell>())
                                    {
                                        counter2++;
                                        switch (counter2)
                                        {
                                            case 1:
                                                Info.Add(GetCellValue(doc, cell));
                                                break;
                                            case 2:
                                                Info.Add(GetCellValue(doc, cell));
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    return Info;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        } 
     
        private string GetCellValue(SpreadsheetDocument doc, Cell cell) //Получение данных из ячейки
        {   if (cell.CellValue == null)
            {
                return  " ";
            }
            else
            {
                string value = cell.CellValue.InnerText;
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return doc.WorkbookPart.SharedStringTablePart.SharedStringTable.ChildElements.GetItem(int.Parse(value)).InnerText;
                }
                return value;
            }            
        }   
    }
}
