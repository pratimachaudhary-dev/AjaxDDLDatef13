﻿using System.Web;
using System.Web.Mvc;

namespace AjaxDDLDatef13
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
