using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    public partial class Form1 : Form
    {
        Connection connection = new Connection();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Change datetimepicker to be now writeable in
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 1;
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
        }
    }
}
