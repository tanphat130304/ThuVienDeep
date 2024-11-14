using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmMuonSach : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recCmbMaSach, recCmbMaNguoiMuon, recCmbTrangThai;
        private Rectangle recDtpNgayMuon, recDtpNgayTraDuKien, recTxtPhiPhat, recTxtMaMuonSach;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnDangXuat;
        private Rectangle recDgvMuonSach;

        MuonSachBLL muonSachBLL;

        public frmMuonSach()
        {
            InitializeComponent();
            muonSachBLL = new MuonSachBLL(); // Khởi tạo đối tượng BLL
            LoadData();
            InitializeComboBox();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmMuonSach_Load;
            this.Resize += frmMuonSach_Resize;
        }
        private void ReloadData()
        {
            // Tải lại danh sách mượn sách và cập nhật DataGridView
            List<MuonSach> muonSachList = muonSachBLL.GetAllMuonSach();
            var muonSachData = muonSachList.Select(ms => new
            {
                ms.MaMuonSach,
                ms.NguoiMuon.HoTen,
                ms.Sach.TieuDe,
                ms.NgayMuon,
                ms.NgayTraDuKien,
                ms.TrangThai,
                ms.PhiPhat
            }).ToList();

            dgvMuonSach.DataSource = muonSachData;
        }

        private void frmMuonSach_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recCmbMaSach = new Rectangle(cmb_MaSach.Location, cmb_MaSach.Size);
            recCmbMaNguoiMuon = new Rectangle(cmbMaNguoiMuon.Location, cmbMaNguoiMuon.Size);
            recCmbTrangThai = new Rectangle(cmbTrangThai.Location, cmbTrangThai.Size);
            recDtpNgayMuon = new Rectangle(dtpNgayMuon.Location, dtpNgayMuon.Size);
            recDtpNgayTraDuKien = new Rectangle(dtpNgayTraDuKien.Location, dtpNgayTraDuKien.Size);
            recTxtPhiPhat = new Rectangle(txtPhiPhat.Location, txtPhiPhat.Size);
            recTxtMaMuonSach = new Rectangle(txtMaMuonSach.Location, txtMaMuonSach.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnDangXuat = new Rectangle(btn_DangXuat.Location, btn_DangXuat.Size);
            recDgvMuonSach = new Rectangle(dgvMuonSach.Location, dgvMuonSach.Size);
        }

        private void frmMuonSach_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(cmb_MaSach, recCmbMaSach);
            ResizeControl(cmbMaNguoiMuon, recCmbMaNguoiMuon);
            ResizeControl(cmbTrangThai, recCmbTrangThai);
            ResizeControl(dtpNgayMuon, recDtpNgayMuon);
            ResizeControl(dtpNgayTraDuKien, recDtpNgayTraDuKien);
            ResizeControl(txtPhiPhat, recTxtPhiPhat);
            ResizeControl(txtMaMuonSach, recTxtMaMuonSach);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(btn_DangXuat, recBtnDangXuat);
            ResizeControl(dgvMuonSach, recDgvMuonSach);
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

        private void InitializeComboBox()
        {
            var sachList = muonSachBLL.GetAllSach();
            cmb_MaSach.DataSource = sachList;
            cmb_MaSach.DisplayMember = "TieuDe";
            cmb_MaSach.ValueMember = "MaSach";

            var nguoiMuonList = muonSachBLL.GetAllNguoiMuon();
            cmbMaNguoiMuon.DataSource = nguoiMuonList;
            cmbMaNguoiMuon.DisplayMember = "HoTen";
            cmbMaNguoiMuon.ValueMember = "MaNguoiMuon";

            cmbTrangThai.Items.Add("Đang mượn");
            cmbTrangThai.Items.Add("Đã trả");
            cmbTrangThai.SelectedIndex = 0;
        }

        private void LoadData()
        {
            List<MuonSach> muonSachList = muonSachBLL.GetAllMuonSach();
            var muonSachData = muonSachList.Select(ms => new
            {
                ms.MaMuonSach,
                ms.NguoiMuon.HoTen,
                ms.Sach.TieuDe,
                ms.NgayMuon,
                ms.NgayTraDuKien,
                ms.TrangThai,
                ms.PhiPhat
            }).ToList();

            dgvMuonSach.DataSource = muonSachData;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ngày trả dự kiến phải lớn hơn hoặc bằng ngày mượn
                if (dtpNgayTraDuKien.Value < dtpNgayMuon.Value)
                {
                    MessageBox.Show("Ngày trả dự kiến không được nhỏ hơn ngày mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngăn không cho tiếp tục thêm mượn sách
                }

                MuonSach muonSach = new MuonSach()
                {
                    MaNguoiMuon = (int)cmbMaNguoiMuon.SelectedValue,
                    MaSach = (int)cmb_MaSach.SelectedValue,
                    NgayMuon = dtpNgayMuon.Value,
                    NgayTraDuKien = dtpNgayTraDuKien.Value,
                    TrangThai = cmbTrangThai.SelectedItem.ToString(),
                    PhiPhat = decimal.Parse(txtPhiPhat.Text)
                };

                // Thêm thông tin mượn sách
                muonSachBLL.AddMuonSach(muonSach);

                // Giảm số lượng sách đi 1
                SachBLL sachBLL = new SachBLL();
                sachBLL.UpdateQuantity(muonSach.MaSach, -1);

                ReloadData();
                MessageBox.Show("Thêm mượn sách thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm mượn sách: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra ngày trả dự kiến phải lớn hơn hoặc bằng ngày mượn
                if (dtpNgayTraDuKien.Value < dtpNgayMuon.Value)
                {
                    MessageBox.Show("Ngày trả dự kiến không được nhỏ hơn ngày mượn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Ngăn không cho tiếp tục cập nhật mượn sách
                }

                int maMuonSach = int.Parse(txtMaMuonSach.Text);
                MuonSach muonSach = new MuonSach()
                {
                    MaMuonSach = maMuonSach,
                    MaNguoiMuon = (int)cmbMaNguoiMuon.SelectedValue,
                    MaSach = (int)cmb_MaSach.SelectedValue,
                    NgayMuon = dtpNgayMuon.Value,
                    NgayTraDuKien = dtpNgayTraDuKien.Value,
                    TrangThai = cmbTrangThai.SelectedItem.ToString(),
                    PhiPhat = decimal.Parse(txtPhiPhat.Text)
                };

                // Kiểm tra trạng thái mới là "Đã trả"
                if (muonSach.TrangThai == "Đã trả")
                {
                    SachBLL sachBLL = new SachBLL();
                    sachBLL.UpdateQuantity(muonSach.MaSach, 1); // Tăng số lượng sách lên 1
                }

                // Cập nhật thông tin mượn sách
                muonSachBLL.UpdateMuonSach(muonSach);
                ReloadData();
                MessageBox.Show("Cập nhật mượn sách thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật mượn sách: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (dgvMuonSach.SelectedRows.Count > 0)
            {
                int maMuonSach = Convert.ToInt32(dgvMuonSach.SelectedRows[0].Cells["MaMuonSach"].Value);

                // Hiển thị hộp thoại xác nhận trước khi xóa
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi mượn sách này?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // Kiểm tra xem sách có đang được mượn hay không
                    if (muonSachBLL.IsBookCurrentlyBorrowed(maMuonSach))
                    {
                        MessageBox.Show("Không thể xóa bản ghi mượn sách khi sách đang được mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Thực hiện xóa nếu sách không đang được mượn
                    muonSachBLL.DeleteMuonSach(maMuonSach);
                    ReloadData();
                    MessageBox.Show("Xóa bản ghi mượn sách thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản ghi mượn sách để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtMaNguoiMuon.Text.Trim();

                var muonSachList = muonSachBLL.GetAllMuonSach()
                                              .Where(ms => ms.NguoiMuon.HoTen.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                                              .Select(ms => new
                                              {
                                                  ms.MaMuonSach,
                                                  ms.NguoiMuon.HoTen,
                                                  ms.Sach.TieuDe,
                                                  ms.NgayMuon,
                                                  ms.NgayTraDuKien,
                                                  ms.TrangThai,
                                                  ms.PhiPhat
                                              })
                                              .ToList();

                if (muonSachList.Count > 0)
                {
                    dgvMuonSach.DataSource = muonSachList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy mượn sách.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm mượn sách: " + ex.Message);
            }
        }

        private void dgvMuonSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMuonSach.Rows[e.RowIndex];
                txtMaMuonSach.Text = row.Cells["MaMuonSach"].Value.ToString();

                cmbMaNguoiMuon.Text = row.Cells["HoTen"].Value.ToString();
                cmb_MaSach.Text = row.Cells["TieuDe"].Value.ToString();

                dtpNgayMuon.Value = DateTime.Parse(row.Cells["NgayMuon"].Value.ToString());
                dtpNgayTraDuKien.Value = DateTime.Parse(row.Cells["NgayTraDuKien"].Value.ToString());
                cmbTrangThai.SelectedItem = row.Cells["TrangThai"].Value.ToString();
                txtPhiPhat.Text = row.Cells["PhiPhat"].Value.ToString();
            }
        }

        private void quảnLíSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSach sach = new frmSach();
            sach.ShowDialog();
        }

        private void quảnLíThủThưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThuThu thuThu = new frmThuThu();
            thuThu.ShowDialog();
        }

        private void btn_LoadDuLieu_Click(object sender, EventArgs e)
        {
            ReloadData();
            MessageBox.Show("Dữ liệu đã được tải lại.");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void quảnLíThểLoạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTheLoai theLoai = new frmTheLoai();
            theLoai.ShowDialog();
        }

        private void quảnLíNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNguoiDung nguoiDung = new frmNguoiDung();
            nguoiDung.ShowDialog();
        }

        private void quảnLíNgườiMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNguoiMuon nguoiMuon = new frmNguoiMuon();
            nguoiMuon.ShowDialog();
        }

        private void quảnLíTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTacGia tacGia = new frmTacGia();
            tacGia.ShowDialog();
        }

        private void txtMaNguoiMuon_TextChanged(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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

        private void frmMuonSach_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void hệThốngQuảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
