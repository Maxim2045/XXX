using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfAppVedomost
{
    class Print
    {
        public void PrintClick(RichTextBox docBox)
        {
            PrintDialog pd = new PrintDialog();
            if ((pd.ShowDialog() == true))
            {

                pd.PrintVisual(docBox as Visual, "printing as visual");
                pd.PrintDocument((((IDocumentPaginatorSource)docBox.Document).DocumentPaginator), "Печать документа");
            }
            else MessageBox.Show("Печать отменена");
        }
    }
}
