﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCallAPI.Model
{
    public class JsonFirstData
    {
        public string stat { get; set; }
        public string title { get; set; }
        public string[] fields { get; set; }
        public string[][] data { get; set; }
        public string[] formula { get; set; }
        public string[] notes { get; set; }
        public string sortKind { get; set; }
    }
}
