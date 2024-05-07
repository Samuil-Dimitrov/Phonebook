using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phonebook
{
    // strategy interface
    public interface IDataFetchingStrategy
    {
        DataSet FetchData(string phoneNumber);
    }

    //strategy year
    public class FetchDataByYear : IDataFetchingStrategy
    {
        public DataSet FetchData(string phoneNumber)
        {
            var connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\LENOVO\Desktop\Phonebook.accdb");
            connect.Open();
            string mySelect = $"Select PhoneBill, YEAR(PaymentDate) as PaymentYear " +
                $"from Payment WHERE [PhoneNumber] = '{phoneNumber}'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, connect);

            DataSet ds = new DataSet();
            adapt.Fill(ds);

            connect.Close();

            return ds;
        }
    }

    // strategy month
    public class FetchDataByMonth : IDataFetchingStrategy
    {
        public DataSet FetchData(string phoneNumber)
        {
            var connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\LENOVO\Desktop\Phonebook.accdb");
            connect.Open();
            string mySelect = $"Select PhoneBill, MONTH(PaymentDate) as PaymentMonth " +
                $"from Payment WHERE [PhoneNumber] = '{phoneNumber}'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, connect);

            DataSet ds = new DataSet();
            adapt.Fill(ds);

            connect.Close();

            return ds;
        }
    }

    public partial class CustomGraphicsForm : Form
    {
        private IDataFetchingStrategy fetchingStrategy;

        public CustomGraphicsForm()
        {
            InitializeComponent();
        }

        private void CustomGraphicsForm_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string phoneNumber = textBox1.Text;

            // Use the selected strategy
            fetchingStrategy = new FetchDataByYear();

            BindChartData(phoneNumber);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string phoneNumber = textBox1.Text;

            // Use the selected strategy
            fetchingStrategy = new FetchDataByMonth();

            BindChartData(phoneNumber);
        }

        private void BindChartData(string phoneNumber)
        {
            // Fetch data using the selected strategy
            DataSet ds = fetchingStrategy.FetchData(phoneNumber);

            // Clear existing series
            chart1.Series.Clear();

            // Add new series
            Series series = chart1.Series.Add("PhoneBill");
            series.XValueMember = ds.Tables[0].Columns[1].ColumnName; // Assuming the date column is at index 1
            series.YValueMembers = ds.Tables[0].Columns[0].ColumnName; // Assuming the phone bill column is at index 0

            // Set chart title
            chart1.Titles.Clear();
            chart1.Titles.Add("Paid by " + (fetchingStrategy is FetchDataByYear ? "year" : "month"));

            // Set data source
            chart1.DataSource = ds.Tables[0];

            // Bind the data
            chart1.DataBind();
        }
    }
}
