using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medicine_Store.Pages
{
    public class ThuocModel : PageModel
    {
        private Service_Thuoc thuoc_service { get; set; }
        public string imageURL { get; set; }
        public string thuoc_id { get; set; }
        public Thuoc Thuoc { get; set; }
        public ThuocModel(Service_Thuoc service_thuoc)
        {
            thuoc_service = service_thuoc;
        }
        public void OnGet([FromQuery] string thuoc_id, [FromQuery] string imageURL)
        {
            this.imageURL = imageURL;
            this.thuoc_id = thuoc_id;
            Thuoc = thuoc_service.GetThuoc(thuoc_id);
        }
    }
}
