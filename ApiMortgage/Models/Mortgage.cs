using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMortgage.Models
{
	public class Mortgage
	{
		public decimal Amount { get; set; }
		public decimal Rate { get; set; }
		public int Years { get; set; }
		public decimal CalcPayment()
		{
			// payment -- calculate the payment on a loan                 
			// formula:                                                    
			//                                      -months                
			//        p = amount /((1 - (1+interest)        ) / interest)  

			int months = Years * 12;
			double interest = (double) Rate / 100.0;
			double denominator;
			denominator = 1 + (double) interest / 12.0;
			denominator = Math.Pow(denominator, -months);
			denominator = 1 - denominator;
			denominator /= interest / 12.0;
			decimal Payment = Amount / Convert.ToDecimal(denominator);
			// Round to nearest cent
			int payCents = (int) (100.0m * Payment + .5m);
			Payment = payCents / 100.0m;
			return Payment;
		}
	}
}