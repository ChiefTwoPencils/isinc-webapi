using ApiMortgage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMortgage.Controllers
{
    public class MortgageController : ApiController
    {
        // GET api/mortgage?amount=20000&rate=5&years=20
        // GET api/mortgage/<amount>/<rate>/<years>
        public string Get(decimal amount, decimal rate, int years)
        {
            Mortgage m = new Mortgage { Amount = amount, Rate = rate, Years = years };
            decimal payment = m.CalcPayment();
            return payment.ToString();
        }

		// POST api/mortgage
		public string Post(Mortgage mort)
		{
			decimal payment = mort.CalcPayment();
			return payment.ToString();
		}
	}
}
