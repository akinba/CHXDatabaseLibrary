﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CHXDataService.Api
{
    public interface ICHXDataApiController
    {
        ICHXDataApiModel GetModel(string modelName);
    }
}
