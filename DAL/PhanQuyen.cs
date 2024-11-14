namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanQuyen")]
    public partial class PhanQuyen
    {
        [Key]
        public int MaPhanQuyen { get; set; }

        public int MaNguoiDung { get; set; }

        public int MaQuyen { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual Quyen Quyen { get; set; }
    }
}
