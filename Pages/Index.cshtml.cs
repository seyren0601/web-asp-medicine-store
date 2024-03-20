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
        public string MedSearch { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Service_Thuoc _service_thuoc)
        {
            _logger = logger;
            this._service_thuoc = _service_thuoc;
        }

        public void OnGet()
        {

        }
    }
}
