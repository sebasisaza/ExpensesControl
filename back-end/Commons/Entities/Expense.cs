using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class Expense
    {
        public int id_expense { get; set; }
        public string description { get; set; }
        public float value { get; set; }
        public DateTime date { get; set; }
        public DateTime created_on { get; set; }
    }
}
