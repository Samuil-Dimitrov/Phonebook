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
            TelephoneSubscriber.TelephoneSubscriberBuilder subscriberBuilder = new TelephoneSubscriber.TelephoneSubscriberBuilder();
            TelephoneSubscriber telephoneSubscriber = subscriberBuilder
              .SetPhoneNumber(textBox1.Text)
              .SetPersonalID(textBox2.Text)
              .SetNames(textBox3.Text)
              .SetAddress(textBox4.Text)
              .Build();
            PhonebookFacade facade = new PhonebookFacade(new Connection()); // Create facade with connection
            facade.AddSubscriber(telephoneSubscriber); // Pass the built object to facade
            displayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TelephoneSubscriber.TelephoneSubscriberBuilder subscriberBuilder = new TelephoneSubscriber.TelephoneSubscriberBuilder();
            TelephoneSubscriber telephoneSubscriber = subscriberBuilder
                                                        .SetPhoneNumber(textBox1.Text)
                                                        .SetPersonalID(textBox2.Text)
                                                        .SetNames(textBox3.Text)
                                                        .SetAddress(textBox4.Text)
                                                        .Build();
            PhonebookFacade facade = new PhonebookFacade(new Connection());
            facade.UpdateSubscriber(telephoneSubscriber);
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
            TelephoneSubscriber.TelephoneSubscriberBuilder subscriberBuilder = new TelephoneSubscriber.TelephoneSubscriberBuilder();
            TelephoneSubscriber telephoneSubscriber = subscriberBuilder
                                                        .SetPhoneNumber(textBox1.Text)
                                                        .SetPersonalID(textBox2.Text)
                                                        .SetNames(textBox3.Text)
                                                        .SetAddress(textBox4.Text)
                                                        .Build();
            PhonebookFacade facade = new PhonebookFacade(new Connection());
            facade.DeleteSubscriber(telephoneSubscriber.PhoneNumber);
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

            PhonebookFacade facade = new PhonebookFacade(new Connection()); // Create facade with connection
            DataTable paymentData = facade.GetSubscriberPayments(PersonalID); // Call facade method

            if (paymentData != null) // Check if data retrieval was successful
            {
                dataGridView1.DataSource = paymentData;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Select No 3
            string PersonalID = textBox2.Text; // Replace with the actual subscriber ID
            PhonebookFacade facade = new PhonebookFacade(new Connection()); // Create facade with connection
            DataTable subscribersData = facade.GetSubscribersWithMultipleNumbers(); // Call facade method

            if (subscribersData != null) // Check if data retrieval was successful
            {
                dataGridView1.DataSource = subscribersData;
            }
        }
    }
}
