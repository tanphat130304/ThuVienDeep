namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            PhanQuyen = new HashSet<PhanQuyen>();
        }

        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDangNhap { get; set; }
        
        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int MaQuyen { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTaoTaiKhoan { get; set; }

        [StringLength(10)]
        public string TinhTrangTaiKhoan { get; set; }

        public virtual Quyen Quyen { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhanQuyen> PhanQuyen { get; set; }
    }
}
