using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class ClientPayment
    {
        public int id_client_payment { get; set; }
        public int id_client { get; set; }
        public float value { get; set; }
        public DateTime date{ get; set; }
        public DateTime created_on { get; set; }
    }
}
