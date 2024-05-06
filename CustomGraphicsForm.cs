using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Phonebook
{
    public partial class CustomGraphicsForm : Form
    {
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

            var connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\LENOVO\Desktop\Phonebook.accdb");
            var command = connect.CreateCommand();
            connect.Open();
            string mySelect = $"Select PhoneBill, YEAR(PaymentDate) as PaymentYear " +
                $"from Payment WHERE [PhoneNumber] = '{phoneNumber}'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, connect);
            chart1.Titles.Clear();
            chart1.Titles.Add("Paid by year");

            DataSet ds = new DataSet();
            adapt.Fill(ds);
            chart1.DataSource = ds.Tables[0];

            chart1.Series[0].XValueMember = "PaymentYear";
            chart1.Series[0].YValueMembers = "PhoneBill";

            //Bind the DataTable with Chart
            chart1.DataBind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string phoneNumber = textBox1.Text;

            var connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\LENOVO\Desktop\Phonebook.accdb");
            var command = connect.CreateCommand();
            connect.Open();
            string mySelect = $"Select PhoneBill, MONTH(PaymentDate) as PaymentMonth " +
                $"from Payment WHERE [PhoneNumber] = '{phoneNumber}'";
            OleDbDataAdapter adapt = new OleDbDataAdapter(mySelect, connect);
            chart1.Titles.Clear();
            chart1.Titles.Add("Paid by month");

            DataSet ds = new DataSet();
            adapt.Fill(ds);
            chart1.DataSource = ds.Tables[0];

            chart1.Series[0].XValueMember = "PaymentMonth";
            chart1.Series[0].YValueMembers = "PhoneBill";
            //Bind the DataTable with Chart
            chart1.DataBind();
        }
    }
}
