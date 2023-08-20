using QLNHANVIEN.BAL;
using QLNHANVIEN.DAL;
using QLNHANVIEN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Globalization;
using DocumentFormat.OpenXml.Wordprocessing;
using iTextSharp.text.pdf;

namespace QLNHANVIEN.GUI
{
    public partial class MainForm : Form
    {
        EmployeeBAL nvBAL = new EmployeeBAL();
        DegreeBAL bangBAL = new DegreeBAL();
        DepartmentBAL phongBAL = new DepartmentBAL();
        private List<EmployeeBEL> employees;
        DBConnection dbConnection = new DBConnection();
        PictureBox pb = new PictureBox();
        private List<string> imageNames = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            dgvEmployee.CellClick += dgvEmployee_CellClick;
            tbName.KeyPress += tbName_KeyPress;
            tbSdt.KeyPress += tbSdt_KeyPress;
            tbId.KeyPress += tbId_KeyPress;
            tbCccd.KeyPress += tbCccd_KeyPress;
        }
        private void tbCccd_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím được nhấn có phải là chữ số hoặc phím điều khiển (như phím Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Ngăn việc nhập ký tự
                e.Handled = true;

                // Hiển thị thông báo lỗi
                MessageBox.Show("Bạn chỉ được nhập số cho CCCD.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím được nhấn có phải là chữ số hoặc phím điều khiển (như phím Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Ngăn việc nhập ký tự
                e.Handled = true;

                // Hiển thị thông báo lỗi
                MessageBox.Show("Bạn chỉ được nhập số cho ID.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím được nhấn có phải là chữ cái, phím điều khiển (như phím Backspace), hoặc dấu cách
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Ngăn việc nhập ký tự
                e.Handled = true;

                // Hiển thị thông báo lỗi
                MessageBox.Show("Bạn phải nhập ký tự là chữ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem phím được nhấn có phải là số hoặc phím điều khiển (như phím Backspace)
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // Ngăn việc nhập ký tự
                e.Handled = true;

                // Hiển thị thông báo lỗi
                MessageBox.Show("Bạn hãy nhập Số điện thoại là ký tự số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvEmployee.Rows[e.RowIndex];

                tbId.Text = selectedRow.Cells[0].Value?.ToString() ?? "";
                tbName.Text = selectedRow.Cells[1].Value?.ToString() ?? "";
                dtNgsinh.Text = selectedRow.Cells[2].Value?.ToString() ?? "";
                tbCccd.Text = selectedRow.Cells[3].Value?.ToString() ?? "";
                dtNgcap.Text = selectedRow.Cells[4].Value?.ToString() ?? "";
                tbDiachi.Text = selectedRow.Cells[7].Value?.ToString() ?? "";
                tbEmail.Text = selectedRow.Cells[8].Value?.ToString() ?? "";
                tbSdt.Text = selectedRow.Cells[9].Value?.ToString() ?? "";
                string selectedImageName = selectedRow.Cells[6].Value?.ToString() ?? "";


                // Cập nhật PictureBox bằng hình ảnh đã chọn
                if (!string.IsNullOrEmpty(selectedImageName))
                {
                    string imagePath = Path.Combine(@"d:\", selectedImageName); // Giả sử các hình ảnh nằm trong thư mục d:\
                    pb.ImageLocation = imagePath;
                }
                else
                {
                    pb.ImageLocation = null;
                }
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(tbId.Text) ||
                string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(dtNgsinh.Text) ||
                string.IsNullOrWhiteSpace(tbCccd.Text) ||
                string.IsNullOrWhiteSpace(dtNgcap.Text) ||
                (!cbMale.Checked && !cbFemale.Checked) ||
                string.IsNullOrWhiteSpace(tbDiachi.Text) ||
                string.IsNullOrWhiteSpace(tbEmail.Text) ||
                string.IsNullOrWhiteSpace(tbSdt.Text) ||
                cbBang.SelectedItem == null ||
                cbPhong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private bool IsEmployeeIdDuplicate(int id)
        {
            foreach (DataGridViewRow row in dgvEmployee.Rows)
            {
                if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == id)
                {
                    return true; // ID trùng
                }
            }
            return false; // ID không trùng
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                int newId = int.Parse(tbId.Text);

                if (IsEmployeeIdDuplicate(newId))
                {
                    MessageBox.Show("ID nhân viên đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!tbEmail.Text.ToLower().EndsWith("@gmail.com"))
                {
                    MessageBox.Show("Email phải kết thúc bằng '@gmail.com'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                EmployeeBEL nv = new EmployeeBEL();
                nv.Id = int.Parse(tbId.Text);
                nv.Name = tbName.Text;
                nv.Ngsinh = dtNgsinh.Text;
                nv.Cccd = tbCccd.Text;
                nv.Ngcap = dtNgcap.Text;

                // Xử lý ComboBox giới tính
                nv.Gioitinh = cbMale.Checked ? "Nam" : (cbFemale.Checked ? "Nữ" : "Khác");

                nv.Diachi = tbDiachi.Text;
                nv.Email = tbEmail.Text;
                nv.Sdt = int.Parse(tbSdt.Text);

                // Giả sử Mabang và Maphong là các thuộc tính chứa các ID.
                DegreeBEL selectedDegree = (DegreeBEL)cbBang.SelectedItem;
                DepartmentBEL selectedDepartment = (DepartmentBEL)cbPhong.SelectedItem;

                nv.MaBang = selectedDegree.Mabang;
                nv.MaPhong = selectedDepartment.Maphong;

                string imageFileName = Path.GetFileName(selectedImageName);
                nv.Image = selectedImageName;

                nvBAL.NewEmployee(nv);

                // Thêm nhân viên mới vào DataGridView.
                dgvEmployee.Rows.Add(
                    nv.Id,
                    nv.Name,
                    nv.Ngsinh,
                    nv.Cccd,
                    nv.Ngcap,
                    nv.Gioitinh,
                    nv.Image,  // Cập nhật DataGridView với tên tệp hình ảnh.
                    nv.Diachi,
                    nv.Email,
                    nv.Sdt,
                    nv.MaBang,
                    nv.MaPhong);

                // Hiển thị thông báo thành công cho nhân viên mới.
                MessageBox.Show("Thêm mới nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                DataGridViewRow row = dgvEmployee.CurrentRow;
                if (row != null)
                {
                    int newId = int.Parse(tbId.Text);
                    int originalId = int.Parse(row.Cells[0].Value.ToString());

                    // Kiểm tra xem ID mới có khớp với một ID hiện tại (khác với ID ban đầu) hay không.
                    if (newId != originalId && IsEmployeeIdDuplicate(newId))
                    {
                        MessageBox.Show("ID nhân viên đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (!tbEmail.Text.ToLower().EndsWith("@gmail.com"))
                    {
                        MessageBox.Show("Email phải kết thúc bằng '@gmail.com'.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    EmployeeBEL nv = new EmployeeBEL();
                    nv.Id = int.Parse(tbId.Text);
                    nv.Name = tbName.Text;
                    nv.Ngsinh = dtNgsinh.Text;
                    nv.Cccd = tbCccd.Text;
                    nv.Ngcap = dtNgcap.Text;

                    // Xử lý ComboBox giới tính.
                    nv.Gioitinh = cbMale.Checked ? "Nam" : (cbFemale.Checked ? "Nữ" : "Khác");

                    nv.Diachi = tbDiachi.Text;
                    nv.Email = tbEmail.Text;
                    nv.Sdt = int.Parse(tbSdt.Text);

                    // Giả sử Mabang và Maphong là các thuộc tính chứa các ID.
                    DegreeBEL selectedDegree = (DegreeBEL)cbBang.SelectedItem;
                    DepartmentBEL selectedDepartment = (DepartmentBEL)cbPhong.SelectedItem;

                    nv.MaBang = selectedDegree.Mabang;
                    nv.MaPhong = selectedDepartment.Maphong;

                    // Thiết lập thuộc tính hình ảnh nếu selectedImageName không null hoặc trống.
                    if (!string.IsNullOrEmpty(selectedImageName))
                    {
                        nv.Image = selectedImageName;
                    }

                    // Gọi phương thức EditEmployee.
                    nvBAL.EditEmployee(nv);

                    // Cập nhật các ô dữ liệu của hàng với các giá trị mới, bao gồm cả tên tệp hình ảnh.
                    row.Cells[0].Value = nv.Id;
                    row.Cells[1].Value = nv.Name;
                    row.Cells[2].Value = nv.Ngsinh;
                    row.Cells[3].Value = nv.Cccd;
                    row.Cells[4].Value = nv.Ngcap;
                    row.Cells[5].Value = nv.Gioitinh;
                    row.Cells[6].Value = nv.Image; // Điều này nên bao gồm tên tệp hình ảnh.
                    row.Cells[7].Value = nv.Diachi;
                    row.Cells[8].Value = nv.Email;
                    row.Cells[9].Value = nv.Sdt;
                    row.Cells[10].Value = nv.MaBang;
                    row.Cells[11].Value = nv.MaPhong;

                    // Hiển thị thông báo thành công cho việc chỉnh sửa thông tin nhân viên.
                    MessageBox.Show("Sửa thông tin nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployee.CurrentRow;
            if (row != null)
            {
                int employeeId = int.Parse(row.Cells[0].Value.ToString());

                // Yêu cầu xác nhận trước khi xóa.
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    // Xóa nhân viên từ database
                    EmployeeBEL customerToDelete = nvBAL.GetEmployeeById(employeeId);
                    if (customerToDelete != null)
                    {
                        nvBAL.DeleteEmployee(customerToDelete);
                    }

                    // Xóa nhân viên khỏi DataGridView.
                    dgvEmployee.Rows.RemoveAt(row.Index);

                    // Thông báo xóa thành công
                    MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void RefreshData()
        {
            List<EmployeeBEL> lstCl = nvBAL.ReadEmployee();
            dgvEmployee.Rows.Clear();

            imageNames.Clear();

            foreach (EmployeeBEL cl in lstCl)
            {
                dgvEmployee.Rows.Add(
                    cl.Id,
                    cl.Name,
                    cl.Ngsinh,
                    cl.Cccd,
                    cl.Ngcap,
                    cl.Gioitinh,
                    cl.Image,
                    cl.Diachi,
                    cl.Email,
                    cl.Sdt,
                    cl.MaBang,
                    cl.MaPhong
                );

                // Thêm tên hình ảnh vào danh sách.
                imageNames.Add(cl.SelectedImageName); // Sử dụng thuộc tính SelectedImageName.
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            List<DegreeBEL> lstBang = bangBAL.ReadDegreeList();
            foreach (DegreeBEL bang in lstBang)
            {
                cbBang.Items.Add(bang);
            }
            cbBang.DisplayMember = "Tenbang";

            List<DepartmentBEL> lstPhong = phongBAL.ReadDepartmentList();
            foreach (DepartmentBEL phong in lstPhong)
            {
                cbPhong.Items.Add(phong);
            }
            cbPhong.DisplayMember = "Tenphong";


            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(100, 100);
            pb.BorderStyle = BorderStyle.FixedSingle;
            pb.Location = new Point(370, 50);
            gbNhanvien.BackgroundImageLayout = ImageLayout.Stretch; // Điều chỉnh bố cục theo cần thiết.

            // Thêm hình ảnh nền mặc định vào PictureBox trong GroupBox.
            gbNhanvien.Controls.Add(pb);
            // Đặt cách hiển thị ngày tháng trong tiếng Việt
            dtNgsinh.Format = DateTimePickerFormat.Custom;
            dtNgsinh.CustomFormat = "dd/MM/yyyy";
            dtNgcap.Format = DateTimePickerFormat.Custom;
            dtNgcap.CustomFormat = "dd/MM/yyyy";

            // Hiển thị ngày tháng trong tiếng Việt
            System.Globalization.CultureInfo viCulture = new System.Globalization.CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentCulture = viCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = viCulture;

            // Thêm các tùy chọn sắp xếp vào ComboBox.
            cboSapXep.Items.Add("Tên (A-Z)");
            cboSapXep.Items.Add("Tên (Z-A)");
            cboSapXep.Items.Add("ID (Tăng dần)");
            cboSapXep.Items.Add("ID (Giảm dần)");

            cboSapXep.SelectedIndex = 0;

            RefreshData();
        }
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx >= 0 && idx < dgvEmployee.Rows.Count)
            {
                DataGridViewRow row = dgvEmployee.Rows[idx];
                if (row.Cells[0].Value != null)
                {
                    tbId.Text = row.Cells[0].Value.ToString();
                    tbName.Text = row.Cells[1].Value.ToString();
                    dtNgsinh.Text = row.Cells[2].Value.ToString();
                    // Xử lý các nút radio giới tính tương ứng.
                    tbCccd.Text = row.Cells[3].Value.ToString();
                    dtNgcap.Text = row.Cells[4].Value.ToString();
                    cbFemale.Checked = row.Cells[5].Value.ToString() == "Nam";
                    cbMale.Checked = row.Cells[5].Value.ToString() == "Nu";

                    tbDiachi.Text = row.Cells[7].Value.ToString();
                    tbEmail.Text = row.Cells[8].Value.ToString();
                    tbSdt.Text = row.Cells[9].Value.ToString();
                    // Đặt mục được chọn trong các combobox.
                    string selectedBang = row.Cells[10].Value.ToString();
                    string selectedPhong = row.Cells[11].Value.ToString();
                    cbBang.SelectedIndex = cbBang.FindStringExact(selectedBang);
                    cbPhong.SelectedIndex = cbPhong.FindStringExact(selectedPhong);

                    if (imageNames.Count > idx)
                    {
                        selectedImageName = imageNames[idx]; // Cập nhật selectedImageName.
                    }
                }
            }
        }
        private void btExit_1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi ứng dụng?", "Xác nhận",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private string selectedImageName = "";
        private void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                selectedImageName = Path.GetFileName(imagePath); // Lấy tên tệp hình ảnh từ đường dẫn đầy đủ

                // Xóa các PictureBox hiện có khỏi GroupBox.
                gbNhanvien.Controls.RemoveByKey("SelectedPictureBox");

                // Tạo một PictureBox mới cho hình ảnh được chọn.
                PictureBox selectedPictureBox = new PictureBox();
                selectedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                selectedPictureBox.Size = new Size(100, 100);
                selectedPictureBox.Image = Image.FromFile(imagePath);

                // Đặt vị trí mong muốn cho PictureBox được chọn.
                selectedPictureBox.Location = new Point(370, 50); // Điều chỉnh vị trí theo cần thiết.
                selectedPictureBox.Name = "SelectedPictureBox";

                // Thêm PictureBox hình ảnh đã chọn vào GroupBox.
                gbNhanvien.Controls.Add(selectedPictureBox);

                // Đưa PictureBox hình ảnh đã chọn lên trước.
                selectedPictureBox.BringToFront();
            }
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Employee Data");

                    // Thêm tiêu đề vào bảng tính.
                    for (int col = 0; col < dgvEmployee.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dgvEmployee.Columns[col].HeaderText;
                    }

                    // Điền dữ liệu vào các hàng dữ liệu.
                    for (int row = 0; row < dgvEmployee.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvEmployee.Columns.Count; col++)
                        {
                            worksheet.Cell(row + 2, col + 1).Value = dgvEmployee.Rows[row].Cells[col].Value.ToString();
                        }
                    }

                    // Lưu workbook
                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("Xuất dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gbNhanvien_Enter(object sender, EventArgs e)
        {

        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSortColumn = cboSapXep.SelectedItem.ToString();

            if (selectedSortColumn == "Tên (A-Z)")
            {
                dgvEmployee.Sort(dgvEmployee.Columns[1], ListSortDirection.Ascending);
            }
            else if (selectedSortColumn == "Tên (Z-A)")
            {
                dgvEmployee.Sort(dgvEmployee.Columns[1], ListSortDirection.Descending);
            }
            else if (selectedSortColumn == "ID (Tăng dần)")
            {
                dgvEmployee.Sort(dgvEmployee.Columns[0], ListSortDirection.Ascending);
            }
            else if (selectedSortColumn == "ID (Giảm dần)")
            {
                dgvEmployee.Sort(dgvEmployee.Columns[0], ListSortDirection.Descending);
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            dgvEmployee.Rows.Clear();
            EmployeeBEL nv = new EmployeeBEL();
            nv.Name = tbSearch.Text;
            List<EmployeeBEL> lstNV = nvBAL.Timkiem(nv);
            foreach (EmployeeBEL c in lstNV)
            {
                dgvEmployee.Rows.Add(c.Id, c.Name, c.Ngsinh, c.Cccd, c.Ngcap,c.Gioitinh,c.Image,
                    c.Diachi,c.Email,c.Sdt,c.MaBang,c.MaPhong);
            }
        }

    }
}
