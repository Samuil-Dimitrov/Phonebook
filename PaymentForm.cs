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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Phonebook
{
    public partial class PaymentForm : Form
    {
        Connection connection = new Connection();

        public PaymentForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Change datetimepicker to be now writeable in
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 1;
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Invoice = textBox1.Text;
            payment.PaymentDate = dateTimePicker1.Value.Date;
            payment.PhoneNumber = textBox2.Text;
            payment.PhoneBill = Decimal.Parse(textBox3.Text);
            // 0 for payed 1 for unpayed
            payment.PaymentStatus = comboBox1.SelectedIndex == 0 ? true : false;
            connection.Insert(payment);
            displayData();
        }

        private void displayData()
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Payment", connection.connect))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[1].Value);
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox1.SelectedIndex = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value) ? 0 : 1; // 0 for payed 1 for unpayed
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Invoice = textBox1.Text;
            payment.PaymentDate = dateTimePicker1.Value.Date;
            payment.PhoneNumber = textBox2.Text;
            payment.PhoneBill = Decimal.Parse(textBox3.Text);
            // 0 for payed 1 for unpayed
            payment.PaymentStatus = comboBox1.SelectedIndex == 0 ? true : false;
            connection.Update(payment);
            displayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Invoice = textBox1.Text;
            payment.PaymentDate = dateTimePicker1.Value.Date;
            payment.PhoneNumber = textBox2.Text;
            payment.PhoneBill = Decimal.Parse(textBox3.Text);
            // 0 for payed 1 for unpayed
            payment.PaymentStatus = comboBox1.SelectedIndex == 0 ? true : false;
            connection.Delete(payment);
            displayData();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Select No 1
            string phoneNumber = textBox2.Text;
            DateTime startDate = dateTimePicker2.Value.Date;
            DateTime endDate = dateTimePicker3.Value.Date;

            var connect = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\LENOVO\Desktop\Phonebook.accdb");
            connect.Open();
            string mySelect = "SELECT Invoice, PaymentDate, PhoneNumber, PhoneBill, PaymentStatus " +
                                 "FROM Payment " +
                                 "WHERE PaymentDate BETWEEN @StartDate AND @EndDate " +
                                 "AND PhoneNumber = @PhoneNumber " +
                                 "AND PaymentStatus = False";

            using (var cmd = new OleDbCommand(mySelect, connect))
            {
                // Use parameters to avoid SQL injection and ensure correct date formatting
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        //Join name of the customer


        private void button5_Click(object sender, EventArgs e)
        {
            displayData();
        }
    }
}
