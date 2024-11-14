using BLL;
using DAL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        NguoiDungBLL nguoiDungBLL;
        // Lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recUsername, recPassword, recButtonLogin;

        public frmLogin()
        {
            nguoiDungBLL = new NguoiDungBLL();
            InitializeComponent();
            this.Load += frmLogin_Load; // Đăng ký sự kiện Load
            this.Resize += frmLogin_Resize; // Đăng ký sự kiện Resize
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Lưu kích thước và vị trí ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recUsername = new Rectangle(txtUsername.Location, txtUsername.Size);
            recPassword = new Rectangle(txtPassword.Location, txtPassword.Size);
            recButtonLogin = new Rectangle(btnLogin.Location, btnLogin.Size);
        
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Hiển thị hộp thoại xác nhận khi người dùng cố gắng đóng form
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả người dùng chọn
            if (result == DialogResult.No)
            {
                // Hủy sự kiện đóng form nếu người dùng chọn "No"
                e.Cancel = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển
            ResizeControl(txtUsername, recUsername);
            ResizeControl(txtPassword, recPassword);
            ResizeControl(btnLogin, recButtonLogin);
        
        }

        private void ResizeControl(Control c, Rectangle r)
        {
            // Tính toán tỷ lệ kích thước mới dựa trên kích thước gốc của form
            float xRatio = (float)this.Width / (float)formOriginalSize.Width;
            float yRatio = (float)this.Height / (float)formOriginalSize.Height;

            // Tính toán vị trí mới
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            // Tính toán kích thước mới
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            // Cập nhật vị trí và kích thước cho điều khiển
            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private bool Login(string username, string password)
        {
            var loginResult = nguoiDungBLL.Login(username, password); // Gọi phương thức Login

            if (loginResult.NguoiDung != null)
            {
                // Kiểm tra trạng thái tài khoản
                if (loginResult.NguoiDung.TinhTrangTaiKhoan.Equals("Inactive", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tài khoản của bạn đang bị khóa. Vui lòng liên hệ quản trị viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false; // Ngăn chặn đăng nhập nếu tài khoản bị khóa
                }

                // Kiểm tra quyền của người dùng
                if (loginResult.NguoiDung.MaQuyen == 1) // Quyền Admin
                {
                    frmMuonSach adminForm = new frmMuonSach(); // Form dành cho Admin
                    adminForm.Show();
                }
                else if (loginResult.NguoiDung.MaQuyen == 2) // Quyền Người dùng
                {
                    frmUser userForm = new frmUser(loginResult.NguoiDung); // Truyền đối tượng user sang form User
                    userForm.Show();
                }
                return true; // Đăng nhập thành công
            }
            return false; // Đăng nhập thất bại
        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            var loginResult = nguoiDungBLL.Login(username, password);

            if (loginResult.NguoiDung != null)
            {
                // Nếu đăng nhập thành công và tài khoản không bị khóa
                if (loginResult.NguoiDung.MaQuyen == 1) // Admin
                {
                    frmMuonSach adminForm = new frmMuonSach();
                    adminForm.Show();
                }
                else if (loginResult.NguoiDung.MaQuyen == 2) // Người dùng
                {
                    frmUser userForm = new frmUser(loginResult.NguoiDung);
                    userForm.Show();
                }
                this.Hide();
            }
            else
            {
                // Hiển thị thông báo cụ thể từ LoginResult
                MessageBox.Show(loginResult.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
