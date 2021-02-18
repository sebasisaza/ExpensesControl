using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class Client
    {
        public int id_client { get; set; }
        public string name { get; set; }
        public int identification { get; set; }
        public string phone { get; set; }
        public float loan { get; set; }
        public int time_limit { get; set; }
        public float interest_rate { get; set; }
        public short payment_type { get; set; }
        public short days_added { get; set; }
        public DateTime created_on { get; set; }
    }
}
