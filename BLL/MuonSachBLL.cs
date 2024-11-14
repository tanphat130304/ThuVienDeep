using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class MuonSachBLL
    {
        private Model1 dbContext;

        public MuonSachBLL()
        {
            dbContext = new Model1(); // Khởi tạo DbContext để kết nối cơ sở dữ liệu
        }

        // Phương thức lấy danh sách tất cả mượn sách
        public List<MuonSach> GetAllMuonSach()
        {
            return dbContext.MuonSach.Include("NguoiMuon").Include("Sach").ToList(); // Lấy cả thông tin liên quan
        }

        // Thêm phương thức lấy danh sách tất cả sách
        public List<Sach> GetAllSach()
        {
            return dbContext.Sach.ToList(); // Lấy danh sách tất cả sách từ cơ sở dữ liệu
        }

        // Thêm phương thức lấy danh sách tất cả người mượn
        public List<NguoiMuon> GetAllNguoiMuon()
        {
            return dbContext.NguoiMuon.ToList(); // Lấy danh sách tất cả người mượn từ cơ sở dữ liệu
        }

        public List<MuonSach> GetMuonSachByUser(int maNguoiMuon)
        {
            return dbContext.MuonSach
                            .Include("NguoiMuon")
                            .Include("Sach")
                            .Where(ms => ms.MaNguoiMuon == maNguoiMuon)
                            .ToList();
        }

        // Phương thức thêm mượn sách mới
        public void AddMuonSach(MuonSach muonSach)
        {
            dbContext.MuonSach.Add(muonSach);
            dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        public MuonSach GetMuonSachById(int maMuonSach)
        {
            return dbContext.MuonSach
                            .Include("NguoiMuon")
                            .Include("Sach")
                            .FirstOrDefault(ms => ms.MaMuonSach == maMuonSach);
        }

        // Phương thức sửa thông tin mượn sách
        public void UpdateMuonSach(MuonSach muonSach)
        {
            var existingMuonSach = dbContext.MuonSach.Find(muonSach.MaMuonSach);
            if (existingMuonSach != null)
            {
                existingMuonSach.MaNguoiMuon = muonSach.MaNguoiMuon;
                existingMuonSach.MaSach = muonSach.MaSach;
                existingMuonSach.NgayMuon = muonSach.NgayMuon;
                existingMuonSach.NgayTra = muonSach.NgayTra;
                existingMuonSach.NgayTraDuKien = muonSach.NgayTraDuKien;
                existingMuonSach.TrangThai = muonSach.TrangThai;
                existingMuonSach.PhiPhat = muonSach.PhiPhat;
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Phương thức kiểm tra trạng thái mượn sách
        public bool IsBookCurrentlyBorrowed(int maMuonSach)
        {
            using (var context = new Model1())
            {
                var muonSach = context.MuonSach.Find(maMuonSach);
                return muonSach != null && muonSach.TrangThai.Equals("Đang mượn", StringComparison.OrdinalIgnoreCase);
            }
        }


        // Phương thức xóa mượn sách
        public bool DeleteMuonSach(int maMuonSach)
        {
            var muonSach = dbContext.MuonSach.Find(maMuonSach);
            if (muonSach != null)
            {
                if (muonSach.TrangThai.Equals("Đang mượn", StringComparison.OrdinalIgnoreCase))
                {
                    return false; // Không cho phép xóa nếu sách đang mượn
                }
                dbContext.MuonSach.Remove(muonSach);
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true; // Xóa thành công
            }
            return false; // Nếu không tìm thấy bản ghi để xóa
        }
    }
}
