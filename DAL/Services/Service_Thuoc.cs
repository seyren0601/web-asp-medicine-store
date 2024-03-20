using Medicine_Store.DAL.Entities;

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
    }
}
