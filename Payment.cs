using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Payment
    {
        public string Invoice { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PhoneNumber { get; set; }
        public decimal PhoneBill { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
