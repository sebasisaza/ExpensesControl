using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class ResponsePage<T>
    {
        public ResponsePage()
        {
            messages = new List<string>();
            errors = new List<string>();
        }
        public bool success { get; set; }
        public List<string> messages { get; set; }
        public List<string> errors { get; set; }
        public T data { get; set; }
        public int size { get; set; }
        public int page { get; set; }
    }
}
