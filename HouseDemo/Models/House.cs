using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HouseDemo.Models
{
    public class House
    {
        public int Id { get; set; }
        public string City { get; set; }
        public decimal Price { get; set; }
        public House(int id, string city, decimal price)
        {
            Id = id;
            City = city;
            Price = price;
        }
    }
}