using BLL;
using DAL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTacGia : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recTxtMaTacGia, recTxtTenTacGia, recTxtQuocGia;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnQuayLai;
        private Rectangle recDgvTacGia;

        TacGiaBLL tacGiaBLL;

        public frmTacGia()
        {
            InitializeComponent();
            tacGiaBLL = new TacGiaBLL(); // Khởi tạo đối tượng BLL
            LoadData();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmTacGia_Load;
            this.Resize += frmTacGia_Resize;
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recTxtMaTacGia = new Rectangle(txtMaTacGia.Location, txtMaTacGia.Size);
            recTxtTenTacGia = new Rectangle(txtTenTacGia.Location, txtTenTacGia.Size);
            recTxtQuocGia = new Rectangle(txtQuocGia.Location, txtQuocGia.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnQuayLai = new Rectangle(btn_QuayLai.Location, btn_QuayLai.Size);
            recDgvTacGia = new Rectangle(dgvTacGia.Location, dgvTacGia.Size);
        }

        private void frmTacGia_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(txtMaTacGia, recTxtMaTacGia);
            ResizeControl(txtTenTacGia, recTxtTenTacGia);
            ResizeControl(txtQuocGia, recTxtQuocGia);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(btn_QuayLai, recBtnQuayLai);
            ResizeControl(dgvTacGia, recDgvTacGia);
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
            var tacGiaList = tacGiaBLL.GetAllTacGia()
                                      .Select(tg => new
                                      {
                                          tg.MaTacGia,
                                          tg.TenTacGia,
                                          tg.QuocGia
                                      })
                                      .ToList();

            dgvTacGia.DataSource = tacGiaList; // Chỉ hiển thị các cột đã chỉ định
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                TacGia tacGia = new TacGia()
                {
                    TenTacGia = txtTenTacGia.Text,
                    QuocGia = txtQuocGia.Text
                };

                tacGiaBLL.AddTacGia(tacGia);
                LoadData(); // Tải lại dữ liệu sau khi thêm
                MessageBox.Show("Thêm tác giả thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tác giả: " + ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int maTacGia = int.Parse(txtMaTacGia.Text); // Lấy mã tác giả từ textbox
                TacGia tacGia = new TacGia()
                {
                    MaTacGia = maTacGia, // Cần cung cấp mã tác giả để cập nhật
                    TenTacGia = txtTenTacGia.Text,
                    QuocGia = txtQuocGia.Text
                };

                tacGiaBLL.UpdateTacGia(tacGia);
                LoadData(); // Tải lại dữ liệu sau khi sửa
                MessageBox.Show("Cập nhật tác giả thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tác giả: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maTacGia = int.Parse(txtMaTacGia.Text); // Lấy mã tác giả từ textbox

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tác giả này?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    tacGiaBLL.DeleteTacGia(maTacGia);
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                    MessageBox.Show("Xóa tác giả thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tác giả: " + ex.Message);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                var tacGiaList = tacGiaBLL.GetAllTacGia()
                                          .Where(tg => tg.TenTacGia.Contains(txtTenTacGia.Text)) // Tìm kiếm theo tên tác giả
                                          .Select(tg => new
                                          {
                                              tg.MaTacGia,
                                              tg.TenTacGia,
                                              tg.QuocGia
                                          })
                                          .ToList();

                if (tacGiaList.Count > 0)
                {
                    dgvTacGia.DataSource = tacGiaList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy tác giả.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm tác giả: " + ex.Message);
            }
        }

        private void dgvTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTacGia.Rows[e.RowIndex];
                txtMaTacGia.Text = row.Cells["MaTacGia"].Value.ToString();
                txtTenTacGia.Text = row.Cells["TenTacGia"].Value.ToString();
                txtQuocGia.Text = row.Cells["QuocGia"].Value.ToString();
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
