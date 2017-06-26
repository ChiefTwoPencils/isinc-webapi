using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StringApi.Controllers
{
    public class StringsController : ApiController
    {
        private static List<string> strings = new List<string>();

        static StringsController()
        {
            strings.Add("Monday");
            strings.Add("Tuesday");
            strings.Add("Wednesday");
            strings.Add("Thursday");
            strings.Add("Friday");
        }

        public IEnumerable<string> Get()
        {
            return strings;
        }
    }
}
