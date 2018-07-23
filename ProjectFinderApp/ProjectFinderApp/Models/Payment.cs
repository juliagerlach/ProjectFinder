using System;

namespace ProjectFinderApp.Models
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int? PaidAmt { get; set; }
        public DateTime PaymentDate { get; set; }
        public int SubscriberID { get; set; }
        public virtual Subscriber Subscriber { get; set; }
    }
}