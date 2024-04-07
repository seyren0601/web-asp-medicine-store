using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Medicine_Store.DAL.Entities;

namespace Medicine_Store.Pages.Manage
{
    public class AddThuocModel : PageModel
    {
        Service_Thuoc _service { get; set; }
        [BindProperty]
        public BindingModel Input { get; set; }
        public AddThuocModel(Service_Thuoc service)
        {
            _service = service;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ViewData.Remove("Success");
                ViewData["Failed"] = "failed";
                return Page();
            }
            

			Console.WriteLine(Input.Id);
			Console.WriteLine(Input.TenThuoc);
			Console.WriteLine(Input.HoatChat);
            await _service.AddThuoc(new Thuoc()
            {
                thuoc_id = Input.Id,
                ten = Input.TenThuoc,
                hoat_chat = Input.HoatChat,
                so_luong_ton = Input.SoLuong,
                don_gia = Input.DonGia
            });
			ViewData.Remove("Failed");
			ViewData["Success"] = "success";
			return Page();
        }

        public class BindingModel
        {
            [Required]
			public string Id { get; set; }
            [Required]
			public string HoatChat { get; set; }
            [Required]
			public string TenThuoc { get; set; }
			[Required]
            [Range(0, int.MaxValue)]
            public int DonGia { get; set; }
            [Range(0, int.MaxValue)]
            public int SoLuong { get; set; }
        }
    }
}
