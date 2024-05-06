using System;

namespace Phonebook
{
    public class TelephoneSubscriber
    {
        public string PhoneNumber { get; private set; }
        public string PersonalID { get; private set; }
        public string Names { get; private set; }
        public string Address { get; private set; }

        // Private конструктор за използване само от Builder
        private TelephoneSubscriber() { }

        public class TelephoneSubscriberBuilder
        {
            private TelephoneSubscriber subscriber;

            public TelephoneSubscriberBuilder()
            {
                subscriber = new TelephoneSubscriber();
            }

            public TelephoneSubscriberBuilder SetPhoneNumber(string phoneNumber)
            {
                subscriber.PhoneNumber = phoneNumber;
                return this;
            }

            public TelephoneSubscriberBuilder SetPersonalID(string personalID)
            {
                subscriber.PersonalID = personalID;
                return this;
            }

            public TelephoneSubscriberBuilder SetNames(string names)
            {
                subscriber.Names = names;
                return this;
            }

            public TelephoneSubscriberBuilder SetAddress(string address)
            {
                subscriber.Address = address;
                return this;
            }

            public TelephoneSubscriber Build()
            {
                return subscriber;
            }
        }
    }
}
