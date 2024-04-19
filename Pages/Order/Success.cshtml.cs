using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medicine_Store.Pages.Order
{
    public class SuccessModel : PageModel
    {
        [BindProperty]
        public string payment_id { get; set; }
        public Service_Thuoc thuoc_service;
        public Service_Cart cart_service;
        public Service_DonHang donhang_service;
        [BindProperty]
        public List<Cart_details> cart_details { get; set; } = new List<Cart_details>();
        [BindProperty]
        public List<Thuoc> list_thuoc { get; set; } = new List<Thuoc>();
        [BindProperty]
        public string UserID { get; set; }
        public SuccessModel(Service_Thuoc service_thuoc, Service_Cart service_cart, Service_DonHang service_donhang)
        {
            thuoc_service = service_thuoc;
            cart_service = service_cart;
            donhang_service = service_donhang;
        }
        public IActionResult OnGet([FromQuery] string session_id)
        {
            var service = new Stripe.Checkout.SessionService();
            Stripe.Checkout.Session session = service.Get(session_id);
            payment_id = session.PaymentIntentId;
            string UserID = User.Identity.GetUserId();
            cart_details = cart_service.GetCartDetails(UserID);

            foreach (var detail in cart_details)
            {
                list_thuoc.Add(thuoc_service.GetThuoc(detail.thuoc_id));
            }

            donhang_service.CreateDonHang_Success(UserID, payment_id);
            return Page();
        }
    }
}
