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

namespace Phonebook
{
    public partial class TelephoneSubscriberForm : Form
    {
        Connection connection = new Connection();
        public TelephoneSubscriberForm()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void displayData()
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from TelephoneSubscriber", connection.connect))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelephoneSubscriber telephoneSubscriber = new TelephoneSubscriber();
            telephoneSubscriber.PhoneNumber = textBox1.Text;
            telephoneSubscriber.PersonalID = textBox2.Text;
            telephoneSubscriber.Names = textBox3.Text;
            telephoneSubscriber.Address = textBox4.Text;

            connection.Insert(telephoneSubscriber);
            displayData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelephoneSubscriber telephoneSubscriber = new TelephoneSubscriber();
            telephoneSubscriber.PhoneNumber = textBox1.Text;
            telephoneSubscriber.PersonalID = textBox2.Text;
            telephoneSubscriber.Names = textBox3.Text;
            telephoneSubscriber.Address = textBox4.Text;

            connection.Update(telephoneSubscriber);
            displayData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TelephoneSubscriber telephoneSubscriber = new TelephoneSubscriber();
            telephoneSubscriber.PhoneNumber = textBox1.Text;
            telephoneSubscriber.PersonalID = textBox2.Text;
            telephoneSubscriber.Names = textBox3.Text;
            telephoneSubscriber.Address = textBox4.Text;

            connection.Delete(telephoneSubscriber);
            displayData();
        }

        private void Clear(object sender, EventArgs e)
        {
            displayData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Select No 2
            string PersonalID = textBox2.Text; // Replace with the actual subscriber ID
            var connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LENOVO\Desktop\Phonebook.accdb";

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string mySelect = "SELECT P.Invoice, P.PaymentDate, S.PersonalID, S.PhoneNumber, P.PhoneBill, P.PaymentStatus " +
                                  "FROM Payment P " +
                                  "INNER JOIN TelephoneSubscriber S ON P.PhoneNumber = S.PhoneNumber " +
                                  "WHERE S.PersonalID = @PersonalID";

                using (var command = new OleDbCommand(mySelect, connection))
                {
                    command.Parameters.AddWithValue("@PersonalID", PersonalID);

                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }
    }
}
