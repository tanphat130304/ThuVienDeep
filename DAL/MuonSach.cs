namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MuonSach")]
    public partial class MuonSach
    {
        [Key]
        public int MaMuonSach { get; set; }

        public int MaNguoiMuon { get; set; }

        public int MaSach { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayMuon { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTra { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraDuKien { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public decimal? PhiPhat { get; set; }

        public virtual NguoiMuon NguoiMuon { get; set; }

        public virtual Sach Sach { get; set; }
    }
}
