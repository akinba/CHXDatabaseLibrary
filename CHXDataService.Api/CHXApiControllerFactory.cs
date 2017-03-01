﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CHXDataService.Api
{
    public static class CHXApiControllerFactory
    {
        private static object _locker = new object();

        public static CHXApi GetApiController(string controllerName, ClaimsPrincipal principal)
        {
            if (controllerName == "data")
            {
                return new CHXApiControllers.Data.CHXDataController(principal);
            }
            else { return null; }
        }
    }
}
