using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subscription subscription = new Subscription();
            subscription.PhoneNumber = textBox1.Text;
            subscription.MonthlyBill = decimal.Parse(textBox2.Text);
            subscription.FreeCallMinutesCount = int.Parse(textBox3.Text);
            subscription.PricePerMinute = decimal.Parse(textBox4.Text);
            subscription.MinutesOutsideEU = int.Parse(textBox5.Text);
            subscription.PricePerMinuteEU = decimal.Parse(textBox6.Text);
            subscription.FreeSMSCount = int.Parse(textBox7.Text);
            subscription.PricePerSMS = decimal.Parse(textBox8.Text);
            subscription.InvoiceDate = dateTimePicker1.Value.Date;
            connection.Insert(subscription);
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
    }
}
