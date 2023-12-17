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
    }
}
