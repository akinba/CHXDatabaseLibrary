﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHXAuthenticate
{
    public class Claim : Entity
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return string.Format("Claim ({0}, Type: {1}, Value: {2}", base.ToString(), Type, Value);
        }
    }
}
