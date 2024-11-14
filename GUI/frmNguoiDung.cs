using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNguoiDung : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recCmbMaQuyen, recCmbTinhTrangTaiKhoan;
        private Rectangle recTxtMaNguoiDung, recTxtTenDangNhap, recTxtMatKhau, recTxtEmail;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnClose;
        private Rectangle recDgvNguoiDung;

        NguoiDungBLL nguoiDungBLL;

        public frmNguoiDung()
        {
            InitializeComponent();
            nguoiDungBLL = new NguoiDungBLL(); // Khởi tạo đối tượng BLL
            LoadQuyen();
            LoadTinhTrangTaiKhoan();
            LoadData();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmNguoiDung_Load;
            this.Resize += frmNguoiDung_Resize;
        }

        private void frmNguoiDung_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recCmbMaQuyen = new Rectangle(cmbMaQuyen.Location, cmbMaQuyen.Size);
            recCmbTinhTrangTaiKhoan = new Rectangle(cmbTinhTrangTaiKhoan.Location, cmbTinhTrangTaiKhoan.Size);
            recTxtMaNguoiDung = new Rectangle(txtMaNguoiDung.Location, txtMaNguoiDung.Size);
            recTxtTenDangNhap = new Rectangle(txtTenDangNhap.Location, txtTenDangNhap.Size);
            recTxtMatKhau = new Rectangle(txtMatKhau.Location, txtMatKhau.Size);
            recTxtEmail = new Rectangle(txtEmail.Location, txtEmail.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnClose = new Rectangle(guna2Button1.Location, guna2Button1.Size);
            recDgvNguoiDung = new Rectangle(dgvNguoiDung.Location, dgvNguoiDung.Size);
        }

        private void frmNguoiDung_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(cmbMaQuyen, recCmbMaQuyen);
            ResizeControl(cmbTinhTrangTaiKhoan, recCmbTinhTrangTaiKhoan);
            ResizeControl(txtMaNguoiDung, recTxtMaNguoiDung);
            ResizeControl(txtTenDangNhap, recTxtTenDangNhap);
            ResizeControl(txtMatKhau, recTxtMatKhau);
            ResizeControl(txtEmail, recTxtEmail);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(guna2Button1, recBtnClose);
            ResizeControl(dgvNguoiDung, recDgvNguoiDung);
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

        private void LoadQuyen()
        {
            // Thêm "Admin" và "Người dùng" vào ComboBox
            cmbMaQuyen.Items.Add("Admin");
            cmbMaQuyen.Items.Add("Người dùng");
            cmbMaQuyen.SelectedIndex = 0; // Đặt giá trị mặc định là "Người dùng"
        }

        private void btn_LoadDuLieu_Click(object sender, EventArgs e)
        {
            ReloadData();
        }
        private void ReloadData()
        {
            LoadData(); // Gọi hàm LoadData để tải lại dữ liệu từ cơ sở dữ liệu
            MessageBox.Show("Dữ liệu đã được tải lại."); // Thông báo khi hoàn tất
        }

        private void cmbTinhTrangTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void LoadTinhTrangTaiKhoan()
        {
            // Thêm các trạng thái tài khoản vào ComboBox
            cmbTinhTrangTaiKhoan.Items.Add("Active");
            cmbTinhTrangTaiKhoan.Items.Add("Inactive");
            cmbTinhTrangTaiKhoan.SelectedIndex = 0; // Đặt giá trị mặc định là "Active"
        }

        private void LoadData()
        {
            List<NguoiDung> nguoiDungList = nguoiDungBLL.GetAllNguoiDung(); // Lấy danh sách người dùng
            var nguoiDungData = nguoiDungList.Select(nd => new
            {
                nd.MaNguoiDung,
                nd.TenDangNhap,
                nd.MatKhau,
                nd.Email,
                nd.Quyen.TenQuyen, // Hiển thị tên quyền
                TinhTrangTaiKhoan = nd.TinhTrangTaiKhoan // Hiển thị trạng thái tài khoản dưới dạng chuỗi
            }).ToList();

            dgvNguoiDung.DataSource = nguoiDungData; // Đổ dữ liệu vào DataGridView
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDung nguoiDung = new NguoiDung()
                {
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                    Email = txtEmail.Text,
                    MaQuyen = cmbMaQuyen.SelectedItem.ToString() == "Admin" ? 1 : 2,
                    TinhTrangTaiKhoan = cmbTinhTrangTaiKhoan.SelectedItem.ToString(),
                    NgayTaoTaiKhoan = DateTime.Now
                };

                nguoiDungBLL.AddNguoiDung(nguoiDung);
                LoadData();
                MessageBox.Show("Thêm người dùng thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người dùng: " + (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNguoiDung.Text))
                {
                    MessageBox.Show("Vui lòng chọn người dùng để sửa.");
                    return;
                }

                int maNguoiDung = int.Parse(txtMaNguoiDung.Text);

                NguoiDung nguoiDung = new NguoiDung()
                {
                    MaNguoiDung = maNguoiDung,
                    TenDangNhap = txtTenDangNhap.Text,
                    MatKhau = txtMatKhau.Text,
                    Email = txtEmail.Text,
                    MaQuyen = cmbMaQuyen.SelectedItem.ToString() == "Admin" ? 1 : 2,
                    TinhTrangTaiKhoan = cmbTinhTrangTaiKhoan.SelectedItem.ToString()
                };

                nguoiDungBLL.UpdateNguoiDung(nguoiDung);
                LoadData();
                MessageBox.Show("Cập nhật người dùng thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật người dùng: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNguoiDung.Text))
                {
                    MessageBox.Show("Vui lòng chọn người dùng để xóa.");
                    return;
                }

                int maNguoiDung = int.Parse(txtMaNguoiDung.Text);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa người dùng này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    nguoiDungBLL.DeleteNguoiDung(maNguoiDung);
                    LoadData();
                    MessageBox.Show("Xóa người dùng thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTenDangNhap.Text.Trim();
                var nguoiDungList = nguoiDungBLL.GetAllNguoiDung()
                                                .Where(nd => nd.TenDangNhap.Contains(keyword))
                                                .Select(nd => new
                                                {
                                                    nd.MaNguoiDung,
                                                    nd.TenDangNhap,
                                                    nd.MatKhau,
                                                    nd.Email,
                                                    TinhTrangTaiKhoan = nd.TinhTrangTaiKhoan
                                                }).ToList();

                if (nguoiDungList.Count > 0)
                {
                    dgvNguoiDung.DataSource = nguoiDungList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm người dùng: " + ex.Message);
            }
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvNguoiDung.Rows[e.RowIndex];
                    txtMaNguoiDung.Text = row.Cells["MaNguoiDung"].Value.ToString();
                    txtTenDangNhap.Text = row.Cells["TenDangNhap"].Value.ToString();
                    txtMatKhau.Text = row.Cells["MatKhau"].Value.ToString();
                    txtEmail.Text = row.Cells["Email"].Value.ToString();

                    // Hiển thị quyền trong ComboBox
                    string quyen = row.Cells["TenQuyen"].Value.ToString();
                    cmbMaQuyen.SelectedItem = quyen;

                    // Hiển thị tình trạng tài khoản
                    string tinhTrang = row.Cells["TinhTrangTaiKhoan"].Value.ToString();
                    cmbTinhTrangTaiKhoan.SelectedItem = tinhTrang;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn người dùng: " + ex.Message);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
