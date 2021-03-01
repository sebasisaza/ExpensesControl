using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class General
    {
        public decimal initial_balance { get; set; }
        public decimal utilities_month { get; set; }
        public decimal expenses_month { get; set; }
        public decimal payment_pending_month { get; set; }
        public decimal payment_pending { get; set; }
    }
}
