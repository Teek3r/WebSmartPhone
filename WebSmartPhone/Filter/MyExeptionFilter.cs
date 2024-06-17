using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace WebSmartPhone.Filter
{
    public class MyExeptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string s = "Message: " + filterContext.Exception
                .Message;
            StreamWriter st = File.AppendText(filterContext.RequestContext.HttpContext.Request
                .PhysicalApplicationPath + "\\errorlog.txt");
            st.WriteLine(s);
            st.Close();

            filterContext.ExceptionHandled = true;

            filterContext.Result = new RedirectResult("/Home/Error");
        }
    }
}