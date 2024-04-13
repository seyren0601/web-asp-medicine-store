using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine_Store.DAL.Entities
{
	[Table("don_hang", Schema = "medicine_store")]
	public class Don_hang
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ma_don_hang { get; set; }
		public string user_id { get; set; }
		[ForeignKey("ApplicationUser")]
		public virtual ApplicationUser User { get; set; }
		[ForeignKey("ma_don_hang")]
		public virtual ICollection<Chi_tiet_don_hang> Chi_Tiet_Don_Hang { get; set; }
		public bool da_thanh_toan { get; set; }
		public string PaymentID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
	}
}
