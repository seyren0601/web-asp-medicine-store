using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medicine_Store.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Medicine_Store.DAL.Services;

namespace Medicine_Store.Areas.Identity.Pages.Account.Manage
{
    public class DonHangModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
		public Service_DonHang service { get; set; }
		[BindProperty]
        public string test { get; set; } = "Test";

        public DonHangModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, Service_DonHang service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.service = service;
        }
        public void OnGet()
        {
        }
    }
}
