namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuThu")]
    public partial class ThuThu
    {
        [Key]
        public int MaThuThu { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }
    }
}
