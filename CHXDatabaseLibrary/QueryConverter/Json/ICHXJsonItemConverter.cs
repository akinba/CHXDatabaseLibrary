﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHXDatabaseLibrary.QueryConverter.Json
{
    public abstract class ICHXJsonItemConverter
    {
        public abstract void Convert(dynamic jsonItem, ref QueryContainer query);
    }
}
