using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine_Store.DAL.Entities
{
	[Table("thuoc", Schema = "medicine_store")]
	public class Thuoc
	{
		[Key]
		public string thuoc_id { get; set; }
		public string hoat_chat { get; set; }
		public string ten { get; set; }
		public int so_luong_ton { get; set; }
		public int don_gia { get; set; }
		[ForeignKey("thuoc_id")]
		public virtual ICollection<Chi_tiet_don_hang> Don_hang { get; set; }
	}
}
