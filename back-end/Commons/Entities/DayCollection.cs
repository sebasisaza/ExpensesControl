using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class DayCollection
    {
        public int id_client { get; set; }
        public string name_client { get; set; }
        public string phone_client { get; set; }
        public string fee_summary { get; set; }
        public string fee_value { get; set; }
    }
}
