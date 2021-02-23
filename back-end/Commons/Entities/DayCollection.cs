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
        public string payments { get; set; }
        public string payments_scheduled { get; set; }
        public string payments_value { get; set; }
    }
}
