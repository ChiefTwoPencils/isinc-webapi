using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HouseDemo.Models
{
    public class House
    {
        [Range(101, 999)]
        public int Id { get; set; }
        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z]*")]
        public string City { get; set; }
        [Range(typeof(decimal), "10000", "1000000")]
        public decimal Price { get; set; }
        public House(int id, string city, decimal price)
        {
            Id = id;
            City = city;
            Price = price;
        }
    }
}