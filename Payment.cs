using System;

namespace Phonebook
{
    public class Payment
    {
        public string Invoice { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string PhoneNumber { get; private set; }
        public decimal PhoneBill { get; private set; }
        // 0 for payed 1 for unpayed
        public bool PaymentStatus { get; private set; }

        // Private конструктор за използване само от Builder
        private Payment() { }

        public class PaymentBuilder
        {
            private Payment payment;

            public PaymentBuilder()
            {
                payment = new Payment();
            }

            public PaymentBuilder SetInvoice(string invoice)
            {
                payment.Invoice = invoice;
                return this;
            }

            public PaymentBuilder SetPaymentDate(DateTime paymentDate)
            {
                payment.PaymentDate = paymentDate;
                return this;
            }

            public PaymentBuilder SetPhoneNumber(string phoneNumber)
            {
                payment.PhoneNumber = phoneNumber;
                return this;
            }

            public PaymentBuilder SetPhoneBill(decimal phoneBill)
            {
                payment.PhoneBill = phoneBill;
                return this;
            }

            public PaymentBuilder SetPaymentStatus(bool paymentStatus)
            {
                payment.PaymentStatus = paymentStatus;
                return this;
            }

            public Payment Build()
            {
                return payment;
            }
        }
    }
}
