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
    public partial class SubscriptionForm : Form
    {
        Connection connection = new Connection();

        public SubscriptionForm()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subscription.SubscriptionBuilder subscriptionBuilder = new Subscription.SubscriptionBuilder();
            Subscription subscription = subscriptionBuilder
                                            .SetPhoneNumber(textBox1.Text)
                                            .SetMonthlyBill(decimal.Parse(textBox2.Text))
                                            .SetFreeCallMinutesCount(int.Parse(textBox3.Text))
                                            .SetPricePerMinute(decimal.Parse(textBox4.Text))
                                            .SetMinutesOutsideEU(int.Parse(textBox5.Text))
                                            .SetPricePerMinuteEU(decimal.Parse(textBox6.Text))
                                            .SetFreeSMSCount(int.Parse(textBox7.Text))
                                            .SetPricePerSMS(decimal.Parse(textBox8.Text))
                                            .SetInvoiceDate(dateTimePicker1.Value.Date)
                                            .Build();
            connection.Insert(subscription);
            displayData();
        }

        private void telephoneSubscriberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelephoneSubscriberForm form3 = new TelephoneSubscriberForm();
            form3.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaymentForm form1 = new PaymentForm();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subscription.SubscriptionBuilder subscriptionBuilder = new Subscription.SubscriptionBuilder();
            Subscription subscription = subscriptionBuilder
                                            .SetPhoneNumber(textBox1.Text)
                                            .SetMonthlyBill(decimal.Parse(textBox2.Text))
                                            .SetFreeCallMinutesCount(int.Parse(textBox3.Text))
                                            .SetPricePerMinute(decimal.Parse(textBox4.Text))
                                            .SetMinutesOutsideEU(int.Parse(textBox5.Text))
                                            .SetPricePerMinuteEU(decimal.Parse(textBox6.Text))
                                            .SetFreeSMSCount(int.Parse(textBox7.Text))
                                            .SetPricePerSMS(decimal.Parse(textBox8.Text))
                                            .SetInvoiceDate(dateTimePicker1.Value.Date)
                                            .Build();
            connection.Update(subscription);
            displayData();
        }

        private void displayData()
        {
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Subscription", connection.connect))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[8].Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Subscription.SubscriptionBuilder subscriptionBuilder = new Subscription.SubscriptionBuilder();
            Subscription subscription = subscriptionBuilder
                                            .SetPhoneNumber(textBox1.Text)
                                            .SetMonthlyBill(decimal.Parse(textBox2.Text))
                                            .SetFreeCallMinutesCount(int.Parse(textBox3.Text))
                                            .SetPricePerMinute(decimal.Parse(textBox4.Text))
                                            .SetMinutesOutsideEU(int.Parse(textBox5.Text))
                                            .SetPricePerMinuteEU(decimal.Parse(textBox6.Text))
                                            .SetFreeSMSCount(int.Parse(textBox7.Text))
                                            .SetPricePerSMS(decimal.Parse(textBox8.Text))
                                            .SetInvoiceDate(dateTimePicker1.Value.Date)
                                            .Build();
            connection.Delete(subscription);
            displayData();
        }
    }
}
