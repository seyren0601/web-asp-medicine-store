using Medicine_Store.DAL.Entities;

namespace Medicine_Store.DAL.Services
{
	public class Service_Cart
	{
		ApplicationDbContext context;
		public Service_Cart(ApplicationDbContext context)
		{
			this.context = context;
		}

		// Use when user created an account
		public bool CreateCart(string user_id)
		{
			context.Carts.Add(new Cart()
			{
				user_id = user_id
			});

			int affected = context.SaveChanges();
			if(affected > 0)
			{
				return true;
			}
			return false;
		}
		public List<Cart_details> GetCartDetails(string user_id)
		{
			Cart userCart = context.Carts.Where(x => x.user_id == user_id).FirstOrDefault();
			if(userCart != null) 
			{
				int cart_id = userCart.cart_id;
				if (cart_id > 0)
				{
					return context.Cart_Details.Where(c => c.cart_id == cart_id).ToList();
				}
			}
			return null;
		}
		public bool AddToCart(string user_id, string thuoc_id, int amount) 
		{
			Cart userCart = context.Carts.Where(x => x.user_id == user_id).FirstOrDefault();
			context.Cart_Details.Add(new Cart_details()
			{
				cart_id = userCart.cart_id,
				thuoc_id = thuoc_id,
				amount = amount,
				date = DateTime.Now
			});

			int affected = context.SaveChanges();
			if (affected > 0)
			{
				return true;
			}
			return false;
		}
	}
}
