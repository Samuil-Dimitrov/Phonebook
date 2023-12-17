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
        public OleDbConnection connect;
        public OleDbCommand command;

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
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        public void Update(Payment payment)
        {
            try
            {
                command.CommandText = $"Update Payment set PaymentDate = '{payment.PaymentDate.Day}.{payment.PaymentDate.Month}.{payment.PaymentDate.Year}',[PhoneNumber] = '{payment.PhoneNumber}',PhoneBill = {payment.PhoneBill},PaymentStatus = {payment.PaymentStatus} where [Invoice] = '{payment.Invoice}'";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        public void Delete(Payment payment)
        {
            try
            {
                command.CommandText = $"Delete from Payment where [Invoice] = '{payment.Invoice}'";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        public void Insert(Subscription subscription)
        {
            try
            {
                command.CommandText = $"Insert into Subscription([PhoneNumber],MonthlyBill,FreeCallMinutesCount,PricePerMinute,MinutesOutsideEU,PricePerMinuteEU,FreeSMSCount,PricePerSMS,InvoiceDate) values ('{subscription.PhoneNumber}',{subscription.MonthlyBill},{subscription.FreeCallMinutesCount},{subscription.PricePerMinute},{subscription.MinutesOutsideEU},{subscription.PricePerMinuteEU},{subscription.FreeSMSCount},{subscription.PricePerSMS},'{subscription.InvoiceDate.Day}.{subscription.InvoiceDate.Month}.{subscription.InvoiceDate.Year}')";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        public void Update(Subscription subscription)
        {
            try
            {
                command.CommandText = $"Update Subscription set MonthlyBill = {subscription.MonthlyBill}, FreeCallMinutesCount = {subscription.FreeCallMinutesCount}, PricePerMinute = {subscription.PricePerMinute}, MinutesOutsideEU = {subscription.MinutesOutsideEU}, PricePerMinuteEU={subscription.PricePerMinuteEU}, FreeSMSCount={subscription.FreeSMSCount}, PricePerSMS={subscription.PricePerSMS}, InvoiceDate = '{subscription.InvoiceDate.Day}.{subscription.InvoiceDate.Month}.{subscription.InvoiceDate.Year}'  where [PhoneNumber] = '{subscription.PhoneNumber}'";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }

        public void Delete(Subscription subscription)
        {
            try
            {
                command.CommandText = $"Delete from Subscription where [PhoneNumber] = '{subscription.PhoneNumber}'";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
            }
            finally
            {
                if (connect != null)
                {
                    connect.Close();
                }
            }
        }


        public void Insert(TelephoneSubscriber telephoneSubscriber)
        {
            try
            {
                command.CommandText = $"Insert into TelephoneSubscriber([PhoneNumber],[PersonalID],[Names],[Address]) values ('{telephoneSubscriber.PhoneNumber}','{telephoneSubscriber.PersonalID}','{telephoneSubscriber.Names}','{telephoneSubscriber.Address}')";
                command.CommandType = System.Data.CommandType.Text;
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                MessageBox.Show($"{err}");
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
