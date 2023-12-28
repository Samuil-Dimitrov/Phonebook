using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public class Subscription
    {
        public string PhoneNumber { get; set; }
        public decimal MonthlyBill { get; set; }
        public int FreeCallMinutesCount { get; set; }
        public decimal PricePerMinute { get; set; }
        public int MinutesOutsideEU { get; set; }
        public decimal PricePerMinuteEU { get; set; }
        public int FreeSMSCount { get; set; }
        public decimal PricePerSMS { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
