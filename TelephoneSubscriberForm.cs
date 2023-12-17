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
    public partial class TelephoneSubscriberForm : Form
    {
        Connection connection = new Connection();
        public TelephoneSubscriberForm()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelephoneSubscriber telephoneSubscriber = new TelephoneSubscriber();
            telephoneSubscriber.PhoneNumber = textBox1.Text;
            telephoneSubscriber.PersonalID = textBox2.Text;
            telephoneSubscriber.Names = textBox3.Text;
            telephoneSubscriber.Address = textBox4.Text;

            connection.Insert(telephoneSubscriber);
        }
    }
}
