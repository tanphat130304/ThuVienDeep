using BLL;
using DAL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmUser : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recCmbSach, recDtpNgayMuon, recDtpNgayTraDuKien;
        private Rectangle recBtnMuonSach, recBtnDangXuat, recDgvThongTin;

        private NguoiDung user; // Người dùng hiện tại (đã đăng nhập)
        private MuonSachBLL muonSachBLL;
        private SachBLL sachBLL;

        public frmUser(NguoiDung currentUser)
        {
            InitializeComponent();
            user = currentUser; // Lưu lại thông tin người dùng đã đăng nhập
            muonSachBLL = new MuonSachBLL(); // Khởi tạo đối tượng BLL
            sachBLL = new SachBLL();         // Khởi tạo đối tượng BLL cho sách

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmUser_Load;
            this.Resize += frmUser_Resize;

            LoadData();
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recCmbSach = new Rectangle(cmb_Sach.Location, cmb_Sach.Size);
            recDtpNgayMuon = new Rectangle(dtp_NgayMuon.Location, dtp_NgayMuon.Size);
            recDtpNgayTraDuKien = new Rectangle(dtpk_NgayTraDuKien.Location, dtpk_NgayTraDuKien.Size);
            recBtnMuonSach = new Rectangle(btnMuonSach.Location, btnMuonSach.Size);
            recBtnDangXuat = new Rectangle(btn_DangXuat.Location, btn_DangXuat.Size);
            recDgvThongTin = new Rectangle(dgv_ThongTin.Location, dgv_ThongTin.Size);

            LoadSach();
        }

        private void frmUser_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(cmb_Sach, recCmbSach);
            ResizeControl(dtp_NgayMuon, recDtpNgayMuon);
            ResizeControl(dtpk_NgayTraDuKien, recDtpNgayTraDuKien);
            ResizeControl(btnMuonSach, recBtnMuonSach);
            ResizeControl(btn_DangXuat, recBtnDangXuat);
            ResizeControl(dgv_ThongTin, recDgvThongTin);
        }

        private void ResizeControl(Control c, Rectangle r)
        {
            // Tính toán tỷ lệ kích thước mới dựa trên kích thước ban đầu của form
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

        private void LoadData()
        {
            var muonSachList = muonSachBLL.GetMuonSachByUser(user.MaNguoiDung);
            var muonSachData = muonSachList.Select(ms => new
            {
                ms.MaMuonSach,
                ms.Sach.TieuDe,
                ms.NgayMuon,
                ms.NgayTraDuKien,
                ms.NgayTra,
                ms.TrangThai,
                ms.PhiPhat // Hiển thị phí phạt nếu có
            }).ToList();

            dgv_ThongTin.DataSource = muonSachData; // Đổ dữ liệu vào DataGridView
        }

        private void LoadSach()
        {
            var sachList = sachBLL.GetAllSach().Where(s => s.SoLuong > 0).ToList();
            cmb_Sach.DataSource = sachList;
            cmb_Sach.DisplayMember = "TieuDe";  // Hiển thị tên sách
            cmb_Sach.ValueMember = "MaSach";    // Lưu mã sách
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime ngayMuon = dtp_NgayMuon.Value;    // Lấy ngày mượn
                DateTime ngayTraDuKien = dtpk_NgayTraDuKien.Value; // Lấy ngày trả dự kiến

                // Kiểm tra ngày trả dự kiến phải lớn hơn hoặc bằng ngày mượn
                if (ngayTraDuKien < ngayMuon)
                {
                    MessageBox.Show("Ngày trả dự kiến không được nhỏ hơn ngày mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại, không tiếp tục nếu ngày trả dự kiến không hợp lệ
                }

                int maSach = (int)cmb_Sach.SelectedValue;  // Lấy mã sách từ ComboBox

                MuonSach muonSach = new MuonSach
                {
                    MaNguoiMuon = user.MaNguoiDung, // Lấy mã người dùng hiện tại
                    MaSach = maSach,
                    NgayMuon = ngayMuon,
                    NgayTraDuKien = ngayTraDuKien,
                    TrangThai = "Đang mượn",
                    PhiPhat = 0 // Mặc định phí phạt bằng 0
                };

                // Thêm thông tin mượn sách
                muonSachBLL.AddMuonSach(muonSach);

                // Giảm số lượng sách đi 1
                sachBLL.UpdateQuantity(maSach, -1);

                MessageBox.Show("Mượn sách thành công!", "Thông báo");
                LoadData(); // Tải lại dữ liệu sau khi mượn sách
                LoadSach(); // Tải lại danh sách sách để cập nhật số lượng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void dtp_NgayMuon_ValueChanged(object sender, EventArgs e)
        {
            dtpk_NgayTraDuKien.Value = dtp_NgayMuon.Value.AddDays(7);
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                frmLogin loginForm = new frmLogin();
                loginForm.Show();
                this.Hide(); // Hide the current form instead of closing it
            }
        }

        private void dgv_ThongTin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi click vào DataGridView nếu cần thêm hành động
        }
    }
}
