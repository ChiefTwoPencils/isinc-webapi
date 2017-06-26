using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApiDemo2
{
    public class DemoController : ApiController
    {

        private static string msg;

        static DemoController()
        {
            msg = "Hello World!!";
        }

        public string Get()
        {
            return msg;
        }

        public void Put([FromBody] string value)
        {
            msg = value;
        }
    }
}