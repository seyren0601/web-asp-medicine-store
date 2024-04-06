using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine_Store.Entity
{
    [Table("medicine", Schema ="medicine")]
    public class Medicine
    {
        [Key]
        public string ID { get; set; }
        public string TEN_THUOC { get; set; }
        public string HOAT_CHAT { get; set; }
    }
}
