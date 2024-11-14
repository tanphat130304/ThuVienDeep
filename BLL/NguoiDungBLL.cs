using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public class NguoiDungBLL
    {
        // Lớp này trả về kết quả đăng nhập
        public class LoginResult
        {
            public NguoiDung NguoiDung { get; set; }
            public string Message { get; set; }
        }


        // Phương thức đăng nhập
        public LoginResult Login(string username, string password)
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    var nguoiDung = dbContext.NguoiDung.FirstOrDefault(nguoi => nguoi.TenDangNhap == username);

                    if (nguoiDung == null)
                    {
                        return new LoginResult { NguoiDung = null, Message = "Tên đăng nhập hoặc mật khẩu không đúng." };
                    }

                    // Kiểm tra trạng thái tài khoản trước
                    if (nguoiDung.TinhTrangTaiKhoan.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
                    {
                        return new LoginResult { NguoiDung = null, Message = "Tài khoản của bạn đang bị khóa." };
                    }

                    // So sánh mật khẩu nhập vào với mật khẩu trong cơ sở dữ liệu
                    if (nguoiDung.MatKhau != password)
                    {
                        return new LoginResult { NguoiDung = null, Message = "Mật khẩu không đúng." };
                    }

                    return new LoginResult { NguoiDung = nguoiDung, Message = "Đăng nhập thành công." };
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần thiết và trả về thông báo lỗi
                return new LoginResult { NguoiDung = null, Message = "Có lỗi xảy ra khi đăng nhập: " + ex.Message };
            }
        }


        // Lấy danh sách tất cả quyền
        public List<Quyen> GetAllQuyen()
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    return dbContext.Quyen.ToList();
                }
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý tùy theo yêu cầu
                throw new Exception("Lỗi khi lấy danh sách quyền.", ex);
            }
        }

        // Lấy danh sách tất cả người dùng
        public List<NguoiDung> GetAllNguoiDung()
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    return dbContext.NguoiDung.Include("Quyen").ToList(); // Lấy cả quyền
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách người dùng.", ex);
            }
        }

        // Thêm người dùng mới
        public void AddNguoiDung(NguoiDung nguoiDung)
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    // Không mã hóa mật khẩu, lưu mật khẩu dạng văn bản thuần
                    dbContext.NguoiDung.Add(nguoiDung);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm người dùng.", ex);
            }
        }



        // Sửa thông tin người dùng
        public void UpdateNguoiDung(NguoiDung nguoiDung)
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    var existingNguoiDung = dbContext.NguoiDung.Find(nguoiDung.MaNguoiDung);
                    if (existingNguoiDung != null)
                    {
                        existingNguoiDung.TenDangNhap = nguoiDung.TenDangNhap;
                        existingNguoiDung.MatKhau = nguoiDung.MatKhau; // Không mã hóa mật khẩu
                        existingNguoiDung.Email = nguoiDung.Email;
                        existingNguoiDung.MaQuyen = nguoiDung.MaQuyen;
                        existingNguoiDung.TinhTrangTaiKhoan = nguoiDung.TinhTrangTaiKhoan;
                        existingNguoiDung.NgayTaoTaiKhoan = nguoiDung.NgayTaoTaiKhoan;
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật người dùng.", ex);
            }
        }



        // Xóa người dùng
        public void DeleteNguoiDung(int maNguoiDung)
        {
            try
            {
                using (var dbContext = new Model1())
                {
                    var nguoiDung = dbContext.NguoiDung.Find(maNguoiDung);
                    if (nguoiDung != null)
                    {
                        dbContext.NguoiDung.Remove(nguoiDung);
                        dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa người dùng.", ex);
            }
        }
    }
}
