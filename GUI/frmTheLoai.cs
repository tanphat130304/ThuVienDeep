using BLL;
using DAL;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheLoai : Form
    {
        // Biến lưu kích thước ban đầu của form và các điều khiển
        private Size formOriginalSize;
        private Rectangle recTxtMaTheLoai, recTxtTenTheLoai;
        private Rectangle recBtnThem, recBtnSua, recBtnXoa, recBtnTimKiem, recBtnQuayLai;
        private Rectangle recDgvTheLoai;

        TheLoaiBLL theLoaiBLL;

        public frmTheLoai()
        {
            InitializeComponent();
            theLoaiBLL = new TheLoaiBLL(); // Khởi tạo đối tượng BLL
            LoadData();

            // Đăng ký sự kiện Load và Resize cho form
            this.Load += frmTheLoai_Load;
            this.Resize += frmTheLoai_Resize;
        }

        private void frmTheLoai_Load(object sender, EventArgs e)
        {
            // Lưu kích thước ban đầu của form và các điều khiển
            formOriginalSize = this.Size;
            recTxtMaTheLoai = new Rectangle(txtMaTheLoai.Location, txtMaTheLoai.Size);
            recTxtTenTheLoai = new Rectangle(txtTenTheLoai.Location, txtTenTheLoai.Size);
            recBtnThem = new Rectangle(btn_Them.Location, btn_Them.Size);
            recBtnSua = new Rectangle(btn_Sua.Location, btn_Sua.Size);
            recBtnXoa = new Rectangle(btn_Xoa.Location, btn_Xoa.Size);
            recBtnTimKiem = new Rectangle(btn_TimKiem.Location, btn_TimKiem.Size);
            recBtnQuayLai = new Rectangle(btn_QuayLai.Location, btn_QuayLai.Size);
            recDgvTheLoai = new Rectangle(dgvTheLoai.Location, dgvTheLoai.Size);
        }

        private void frmTheLoai_Resize(object sender, EventArgs e)
        {
            // Cập nhật vị trí và kích thước các điều khiển khi form thay đổi kích thước
            ResizeControl(txtMaTheLoai, recTxtMaTheLoai);
            ResizeControl(txtTenTheLoai, recTxtTenTheLoai);
            ResizeControl(btn_Them, recBtnThem);
            ResizeControl(btn_Sua, recBtnSua);
            ResizeControl(btn_Xoa, recBtnXoa);
            ResizeControl(btn_TimKiem, recBtnTimKiem);
            ResizeControl(btn_QuayLai, recBtnQuayLai);
            ResizeControl(dgvTheLoai, recDgvTheLoai);
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
            var theLoaiList = theLoaiBLL.GetAllTheLoai()
                                        .Select(tl => new
                                        {
                                            tl.MaTheLoai,
                                            tl.TenTheLoai
                                        })
                                        .ToList();

            dgvTheLoai.DataSource = theLoaiList; // Chỉ hiển thị các cột đã chọn
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                TheLoai theLoai = new TheLoai()
                {
                    TenTheLoai = txtTenTheLoai.Text
                };

                theLoaiBLL.AddTheLoai(theLoai);
                LoadData(); // Tải lại dữ liệu sau khi thêm
                MessageBox.Show("Thêm thể loại thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thể loại: " + ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = string.Format("Hôm nay là ngày {0} - Bây giờ là {1}",
    DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss tt"));
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                int maTheLoai = int.Parse(txtMaTheLoai.Text); // Lấy mã thể loại từ textbox
                TheLoai theLoai = new TheLoai()
                {
                    MaTheLoai = maTheLoai, // Cần cung cấp mã thể loại để cập nhật
                    TenTheLoai = txtTenTheLoai.Text
                };

                theLoaiBLL.UpdateTheLoai(theLoai);
                LoadData(); // Tải lại dữ liệu sau khi sửa
                MessageBox.Show("Cập nhật thể loại thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật thể loại: " + ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                int maTheLoai = int.Parse(txtMaTheLoai.Text); // Lấy mã thể loại từ textbox

                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?",
                                                     "Xác nhận xóa",
                                                     MessageBoxButtons.YesNo);

                if (confirmResult == DialogResult.Yes)
                {
                    theLoaiBLL.DeleteTheLoai(maTheLoai);
                    LoadData(); // Tải lại dữ liệu sau khi xóa
                    MessageBox.Show("Xóa thể loại thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa thể loại: " + ex.Message);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtTenTheLoai.Text.Trim().ToLower(); // Lấy chuỗi tìm kiếm và chuyển thành chữ thường

                var theLoaiList = theLoaiBLL.GetAllTheLoai()
                                            .Where(tl => tl.TenTheLoai.ToLower().Contains(searchText)) // Chuyển thành chữ thường trước khi tìm kiếm
                                            .Select(tl => new
                                            {
                                                tl.MaTheLoai,
                                                tl.TenTheLoai
                                            })
                                            .ToList();

                if (theLoaiList.Count > 0)
                {
                    dgvTheLoai.DataSource = theLoaiList;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thể loại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm thể loại: " + ex.Message);
            }
        }

        private void dgvTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTheLoai.Rows[e.RowIndex];
                txtMaTheLoai.Text = row.Cells["MaTheLoai"].Value.ToString();
                txtTenTheLoai.Text = row.Cells["TenTheLoai"].Value.ToString();
            }
        }

        private void btn_QuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
