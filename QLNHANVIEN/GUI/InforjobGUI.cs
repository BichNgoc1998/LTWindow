using QLNHANVIEN.BAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;


namespace QLNHANVIEN.GUI
{
    public partial class InforjobGUI : Form
    {
        InforjobBAL nvBAL = new InforjobBAL();
        TypeoemBAL loaiBAL = new TypeoemBAL();
        PositionBAL chucBAL = new PositionBAL();
        DepartmentBAL phongBAL = new DepartmentBAL();

        public InforjobGUI()
        {
            InitializeComponent();
            dgvTtcv.CellClick += dgvTtcv_CellClick;
            tbLuong.KeyPress += tbLuong_KeyPress;
            tbTKNH.KeyPress += tbTKNH_KeyPress;
            tbHso.KeyPress += tbHso_KeyPress;
            tbMa.KeyPress += tbMa_KeyPress;
        }
        private void tbMa_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu phím được nhấn là một chữ số hoặc một phím điều khiển (như backspace)            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Ngăn việc nhập ký tự
                e.Handled = true;

                // Hiển thị thông báo lỗi
                MessageBox.Show("Bạn chỉ được nhập số cho ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbTKNH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Bạn hãy nhập ký tự số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                MessageBox.Show("Bạn hãy nhập ký tự số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbHso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 

                MessageBox.Show("Bạn hãy nhập ký tự số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(tbMa.Text) ||
                string.IsNullOrWhiteSpace(dtVao.Text) ||
                string.IsNullOrWhiteSpace(tbCongviec.Text) ||
                string.IsNullOrWhiteSpace(tbLuong.Text) ||
                string.IsNullOrWhiteSpace(tbHso.Text) ||
                string.IsNullOrWhiteSpace(tbTKNH.Text) ||
                string.IsNullOrWhiteSpace(tbNghang.Text) ||
                cbLoai.SelectedItem == null||
                cbChucvu.SelectedItem == null||
                cbPhong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void RefreshData()
        {
            List<InforjobBEL> lstCl = nvBAL.ReadInforjob();
            dgvTtcv.Rows.Clear();

            foreach (InforjobBEL cl in lstCl)
            {
                dgvTtcv.Rows.Add(
                    cl.Manv,
                    cl.Ngvaolam,
                    cl.Loai.Tenloai,
                    cl.Chucvu.Tench,
                    cl.Congviec,
                    cl.Phong.Tenphong,
                    cl.Muclg,
                    cl.Hso,
                    cl.Tknh,
                    cl.Nghang
                );
            }
        }
        private void tbMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedEmployeeId = (int)tbMa.SelectedItem;
        }
        private void InforjobGUI_Load(object sender, EventArgs e)
        {
            List<InforjobBEL> lstInfo = nvBAL.ReadInforjob();
            foreach (InforjobBEL info in lstInfo)
            {
                dgvTtcv.Rows.Add(info.Manv, info.Ngvaolam, info.TenLoaiNV, info.TenChucVu,
                info.Congviec, info.TenPhong, info.Muclg, info.Hso, info.Tknh, info.Nghang);
            }

            List<TypeoemBEL> lstLoai = loaiBAL.ReadTypeList();
            foreach (TypeoemBEL loai in lstLoai)
            {
                cbLoai.Items.Add(loai);
            }
            cbLoai.DisplayMember = "tenloai";

            List<PositionBEL> lstChuc = chucBAL.ReadPositionList();
            foreach (PositionBEL chuc in lstChuc)
            {
                cbChucvu.Items.Add(chuc);
            }
            cbChucvu.DisplayMember = "tench";

            List<DepartmentBEL> lstPhong = phongBAL.ReadDepartmentList();
            foreach (DepartmentBEL phong in lstPhong)
            {
                cbPhong.Items.Add(phong);
            }
            cbPhong.DisplayMember = "tenphong";

            // Đặt cách hiển thị ngày tháng trong tiếng Việt
            dtVao.Format = DateTimePickerFormat.Custom;
            dtVao.CustomFormat = "dd/MM/yyyy";
            // Hiển thị ngày tháng trong tiếng Việt
            System.Globalization.CultureInfo viCulture = new System.Globalization.CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentCulture = viCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = viCulture;

            List<int> employeeIds = nvBAL.GetEmployeeIds();
            foreach (int id in employeeIds)
            {
                tbMa.Items.Add(id);
            }

            RefreshData();
        }
        private void dgvTtcv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTtcv.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvTtcv.Rows[e.RowIndex];

                string Manv = selectedRow.Cells[0].Value?.ToString() ?? "";
                string Ngayvaolam = selectedRow.Cells[1].Value?.ToString() ?? "";
                string Loai = selectedRow.Cells[2].Value?.ToString() ?? "";
                string Chucvu = selectedRow.Cells[3].Value?.ToString() ?? "";
                string Congviec = selectedRow.Cells[4].Value?.ToString() ?? "";
                string Phong = selectedRow.Cells[5].Value?.ToString() ?? "";
                string Muclg = selectedRow.Cells[6].Value?.ToString() ?? "";
                string Hso = selectedRow.Cells[7].Value?.ToString() ?? "";
                string Tknh = selectedRow.Cells[8].Value?.ToString() ?? "";
                string Nghang = selectedRow.Cells[9].Value?.ToString() ?? "";

                tbMa.Text = Manv;
                dtVao.Text = Ngayvaolam;
                cbLoai.Text = Loai;
                cbChucvu.Text = Chucvu;
                tbCongviec.Text = Congviec;
                cbPhong.Text = Phong;
                tbLuong.Text = Muclg;
                tbHso.Text = Hso;
                tbTKNH.Text = Tknh;
                tbNghang.Text = Nghang;

            }
        }
        private void dgvTtcv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvTtcv.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = row.Cells[0].Value.ToString();
                dtVao.Text = row.Cells[1].Value.ToString();
                cbLoai.Text = row.Cells[2].Value.ToString();
                cbChucvu.Text = row.Cells[3].Value.ToString();
                tbCongviec.Text = row.Cells[4].Value.ToString();
                cbPhong.Text = row.Cells[5].Value.ToString();
                tbLuong.Text = row.Cells[6].Value.ToString();
                tbHso.Text = row.Cells[7].Value.ToString();
                tbTKNH.Text = row.Cells[8].Value.ToString();
                tbNghang.Text = row.Cells[9].Value.ToString();
            }
        }
        private bool IsEmployeeIdDuplicate(int manv)
        {
            foreach (DataGridViewRow row in dgvTtcv.Rows)
            {
                if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == manv)
                {
                    return true; //ID trùng
                }
            }
            return false; // ID không trùng
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                int newId = int.Parse(tbMa.Text);

                if (IsEmployeeIdDuplicate(newId))
                {
                    MessageBox.Show("ID nhân viên đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                InforjobBEL info = new InforjobBEL();
                info.Manv = int.Parse(tbMa.Text);
                info.Ngvaolam = dtVao.Text;
                info.Loai = (TypeoemBEL)cbLoai.SelectedItem;
                info.Chucvu = (PositionBEL)cbChucvu.SelectedItem;
                info.Congviec = tbCongviec.Text;
                info.Phong = (DepartmentBEL)cbPhong.SelectedItem;
                info.Muclg = float.Parse(tbLuong.Text);
                info.Hso = int.Parse(tbHso.Text);
                info.Tknh = int.Parse(tbTKNH.Text);
                info.Nghang = tbNghang.Text;
                nvBAL.NewInforjob(info);

                dgvTtcv.Rows.Add(info.Manv, info.Ngvaolam, info.Loai.Tenloai, info.Chucvu.Tench,
                    info.Congviec, info.Phong.Tenphong, info.Muclg, info.Hso, info.Tknh, info.Nghang);

                // Hiển thị thông báo thêm mới thành công
                MessageBox.Show("Thêm mới thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       
        private void btSua_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                DataGridViewRow row = dgvTtcv.CurrentRow;
                if (row != null)
                {
                    int currentEmployeeId = int.Parse(row.Cells[0].Value.ToString());

                    if (int.Parse(tbMa.Text) != currentEmployeeId && IsEmployeeIdDuplicate(int.Parse(tbMa.Text)))
                    {
                        MessageBox.Show("ID nhân viên đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    InforjobBEL info = new InforjobBEL();
                    info.Manv = int.Parse(tbMa.Text);
                    info.Ngvaolam = dtVao.Text;
                    info.Loai = (TypeoemBEL)cbLoai.SelectedItem;
                    info.Chucvu = (PositionBEL)cbChucvu.SelectedItem;
                    info.Congviec = tbCongviec.Text;
                    info.Phong = (DepartmentBEL)cbPhong.SelectedItem;
                    info.Muclg = float.Parse(tbLuong.Text);
                    info.Hso = int.Parse(tbHso.Text);
                    info.Tknh = int.Parse(tbTKNH.Text);
                    info.Nghang = tbNghang.Text;
                    nvBAL.EditInforjob(info);

                    row.Cells[0].Value = info.Manv;
                    row.Cells[1].Value = info.Ngvaolam;
                    row.Cells[2].Value = info.TenLoaiNV;
                    row.Cells[3].Value = info.TenChucVu;
                    row.Cells[4].Value = info.Congviec;
                    row.Cells[5].Value = info.TenPhong;
                    row.Cells[6].Value = info.Muclg;
                    row.Cells[7].Value = info.Hso;
                    row.Cells[8].Value = info.Tknh;
                    row.Cells[9].Value = info.Nghang;

                    // Hiển thị thông báo sửa thành công
                    MessageBox.Show("Sửa thông tin công việc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTtcv.CurrentRow;
            if (row != null)
            {
                int employeeId = int.Parse(row.Cells[0].Value.ToString());

                // Hiển thị hộp thoại xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    // Xóa nhân viên bằng ID trong database
                    InforjobBEL employeeToDelete = nvBAL.GetInforjobById(employeeId);
                    if (employeeToDelete != null)
                    {
                        nvBAL.DeleteInforjob(employeeToDelete);
                    }

                    // Xóa hàng khỏi DataGridView
                    dgvTtcv.Rows.RemoveAt(row.Index);

                    // Hiển thị thông báo thành công
                    MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?", "Xác nhận",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btXuat_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportDialog = new SaveFileDialog();
            exportDialog.Filter = "Excel Files|*.xlsx";

            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Employee Data");

                    // Thêm tiêu đề cột vào bảng tín
                    for (int col = 0; col < dgvTtcv.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dgvTtcv.Columns[col].HeaderText;
                    }

                    // Điền dữ liệu vào các dòng
                    for (int row = 0; row < dgvTtcv.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvTtcv.Columns.Count; col++)
                        {
                            object cellValue = dgvTtcv.Rows[row].Cells[col].Value;
                            worksheet.Cell(row + 2, col + 1).Value = cellValue != null ? cellValue.ToString() : string.Empty;
                        }
                    }

                    // Lưu workbook
                    workbook.SaveAs(exportDialog.FileName);
                }

                MessageBox.Show("Xuất dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
