using System;
using System.Data;
using static Phonebook.TelephoneSubscriber;

namespace Phonebook
{
    public class PhonebookFacade
    {
        private readonly Connection facadeConnection;

        public PhonebookFacade(Connection connection)
        {
            facadeConnection = connection;
        }

        public void AddSubscriber(TelephoneSubscriber telephoneSubscriberBuilder)
        {
            facadeConnection.Insert(telephoneSubscriberBuilder);
        }

        public void UpdateSubscriber(TelephoneSubscriber telephoneSubscriber)
        {
            facadeConnection.Update(telephoneSubscriber);
        }

        public void DeleteSubscriber(string phoneNumber)
        {
            var subscriber = new TelephoneSubscriberBuilder()
              .SetPhoneNumber(phoneNumber)
              .Build(); // Only phone number needed for deletion

            facadeConnection.Delete(subscriber);
        }

        public DataTable GetSubscriberPayments(string personalID)
        {
            return facadeConnection.GetSubscriberPayments(personalID);
        }

        public DataTable GetSubscribersWithMultipleNumbers()
        {
            return facadeConnection.GetSubscribersWithMultipleNumbers();
        }
    }
}
