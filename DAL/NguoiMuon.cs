namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiMuon")]
    public partial class NguoiMuon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiMuon()
        {
            MuonSach = new HashSet<MuonSach>();
        }

        [Key]
        public int MaNguoiMuon { get; set; }

        [Required]
        [StringLength(255)]
        public string HoTen { get; set; }

        [StringLength(255)]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [StringLength(10)]
        public string GioiTinh { get; set; }

        [StringLength(50)]
        public string LoaiThe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHetHanThe { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTaoThe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonSach> MuonSach { get; set; }
    }
}
