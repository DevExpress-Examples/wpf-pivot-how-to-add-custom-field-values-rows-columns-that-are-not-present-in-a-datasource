using CustomDatesPivot;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataTable Table;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dateEdit1.DateTime = DateTime.Now;
            dateEdit2.DateTime = DateTime.Now.AddMonths(12);
            Table = CreatePivotTable(100);
            pivot.DataSource = Table;
        }

        private static DataTable CreatePivotTable(int RowCount)
        {
            Random rnd = new Random();

            DataTable tbl = new DataTable();
            tbl.Columns.Add("ID", typeof(int));
            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("Checked", typeof(bool));
            tbl.Columns.Add("Number", typeof(int));
            tbl.Columns.Add("Value", typeof(decimal));
            tbl.Columns.Add("AltValue", typeof(decimal));
            tbl.Columns.Add("Date", typeof(DateTime));


            for (int i = 0; i < RowCount; i++)
            {
                DataRow row = tbl.Rows.Add(new object[] { i, String.Format("Name{0}", i % 9), i % 2 == 0, rnd.Next(10), rnd.Next(100, 1000), rnd.Next(100, 1000), DateTime.Now.AddDays(rnd.Next(300)) });
            }
            return tbl;
        }

        private void pivot_CustomFieldValueCells(object sender, DevExpress.Xpf.PivotGrid.PivotCustomFieldValueCellsEventArgs e)
        {
            int index = pivot.GetRowIndex(new object[] { null });
            if (index != -1)
                e.Remove(e.GetCell(false, index));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<string> DateFields = new List<string>();
            DateFields.Add("Date");
            List<DateTime> CustomDates = new List<DateTime>();
            DateTime date = dateEdit1.DateTime;
            while (date < dateEdit2.DateTime)
            {
                CustomDates.Add(date);
                switch (comboBox.Text)
                {
                    case "Year":
                        date = date.AddYears(1);
                        break;
                    case "Quarter":
                        date = date.AddMonths(3);
                        break;
                    case "Month":
                        date = date.AddMonths(1);
                        break;
                    default:
                        date = date.AddDays(1);
                        break;
                }
            }
            pivot.DataSource = new DateDataSourceWrapper(Table.DefaultView, DateFields, CustomDates);
        }
    }
}
