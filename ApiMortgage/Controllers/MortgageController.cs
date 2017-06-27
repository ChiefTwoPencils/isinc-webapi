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
		// POST api/mortgage
		public string Post(Mortgage mort)
		{
			decimal payment = mort.CalcPayment();
			return payment.ToString();
		}
	}
}
