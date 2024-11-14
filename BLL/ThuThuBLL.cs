using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class ThuThuBLL
    {
        private Model1 dbContext;

        public ThuThuBLL()
        {
            dbContext = new Model1(); // Khởi tạo DbContext để kết nối cơ sở dữ liệu
        }

        // Phương thức lấy danh sách tất cả thủ thư
        public List<ThuThu> GetAllThuThu()
        {
            return dbContext.ThuThu.ToList();
        }

        // Phương thức thêm thủ thư mới
        public void AddThuThu(ThuThu thuThu)
        {
            dbContext.ThuThu.Add(thuThu);
            dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Phương thức sửa thông tin thủ thư
        public void UpdateThuThu(ThuThu thuThu)
        {
            var existingThuThu = dbContext.ThuThu.Find(thuThu.MaThuThu);
            if (existingThuThu != null)
            {
                existingThuThu.HoTen = thuThu.HoTen;
                existingThuThu.SoDienThoai = thuThu.SoDienThoai;
                existingThuThu.Email = thuThu.Email;
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Phương thức xóa thủ thư
        public void DeleteThuThu(int maThuThu)
        {
            var thuThu = dbContext.ThuThu.Find(maThuThu);
            if (thuThu != null)
            {
                dbContext.ThuThu.Remove(thuThu);
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
