using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phonebook
{
    class Connection
    {
        OleDbConnection connect;
        OleDbCommand command;

        private void ConnectionTo()
        {
            connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\LENOVO\Desktop\Phonebook.accdb");
            command = connect.CreateCommand();
        }

        public Connection()
        {
            ConnectionTo();
        }

        public void Insert(Payment payment)
        {
            try
            {
                command.CommandText = $"Insert into Payment([Invoice],PaymentDate,[PhoneNumber],PhoneBill,PaymentStatus) values ('{payment.Invoice}','{payment.PaymentDate.Day}.{payment.PaymentDate.Month}.{payment.PaymentDate.Year}','{payment.PhoneNumber}',{payment.PhoneBill},{payment.PaymentStatus})";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect data");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }
    }
}
