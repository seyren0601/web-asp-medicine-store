using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medicine_Store.Pages.Order
{
    public class DonHangModel : PageModel
    {
        public Service_DonHang service { get; set; }
        public DonHangModel(Service_DonHang service)
        {
            this.service = service;
        }
        public void OnGet()
        {

        }
    }
}
