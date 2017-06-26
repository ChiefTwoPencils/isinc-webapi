using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiHouses.Models;

namespace ApiHouses.Controllers
{
    public class HouseController : ApiController
    {
        private static List<House> houses = new List<House>();
        private static int nextId;

        static HouseController()
        {
            houses.Add(new House(101, "Charlotte", 20000m));
            houses.Add(new House(102, "Boston", 25000m));
            houses.Add(new House(103, "Chicago", 300000m));
            houses.Add(new House(104, "Sacramento", 210000m));
            nextId = 105;
        }

        public IEnumerable<House> Get()
        {
            return houses;
        }

        public House Get(int id)
        {
            House house = houses.First(h => h.Id == id);
            if (house != null)
            {
                return house;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public HttpResponseMessage Post(House house)
        {
            house.Id = nextId++;
            houses.Add(house);
            HttpResponseMessage message = Request.CreateResponse<House>(
                HttpStatusCode.Created, house
            );
            string uri = Url.Link("DefaultApi", new { id = house.Id });
            message.Headers.Location = new Uri(uri);
            return message;
        }

        public void Put(int id, House house)
        {
            int index = houses.FindIndex(h => h.Id == id);
            if (index >= 0)
            {
                houses[index] = house;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void Delete(int id)
        {
            int index = houses.FindIndex(h => h.Id == id);
            if (index >= 0)
            {
                houses.RemoveAt(index);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
    }
}
