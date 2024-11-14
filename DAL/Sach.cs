namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            MuonSach = new HashSet<MuonSach>();
        }

        [Key]
        public int MaSach { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        public int MaTacGia { get; set; }

        public int MaTheLoai { get; set; }

        public int? NamXuatBan { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(1000)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MuonSach> MuonSach { get; set; }

        public virtual TacGia TacGia { get; set; }

        public virtual TheLoai TheLoai { get; set; }
    }
}
