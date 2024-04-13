using Medicine_Store.DAL.Entities;

namespace Medicine_Store.DAL.Services
{
    public class Service_DonHang
    {
        ApplicationDbContext _context;
        public Service_DonHang(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateDonHang(string UserID, string paymentID)
        {
            try
            {
                Cart user_cart = _context.Carts.FirstOrDefault(c => c.user_id == UserID);
                List<Cart_details> details = _context.Cart_Details.ToList();
                _context.Don_hang.Add(new Don_hang
                {
                    user_id = UserID,
                    da_thanh_toan = true,
                    PaymentDate = DateTime.Now,
                    PaymentID = paymentID
                });
                _context.SaveChanges();

                int ma_don_hang = _context.Don_hang.FirstOrDefault(dh => dh.user_id == UserID).ma_don_hang;
                foreach (var detail in details)
                {
                    _context.Thuoc.FirstOrDefault(th => th.thuoc_id == detail.thuoc_id).so_luong_ton -= detail.amount;
                    _context.Chi_tiet_don_hang.Add(new Chi_tiet_don_hang
                    {
                        ma_don_hang = ma_don_hang,
                        thuoc_id = detail.thuoc_id,
                        so_luong_mua = detail.amount
                    });
                }
                _context.Cart_Details.RemoveRange(details);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
