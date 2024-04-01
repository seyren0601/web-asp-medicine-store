using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine_Store.DAL.Entities
{
	[Table("cart_details", Schema="medicine_store"), PrimaryKey("cart_id", "thuoc_id")]
	public class Cart_details
	{
		[ForeignKey("Cart")]
		public int cart_id { get; set; }
		[ForeignKey("Thuoc")]
		public string thuoc_id { get; set; }
		public int amount { get; set; }
		public DateTime date { get; set; }
	}
}
