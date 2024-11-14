using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmSach : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recTxtMaSach, recTxtTieuDe, recTxtNamXuatBan, recNudSoLuong, recRtbMoTa;
        private Rectangle recCmbTacGia, recCmbTheLoai;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnQuayLai;
        private Rectangle recDgvBooks;

        SachBLL sachBLL;

        public frmSach()
        {
            InitializeComponent();
            sachBLL = new SachBLL(); // Khởi tạo đối tượng BLL
            LoadData();
            LoadComboBoxData();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmSach_Load;
            this.Resize += frmSach_Resize;
        }

        private void frmSach_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recTxtMaSach = new Rectangle(txtMaSach.Location, txtMaSach.Size);
            recTxtTieuDe = new Rectangle(txtTieuDe.Location, txtTieuDe.Size);
            recTxtNamXuatBan = new Rectangle(txtNamXuatBan.Location, txtNamXuatBan.Size);
            recNudSoLuong = new Rectangle(nudSoLuong.Location, nudSoLuong.Size);
            recRtbMoTa = new Rectangle(rtbMoTa.Location, rtbMoTa.Size);
            recCmbTacGia = new Rectangle(cmbTacGia.Location, cmbTacGia.Size);
            recCmbTheLoai = new Rectangle(cmbTheLoai.Location, cmbTheLoai.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnQuayLai = new Rectangle(btn_QuayLai.Location, btn_QuayLai.Size);
            recDgvBooks = new Rectangle(dgvBooks.Location, dgvBooks.Size);
        }

        private void frmSach_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(txtMaSach, recTxtMaSach);
            ResizeControl(txtTieuDe, recTxtTieuDe);
            ResizeControl(txtNamXuatBan, recTxtNamXuatBan);
            ResizeControl(nudSoLuong, recNudSoLuong);
            ResizeControl(rtbMoTa, recRtbMoTa);
            ResizeControl(cmbTacGia, recCmbTacGia);
            ResizeControl(cmbTheLoai, recCmbTheLoai);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(btn_QuayLai, recBtnQuayLai);
            ResizeControl(dgvBooks, recDgvBooks);
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
            var sachList = sachBLL.GetAllSach()
                                  .Select(s => new
                                  {
                                      s.MaSach,
                                      s.TieuDe,
                                      TenTacGia = s.TacGia.TenTacGia, // Hiển thị tên tác giả
                                      TenTheLoai = s.TheLoai.TenTheLoai, // Hiển thị tên thể loại
                                      s.NamXuatBan,
                                      s.SoLuong,
                                      s.MoTa
                                  })
                                  .ToList();

            dgvBooks.DataSource = sachList; // Đổ dữ liệu vào DataGridView
        }

        private void LoadComboBoxData()
        {
            try
            {
                // Đổ dữ liệu vào ComboBox tác giả
                var tacGiaList = sachBLL.GetAllTacGia();
                cmbTacGia.DataSource = tacGiaList;
                cmbTacGia.DisplayMember = "TenTacGia"; // Hiển thị tên tác giả
                cmbTacGia.ValueMember = "MaTacGia";    // Lưu mã số tác giả

                // Đổ dữ liệu vào ComboBox thể loại
                var theLoaiList = sachBLL.GetAllTheLoai();
                cmbTheLoai.DataSource = theLoaiList;
                cmbTheLoai.DisplayMember = "TenTheLoai";   // Hiển thị tên thể loại
                cmbTheLoai.ValueMember = "MaTheLoai";      // Lưu mã số thể loại
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu ComboBox: " + ex.Message);
            }
        }

        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBooks.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["MaSach"].Value.ToString();
                txtTieuDe.Text = row.Cells["TieuDe"].Value.ToString();
                cmbTacGia.Text = row.Cells["TenTacGia"].Value.ToString();  // Hiển thị tên tác giả
                cmbTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString(); // Hiển thị tên thể loại
                txtNamXuatBan.Text = row.Cells["NamXuatBan"].Value.ToString();
                nudSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuong"].Value);
                rtbMoTa.Text = row.Cells["MoTa"].Value.ToString(); // Gán giá trị vào RichTextBox
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                Sach sach = new Sach()
                {
                    TieuDe = txtTieuDe.Text,
                    MaTacGia = (int)cmbTacGia.SelectedValue,   // Lấy mã số tác giả từ ComboBox
                    MaTheLoai = (int)cmbTheLoai.SelectedValue, // Lấy mã số thể loại từ ComboBox
                    NamXuatBan = int.Parse(txtNamXuatBan.Text),
                    SoLuong = (int)nudSoLuong.Value,
                    MoTa = rtbMoTa.Text
                };

                sachBLL.AddSach(sach);
                LoadData();
                MessageBox.Show("Thêm sách thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                Sach sach = new Sach()
                {
                    MaSach = int.Parse(txtMaSach.Text),
                    TieuDe = txtTieuDe.Text,
                    MaTacGia = (int)cmbTacGia.SelectedValue,   // Lấy mã số tác giả từ ComboBox
                    MaTheLoai = (int)cmbTheLoai.SelectedValue, // Lấy mã số thể loại từ ComboBox
                    NamXuatBan = int.Parse(txtNamXuatBan.Text),
                    SoLuong = (int)nudSoLuong.Value,
                    MoTa = rtbMoTa.Text
                };

                sachBLL.UpdateSach(sach);
                LoadData();
                MessageBox.Show("Cập nhật sách thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật sách: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maSach = int.Parse(txtMaSach.Text);
                sachBLL.DeleteSach(maSach);
                LoadData();
                MessageBox.Show("Xóa sách thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa sách: " + ex.Message);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var sachList = sachBLL.GetAllSach()
                                      .Where(s => s.TieuDe.Contains(txtTieuDe.Text))
                                      .Select(s => new
                                      {
                                          s.MaSach,
                                          s.TieuDe,
                                          TenTacGia = s.TacGia.TenTacGia,
                                          TenTheLoai = s.TheLoai.TenTheLoai,
                                          s.NamXuatBan,
                                          s.SoLuong,
                                          s.MoTa
                                      })
                                      .ToList();

                if (sachList.Count > 0)
                {
                    dgvBooks.DataSource = sachList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sách.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sách: " + ex.Message);
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
