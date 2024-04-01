using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine_Store.DAL.Entities
{
	[Table("cart", Schema = "medicine_store")]
	public class Cart
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int cart_id { get; set; }
		public string user_id { get; set; }
		[ForeignKey("ApplicationUser")]
		public virtual ApplicationUser User { get; set; }
	}
}
