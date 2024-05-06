using System;

namespace Phonebook
{
    public class Subscription
    {
        public string PhoneNumber { get; private set; }
        public decimal MonthlyBill { get; private set; }
        public int FreeCallMinutesCount { get; private set; }
        public decimal PricePerMinute { get; private set; }
        public int MinutesOutsideEU { get; private set; }
        public decimal PricePerMinuteEU { get; private set; }
        public int FreeSMSCount { get; private set; }
        public decimal PricePerSMS { get; private set; }
        public DateTime InvoiceDate { get; private set; }

        // Private конструктор за използване само от Builder
        private Subscription() { }

        public class SubscriptionBuilder
        {
            private Subscription subscription;

            public SubscriptionBuilder()
            {
                subscription = new Subscription();
            }

            public SubscriptionBuilder SetPhoneNumber(string phoneNumber)
            {
                subscription.PhoneNumber = phoneNumber;
                return this;
            }

            public SubscriptionBuilder SetMonthlyBill(decimal monthlyBill)
            {
                // Validate the input before setting the value
                if (monthlyBill < 0)
                {
                    throw new FormatException("Monthly bill cannot be negative.");
                }

                subscription.MonthlyBill = monthlyBill;
                return this;
            }

            public SubscriptionBuilder SetFreeCallMinutesCount(int freeCallMinutesCount)
            {
                if (freeCallMinutesCount < 0)
                {
                    throw new FormatException("Free call minutes count cannot be negative.");
                }

                subscription.FreeCallMinutesCount = freeCallMinutesCount;
                return this;
            }

            public SubscriptionBuilder SetPricePerMinute(decimal pricePerMinute)
            {
                subscription.PricePerMinute = pricePerMinute;
                return this;
            }

            public SubscriptionBuilder SetMinutesOutsideEU(int minutesOutsideEU)
            {
                subscription.MinutesOutsideEU = minutesOutsideEU;
                return this;
            }

            public SubscriptionBuilder SetPricePerMinuteEU(decimal pricePerMinuteEU)
            {
                subscription.PricePerMinuteEU = pricePerMinuteEU;
                return this;
            }

            public SubscriptionBuilder SetFreeSMSCount(int freeSMSCount)
            {
                subscription.FreeSMSCount = freeSMSCount;
                return this;
            }

            public SubscriptionBuilder SetPricePerSMS(decimal pricePerSMS)
            {
                subscription.PricePerSMS = pricePerSMS;
                return this;
            }

            public SubscriptionBuilder SetInvoiceDate(DateTime invoiceDate)
            {
                subscription.InvoiceDate = invoiceDate;
                return this;
            }

            public Subscription Build()
            {
                return subscription;
            }
        }
    }
}
