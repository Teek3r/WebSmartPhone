﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSmartPhone.Filter;
namespace WebSmartPhone.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilter
            (GlobalFilterCollection filters)
        {
            filters.Add(new MyExeptionFilter());
        }
    }
}