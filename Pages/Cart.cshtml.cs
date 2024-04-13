using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Stripe.Checkout;
using Stripe;

namespace Medicine_Store.Pages
{
    public class CartModel : PageModel
    {
        public Service_Thuoc thuoc_service;
        public Service_Cart cart_service;
        [BindProperty]
        public List<Cart_details> cart_details { get; set; }
        [BindProperty]
        public List<Thuoc> list_thuoc { get; set; }
        [BindProperty]
        public string UserID { get; set; }

        public CartModel(Service_Thuoc thuoc_service, Service_Cart cart_service)
        {
            this.thuoc_service = thuoc_service;
            this.cart_service = cart_service;
            cart_details = new List<Cart_details>();
            list_thuoc = new List<Thuoc>();
        }

        public IActionResult OnGet()
        {
            string UserID = User.Identity.GetUserId();
            cart_details = cart_service.GetCartDetails(UserID);

            foreach (var detail in cart_details)
            {
                list_thuoc.Add(thuoc_service.GetThuoc(detail.thuoc_id));
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            string UserID = User.Identity.GetUserId();
            cart_details = cart_service.GetCartDetails(UserID);

            foreach (var detail in cart_details)
            {
                list_thuoc.Add(thuoc_service.GetThuoc(detail.thuoc_id));
            }
            var product_service = new ProductService();
            StripeList<Product> Products = product_service.List();

            var productid_and_quantities = from cart_detail in cart_details
                                           join product in Products on cart_detail.thuoc_id equals product.Metadata["thuoc_id"]
                                           select new SessionLineItemOptions
                                           {
                                               Price = product.DefaultPriceId,
                                               Quantity = cart_detail.amount
                                           };
            List<SessionLineItemOptions> items = productid_and_quantities.ToList();
            var domain = "https://localhost:7191";
            var options = new SessionCreateOptions
            {
                LineItems = items,
                Mode = "payment",
                SuccessUrl = domain + $"/Order/Success?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = domain + "/cancel.html",
            };
            var checkout_service = new SessionService();
            Session session = checkout_service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
