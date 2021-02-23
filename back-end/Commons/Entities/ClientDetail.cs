using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class ClientDetail
    {
        public int id_client { get; set; }
        public string name { get; set; }
        public int identification { get; set; }
        public string phone { get; set; }
        public float loan { get; set; }
        public float payment_paid { get; set; }
        public float payment_owed { get; set; }
        public int time_limit { get; set; }
        public float interest_rate { get; set; }
        public short payment_type { get; set; }
        public List<ClientPayment> payments { get; set; }
    }
}
