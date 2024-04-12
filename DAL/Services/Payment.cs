using Stripe.Infrastructure;
using Stripe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe.Checkout;

namespace Medicine_Store.DAL.Services
{

	[Route("create-payment-session")]
	[ApiController]
	public class PaymentIntentApiController : Controller
	{
        [HttpPost]
        public ActionResult Create()
        {
            var domain = "https://localhost:7191";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "vnd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "test"
                            },
                            UnitAmount = 50000
                        },
                        // Provide the exact Price ID (for example, pr_1234) of the product you want to sell
                        Quantity = 5,
                    },
                },
                Mode = "payment",
                SuccessUrl = domain + "/success.html",
                CancelUrl = domain + "/cancel.html",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
	}
}
