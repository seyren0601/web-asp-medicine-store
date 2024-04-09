using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

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
    }
}
