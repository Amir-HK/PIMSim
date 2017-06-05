﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SimplePIM.General
{
    public abstract class Request
    {
        public UInt64 ts_arrival = 0;
        public UInt64 ts_departure = 0;
        public UInt64 ts_issue = 0;
    }
}
