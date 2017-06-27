using HouseDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HouseDemo.Controllers
{
    public class HousesController : ApiController
    {
		private static int nextId;
		private static List<House> houses = new List<House>();
		static HousesController()
		{
			houses.Add(new House(101, "Charlotte", 200000m));
			houses.Add(new House(102, "Boston", 300000m));
			houses.Add(new House(103, "Chicago", 250000m));
			houses.Add(new House(104, "San Francisco", 350000m));
			nextId = 105;
		}

		// GET api/houses
		public IEnumerable<House> Get()
		{
			return houses;
		}

		// GET api/houses/101
		public House Get(int id)
		{
			House house = houses.FirstOrDefault(h => h.Id == id);
			if (house != null)
				return house;
			else
				throw new HttpResponseException(HttpStatusCode.NotFound);
		}

		// POST api/houses
		public HttpResponseMessage Post(House house)
		{
			house.Id = nextId++;
			houses.Add(house);
			var response = Request.CreateResponse<House>(
				HttpStatusCode.Created, house);
			string uri = Url.Link("DefaultApi", new { id = house.Id });
			response.Headers.Location = new Uri(uri);
			return response;
		}

		// PUT api/houses/101
		public void Put(int id, House house)
		{
			int index = houses.FindIndex(h => h.Id == id);
			if (index >= 0)
				houses[index] = house;
			else
				throw new HttpResponseException(HttpStatusCode.NotFound);
		}

		// DELETE api/houses/101
		public void Delete(int id)
		{
			House house = Get(id);
			houses.Remove(house);
		}
	}
}
