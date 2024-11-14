using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmNguoiMuon : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recTxtMaNguoiMuon, recTxtHoTen, recTxtDiaChi, recTxtSoDienThoai, recTxtEmail;
        private Rectangle recCmbGioiTinh, recCmbLoaiThe;
        private Rectangle recDtpNgaySinh, recDtpNgayTaoThe, recDtpNgayHetHanThe;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnQuayLai;
        private Rectangle recDgvNguoiMuon;

        NguoiMuonBLL nguoiMuonBLL;

        public frmNguoiMuon()
        {
            InitializeComponent();
            nguoiMuonBLL = new NguoiMuonBLL(); // Khởi tạo đối tượng BLL
            LoadData();
            InitializeComboBoxes();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmNguoiMuon_Load;
            this.Resize += frmNguoiMuon_Resize;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void frmNguoiMuon_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recTxtMaNguoiMuon = new Rectangle(txtMaNguoiMuon.Location, txtMaNguoiMuon.Size);
            recTxtHoTen = new Rectangle(txtHoTen.Location, txtHoTen.Size);
            recTxtDiaChi = new Rectangle(txtDiaChi.Location, txtDiaChi.Size);
            recTxtSoDienThoai = new Rectangle(txtSoDienThoai.Location, txtSoDienThoai.Size);
            recTxtEmail = new Rectangle(txtEmail.Location, txtEmail.Size);
            recCmbGioiTinh = new Rectangle(cmbGioiTinh.Location, cmbGioiTinh.Size);
            recCmbLoaiThe = new Rectangle(cmbLoaiThe.Location, cmbLoaiThe.Size);
            recDtpNgaySinh = new Rectangle(dtpNgaySinh.Location, dtpNgaySinh.Size);
            recDtpNgayTaoThe = new Rectangle(dtpNgayTaoThe.Location, dtpNgayTaoThe.Size);
            recDtpNgayHetHanThe = new Rectangle(dtpNgayHetHanThe.Location, dtpNgayHetHanThe.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnQuayLai = new Rectangle(btn_QuayLai.Location, btn_QuayLai.Size);
            recDgvNguoiMuon = new Rectangle(dgvNguoiMuon.Location, dgvNguoiMuon.Size);
        }

        private void frmNguoiMuon_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(txtMaNguoiMuon, recTxtMaNguoiMuon);
            ResizeControl(txtHoTen, recTxtHoTen);
            ResizeControl(txtDiaChi, recTxtDiaChi);
            ResizeControl(txtSoDienThoai, recTxtSoDienThoai);
            ResizeControl(txtEmail, recTxtEmail);
            ResizeControl(cmbGioiTinh, recCmbGioiTinh);
            ResizeControl(cmbLoaiThe, recCmbLoaiThe);
            ResizeControl(dtpNgaySinh, recDtpNgaySinh);
            ResizeControl(dtpNgayTaoThe, recDtpNgayTaoThe);
            ResizeControl(dtpNgayHetHanThe, recDtpNgayHetHanThe);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(btn_QuayLai, recBtnQuayLai);
            ResizeControl(dgvNguoiMuon, recDgvNguoiMuon);
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

        private void InitializeComboBoxes()
        {
            cmbGioiTinh.Items.Add("Nam");
            cmbGioiTinh.Items.Add("Nữ");
            cmbGioiTinh.SelectedIndex = 0;

            cmbLoaiThe.Items.Add("Thẻ thường");
            cmbLoaiThe.Items.Add("Thẻ VIP");
            cmbLoaiThe.SelectedIndex = 0;
        }

        private void LoadData()
        {
            var nguoiMuonList = nguoiMuonBLL.GetAllNguoiMuon()
                                            .Select(nm => new
                                            {
                                                nm.MaNguoiMuon,
                                                nm.HoTen,
                                                nm.DiaChi,
                                                nm.SoDienThoai,
                                                nm.Email,
                                                nm.NgaySinh,
                                                nm.GioiTinh,
                                                nm.LoaiThe,
                                                nm.NgayTaoThe,
                                                nm.NgayHetHanThe
                                            })
                                            .ToList();

            dgvNguoiMuon.DataSource = nguoiMuonList;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiMuon nguoiMuon = new NguoiMuon()
                {
                    HoTen = txtHoTen.Text,
                    DiaChi = txtDiaChi.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    Email = txtEmail.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cmbGioiTinh.SelectedItem.ToString(),
                    LoaiThe = cmbLoaiThe.SelectedItem.ToString(),
                    NgayTaoThe = dtpNgayTaoThe.Value,
                    NgayHetHanThe = dtpNgayHetHanThe.Value
                };

                nguoiMuonBLL.AddNguoiMuon(nguoiMuon);
                LoadData();
                MessageBox.Show("Thêm người mượn thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm người mượn: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int maNguoiMuon = int.Parse(txtMaNguoiMuon.Text);
                NguoiMuon nguoiMuon = new NguoiMuon()
                {
                    MaNguoiMuon = maNguoiMuon,
                    HoTen = txtHoTen.Text,
                    DiaChi = txtDiaChi.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    Email = txtEmail.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = cmbGioiTinh.SelectedItem.ToString(),
                    LoaiThe = cmbLoaiThe.SelectedItem.ToString(),
                    NgayTaoThe = dtpNgayTaoThe.Value,
                    NgayHetHanThe = dtpNgayHetHanThe.Value
                };

                nguoiMuonBLL.UpdateNguoiMuon(nguoiMuon);
                LoadData();
                MessageBox.Show("Cập nhật người mượn thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật người mượn: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maNguoiMuon = int.Parse(txtMaNguoiMuon.Text);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa người mượn này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    nguoiMuonBLL.DeleteNguoiMuon(maNguoiMuon);
                    LoadData();
                    MessageBox.Show("Xóa người mượn thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa người mượn: " + ex.Message);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var nguoiMuonList = nguoiMuonBLL.GetAllNguoiMuon()
                                                .Where(nm => nm.HoTen.Contains(txtHoTen.Text))
                                                .Select(nm => new
                                                {
                                                    nm.MaNguoiMuon,
                                                    nm.HoTen,
                                                    nm.DiaChi,
                                                    nm.SoDienThoai,
                                                    nm.Email,
                                                    nm.NgaySinh,
                                                    nm.GioiTinh,
                                                    nm.LoaiThe,
                                                    nm.NgayTaoThe,
                                                    nm.NgayHetHanThe
                                                })
                                                .ToList();

                if (nguoiMuonList.Count > 0)
                {
                    dgvNguoiMuon.DataSource = nguoiMuonList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người mượn.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm người mượn: " + ex.Message);
            }
        }

        private void dgvNguoiMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNguoiMuon.Rows[e.RowIndex];
                txtMaNguoiMuon.Text = row.Cells["MaNguoiMuon"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                dtpNgaySinh.Value = DateTime.Parse(row.Cells["NgaySinh"].Value.ToString());
                cmbGioiTinh.SelectedItem = row.Cells["GioiTinh"].Value.ToString();
                cmbLoaiThe.SelectedItem = row.Cells["LoaiThe"].Value.ToString();
                dtpNgayTaoThe.Value = DateTime.Parse(row.Cells["NgayTaoThe"].Value.ToString());
                dtpNgayHetHanThe.Value = DateTime.Parse(row.Cells["NgayHetHanThe"].Value.ToString());
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
