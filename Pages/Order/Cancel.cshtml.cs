using Medicine_Store.DAL;
using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medicine_Store.Pages.Order
{
    public class CancelModel : PageModel
    {
        private string UserID { get; set; }
        private ApplicationDbContext Context { get; set; }
        private Service_Cart cart_service { get; set; }
        private Service_DonHang donhang_service { get; set; }
        public CancelModel(Service_Cart cart, Service_DonHang donhang)
        {
            cart_service = cart;
            donhang_service = donhang;
        }
        public void OnGet([FromQuery] string session_id)
        {
            UserID = Request.Query["user_id"];
            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Get(session_id);
            var payment_id = session.PaymentIntentId;

            bool success = donhang_service.CreateDonHang_Failed(UserID, session_id);
        }
    }
}
