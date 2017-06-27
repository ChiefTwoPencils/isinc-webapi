using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcStringApi.Controllers
{
    public class StringsController : ApiController
    {
        private static List<string> info =
           new List<string>();

        static StringsController()
        {
            info.Add("alpha");
            info.Add("beta");
            info.Add("gamma");
        }

        // GET api/strings
        public IEnumerable<string> Get()
        {
            return info;
        }

        // GET api/strings/5
        public HttpResponseMessage Get(int id)
        {
            if (id < info.Count)
            {
                return Request.CreateResponse<string>(
                    HttpStatusCode.OK, info[id]);
            }
            else
                return Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "string not found");
        }

        // POST api/strings
        public HttpResponseMessage Post([FromBody]string value)
        {
            info.Add(value);
            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + (info.Count - 1).ToString());
            return msg;
        }

        // PUT api/strings/5
        public void Put(int id, [FromBody]string value)
        {
            if (id >= info.Count)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            info[id] = value;
        }

        // DELETE api/strings/5
        public void Delete(int id)
        {
            if (id >= info.Count)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            info.RemoveAt(id);
        }
    }
}
