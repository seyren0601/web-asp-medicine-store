using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medicine_Store.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Service_Thuoc _service_thuoc;
        [BindProperty]
        public string MedSearch { get; set; }
        [BindProperty]
        public string SearchOptions { get; set; }
        public List<Thuoc> ListThuoc { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Service_Thuoc _service_thuoc)
        {
            _logger = logger;
            this._service_thuoc = _service_thuoc;
        }

        public void OnGet()
        {
            ListThuoc = _service_thuoc.GetAllThuoc();
        }

        public IActionResult OnPost()
        {
            if(SearchOptions == "tenThuoc")
            {
				ListThuoc = _service_thuoc.GetAllThuoc().Where(x => x.ten.Contains(MedSearch, StringComparison.OrdinalIgnoreCase)).Take(5).ToList();
			}
            else if(SearchOptions == "tenHopChat")
            {
				ListThuoc = _service_thuoc.GetAllThuoc().Where(x => x.hoat_chat.Contains(MedSearch, StringComparison.OrdinalIgnoreCase)).Take(5).ToList();
			}
            return Page();
        }
    }
}
