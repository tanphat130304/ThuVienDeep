using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class PhanQuyenBLL
    {
        private Model1 dbContext;

        public PhanQuyenBLL()
        {
            dbContext = new Model1(); // Khởi tạo DbContext để kết nối cơ sở dữ liệu
        }

        // Phương thức lấy danh sách tất cả phân quyền
        public List<PhanQuyen> GetAllPhanQuyen()
        {
            return dbContext.PhanQuyen.Include("NguoiDung").Include("Quyen").ToList();
        }

        // Phương thức thêm phân quyền mới
        public void AddPhanQuyen(PhanQuyen phanQuyen)
        {
            dbContext.PhanQuyen.Add(phanQuyen);
            dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Phương thức sửa thông tin phân quyền
        public void UpdatePhanQuyen(PhanQuyen phanQuyen)
        {
            var existingPhanQuyen = dbContext.PhanQuyen.Find(phanQuyen.MaPhanQuyen);
            if (existingPhanQuyen != null)
            {
                existingPhanQuyen.MaNguoiDung = phanQuyen.MaNguoiDung;
                existingPhanQuyen.MaQuyen = phanQuyen.MaQuyen;
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Phương thức xóa phân quyền
        public void DeletePhanQuyen(int maPhanQuyen)
        {
            var phanQuyen = dbContext.PhanQuyen.Find(maPhanQuyen);
            if (phanQuyen != null)
            {
                dbContext.PhanQuyen.Remove(phanQuyen);
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
