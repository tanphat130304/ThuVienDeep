using System.Collections.Generic;
using System.Linq;
using DAL;

namespace BLL
{
    public class TheLoaiBLL
    {
        private Model1 dbContext;

        public TheLoaiBLL()
        {
            dbContext = new Model1(); // Khởi tạo DbContext để kết nối cơ sở dữ liệu
        }

        // Lấy danh sách tất cả thể loại
        public List<TheLoai> GetAllTheLoai()
        {
            return dbContext.TheLoai.ToList();
        }

        // Thêm thể loại mới
        public void AddTheLoai(TheLoai theLoai)
        {
            dbContext.TheLoai.Add(theLoai);
            dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
        }

        // Sửa thể loại
        public void UpdateTheLoai(TheLoai theLoai)
        {
            var existingTheLoai = dbContext.TheLoai.Find(theLoai.MaTheLoai);
            if (existingTheLoai != null)
            {
                existingTheLoai.TenTheLoai = theLoai.TenTheLoai;
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }

        // Xóa thể loại
        public void DeleteTheLoai(int maTheLoai)
        {
            var theLoai = dbContext.TheLoai.Find(maTheLoai);
            if (theLoai != null)
            {
                dbContext.TheLoai.Remove(theLoai);
                dbContext.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
        }
    }
}
