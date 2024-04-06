using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medicine_Store.Pages
{
    public class ManageIndexModel : PageModel
    {
        public Service_Thuoc service { get; set; }
        public ManageIndexModel(Service_Thuoc service)
        {
            this.service = service;
        }
        public void OnGet()
        {
        }
    }
}
