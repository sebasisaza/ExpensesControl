﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Commons.Entities
{
    public class ResponseItem<T>
    {
        public ResponseItem()
        {
            messages = new List<string>();
            errors = new List<string>();
        }
        public bool success { get; set; }
        public List<string> messages { get; set; }
        public List<string> errors { get; set; }
        public T data { get; set; }
    }
}
