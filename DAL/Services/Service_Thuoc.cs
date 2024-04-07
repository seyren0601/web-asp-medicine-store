using Medicine_Store.DAL.Entities;
using Newtonsoft.Json;
using System.Collections;
using PagedList;

namespace Medicine_Store.DAL.Services
{
    public class Service_Thuoc
    {
        ApplicationDbContext _context;
        public Service_Thuoc(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Thuoc> GetAllThuoc()
        {
            return _context.Thuoc.ToList();
        }

        public async Task<string> GetThuocImage(Thuoc thuoc)
        {
            HttpClient client = new HttpClient();
            string jsonString = await client.GetStringAsync($"https://drugbank.vn/services/drugbank/api/public/thuoc/{thuoc.thuoc_id}");
            dynamic response = JsonConvert.DeserializeObject(jsonString);
            if(response.images != null)
            {
                string imageName = response.images[0];
                string imageUrl = "https://drugbank.vn/api/public/gridfs/" + imageName;
                Console.WriteLine(imageUrl);
                return imageUrl;
            }
            else return "";
        }

        public int GetStock(string thuoc_id)
        {
            Thuoc thuoc = _context.Thuoc.FirstOrDefault(t => t.thuoc_id == thuoc_id);
            return thuoc.so_luong_ton;
        }

        public async Task<bool> AddThuoc(Thuoc thuoc)
        {
            try
            {
                _context.Thuoc.Add(thuoc);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
