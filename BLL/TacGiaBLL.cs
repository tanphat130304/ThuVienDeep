using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class TacGiaBLL
    {
        private Model1 dbContext;

        public TacGiaBLL()
        {
            dbContext = new Model1(); // Khởi tạo đối tượng DbContext
        }

        // Phương thức lấy tất cả tác giả từ cơ sở dữ liệu
        public List<TacGia> GetAllTacGia()
        {
            return dbContext.TacGia.ToList(); // Lấy danh sách tất cả tác giả
        }

        // Phương thức thêm tác giả mới
        public void AddTacGia(TacGia tacGia)
        {
            dbContext.TacGia.Add(tacGia); // Thêm đối tượng tác giả vào cơ sở dữ liệu
            dbContext.SaveChanges(); // Lưu thay đổi
        }

        // Phương thức sửa thông tin tác giả
        public void UpdateTacGia(TacGia tacGia)
        {
            var existingTacGia = dbContext.TacGia.Find(tacGia.MaTacGia);
            if (existingTacGia != null)
            {
                existingTacGia.TenTacGia = tacGia.TenTacGia;
                existingTacGia.QuocGia = tacGia.QuocGia;
                dbContext.SaveChanges(); // Lưu thay đổi
            }
        }

        // Phương thức xóa tác giả
        public void DeleteTacGia(int maTacGia)
        {
            var tacGia = dbContext.TacGia.Find(maTacGia);
            if (tacGia != null)
            {
                dbContext.TacGia.Remove(tacGia); // Xóa tác giả
                dbContext.SaveChanges(); // Lưu thay đổi
            }
        }
    }
}
