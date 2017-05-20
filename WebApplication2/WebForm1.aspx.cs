using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static object o = new object();
        protected void Button1_Click(object sender, EventArgs e)
        {
            //lock (this)
            //{
            //    for (int i = 0; i < 10; i++)
            //    {

            //        Response.Write(DateTime.Now.ToString()+"&nbsp;");
            //        Thread.Sleep(1000);
            //    }
            //}
            lock (o)
            {
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Response.Write(DateTime.Now.ToString() + "<br />");
                }
            }
        }
    }
}