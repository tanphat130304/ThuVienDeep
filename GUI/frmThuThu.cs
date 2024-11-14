using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmThuThu : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recTxtMaThuThu, recTxtHoTen, recTxtSoDienThoai, recTxtEmail;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnQuayLai;
        private Rectangle recDgvThuThu;

        private ThuThuBLL thuThuBLL;

        public frmThuThu()
        {
            InitializeComponent();
            thuThuBLL = new ThuThuBLL(); // Khởi tạo đối tượng BLL
            LoadData();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmThuThu_Load;
            this.Resize += frmThuThu_Resize;
        }

        private void frmThuThu_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recTxtMaThuThu = new Rectangle(txtMaThuThu.Location, txtMaThuThu.Size);
            recTxtHoTen = new Rectangle(txtHoTen.Location, txtHoTen.Size);
            recTxtSoDienThoai = new Rectangle(txtSoDienThoai.Location, txtSoDienThoai.Size);
            recTxtEmail = new Rectangle(txtEmail.Location, txtEmail.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnQuayLai = new Rectangle(btn_QuayLai.Location, btn_QuayLai.Size);
            recDgvThuThu = new Rectangle(dgvThuThu.Location, dgvThuThu.Size);
        }

        private void frmThuThu_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(txtMaThuThu, recTxtMaThuThu);
            ResizeControl(txtHoTen, recTxtHoTen);
            ResizeControl(txtSoDienThoai, recTxtSoDienThoai);
            ResizeControl(txtEmail, recTxtEmail);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(btn_QuayLai, recBtnQuayLai);
            ResizeControl(dgvThuThu, recDgvThuThu);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void LoadData()
        {
            List<ThuThu> thuThuList = thuThuBLL.GetAllThuThu(); // Lấy danh sách thủ thư
            dgvThuThu.DataSource = thuThuList; // Đổ dữ liệu vào DataGridView
        }

        private void dgvThuThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThuThu.Rows[e.RowIndex];
                txtMaThuThu.Text = row.Cells["MaThuThu"].Value.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                ThuThu thuThu = new ThuThu()
                {
                    HoTen = txtHoTen.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    Email = txtEmail.Text
                };

                thuThuBLL.AddThuThu(thuThu);
                LoadData(); // Tải lại dữ liệu sau khi thêm
                MessageBox.Show("Thêm thủ thư thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thủ thư: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaThuThu.Text))
                {
                    MessageBox.Show("Vui lòng chọn thủ thư để sửa.");
                    return;
                }

                int maThuThu = int.Parse(txtMaThuThu.Text);

                ThuThu thuThu = new ThuThu()
                {
                    MaThuThu = maThuThu,
                    HoTen = txtHoTen.Text,
                    SoDienThoai = txtSoDienThoai.Text,
                    Email = txtEmail.Text
                };

                thuThuBLL.UpdateThuThu(thuThu);
                LoadData(); // Tải lại dữ liệu sau khi sửa
                MessageBox.Show("Cập nhật thủ thư thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thủ thư: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaThuThu.Text))
                {
                    MessageBox.Show("Vui lòng chọn thủ thư để xóa.");
                    return;
                }

                int maThuThu = int.Parse(txtMaThuThu.Text);

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thủ thư này?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    thuThuBLL.DeleteThuThu(maThuThu);
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                    MessageBox.Show("Xóa thủ thư thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thủ thư: " + ex.Message);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var thuThuList = thuThuBLL.GetAllThuThu()
                                          .Where(tt => tt.HoTen.Contains(txtHoTen.Text))
                                          .ToList();

                if (thuThuList.Count > 0)
                {
                    dgvThuThu.DataSource = thuThuList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thủ thư nào.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm thủ thư: " + ex.Message);
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
