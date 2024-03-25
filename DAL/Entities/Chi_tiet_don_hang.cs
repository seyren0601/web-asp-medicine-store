using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Mozilla;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine_Store.DAL.Entities
{
	[PrimaryKey("ma_don_hang", "thuoc_id"), Table("chi_tiet_don_hang", Schema="medicine_store")]
	public class Chi_tiet_don_hang
	{
		[ForeignKey("Don_hang")]
		public int ma_don_hang { get; set; }
		[ForeignKey("Thuoc")]
		public string thuoc_id { get; set; }
		public int so_luong_mua { get; set; }
	}
}
