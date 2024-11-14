using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class NguoiMuonBLL
    {
        private Model1 dbContext;

        public NguoiMuonBLL()
        {
            dbContext = new Model1(); // Khởi tạo DbContext để kết nối cơ sở dữ liệu
        }

        // Phương thức lấy danh sách tất cả người mượn
        public List<NguoiMuon> GetAllNguoiMuon()
        {
            return dbContext.NguoiMuon.ToList();
        }

        // Phương thức thêm người mượn mới
        public void AddNguoiMuon(NguoiMuon nguoiMuon)
        {
            dbContext.NguoiMuon.Add(nguoiMuon);
            dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Phương thức sửa thông tin người mượn
        public void UpdateNguoiMuon(NguoiMuon nguoiMuon)
        {
            var existingNguoiMuon = dbContext.NguoiMuon.Find(nguoiMuon.MaNguoiMuon);
            if (existingNguoiMuon != null)
            {
                existingNguoiMuon.HoTen = nguoiMuon.HoTen;
                existingNguoiMuon.DiaChi = nguoiMuon.DiaChi;
                existingNguoiMuon.SoDienThoai = nguoiMuon.SoDienThoai;
                existingNguoiMuon.Email = nguoiMuon.Email;
                existingNguoiMuon.NgaySinh = nguoiMuon.NgaySinh;
                existingNguoiMuon.GioiTinh = nguoiMuon.GioiTinh;
                existingNguoiMuon.LoaiThe = nguoiMuon.LoaiThe;
                existingNguoiMuon.NgayHetHanThe = nguoiMuon.NgayHetHanThe;
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Phương thức xóa người mượn
        public void DeleteNguoiMuon(int maNguoiMuon)
        {
            var nguoiMuon = dbContext.NguoiMuon.Find(maNguoiMuon);
            if (nguoiMuon != null)
            {
                dbContext.NguoiMuon.Remove(nguoiMuon);
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
