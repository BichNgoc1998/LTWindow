using ClosedXML.Excel;
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
using System.Globalization;

namespace QLNHANVIEN.GUI
{
    public partial class TimekeepingGUI : Form
    {
        TimekeepingBAL timeBAL = new TimekeepingBAL();
        StatusBAL ttBAL = new StatusBAL();
        public TimekeepingGUI()
        {
            InitializeComponent();
            dgvTimekeeping.CellClick += dgvTimekeeping_CellClick;
            tbTen.KeyPress += tbTen_KeyPress;
        }
        private void tbTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Bạn phải nhập ký tự là chữ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvTimekeeping_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvTimekeeping.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvTimekeeping.Rows[e.RowIndex];

                string Manv = selectedRow.Cells[0].Value?.ToString() ?? "";
                string Tennv = selectedRow.Cells[1].Value?.ToString() ?? "";
                string Tinhtrang = selectedRow.Cells[2].Value?.ToString() ?? "";
                string Ngay = selectedRow.Cells[3].Value?.ToString() ?? "";

                tbMa.Text = Manv;
                tbTen.Text = Tennv;
                cbTinhtrang.Text = Tinhtrang;
                dtNgaychc.Text = Ngay;

            }
        }
        private void tbMa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedEmployeeId = (int)tbMa.SelectedItem;

            // Bạn có thể muốn lấy tên nhân viên bằng cách sử dụng ID nhân viên đã chọn.
            string employeeName = timeBAL.GetEmployeeName(selectedEmployeeId); // Thay thế điều này bằng phương pháp của bạn để lấy tên nhân viên.

            tbTen.Text = employeeName;
        }
        private void TimekeepingGUI_Load(object sender, EventArgs e)
        {
            List<TimekeepingBEL> lstTime = timeBAL.ReadTimekeeping();
            foreach (TimekeepingBEL time in lstTime)
            {
                dgvTimekeeping.Rows.Add(time.Manv, time.Tennv, time.Tinhtrang);
            }
            List<StatusBEL> lstTT = ttBAL.ReadStatusList();
            foreach (StatusBEL tt in lstTT)
            {
                cbTinhtrang.Items.Add(tt);
            }
            cbTinhtrang.DisplayMember = "tentt";

            // Đặt cách hiển thị ngày tháng trong tiếng Việt
            dtNgaychc.Format = DateTimePickerFormat.Custom;
            dtNgaychc.CustomFormat = "dd/MM/yyyy";
            // Hiển thị ngày tháng trong tiếng Việt
            System.Globalization.CultureInfo viCulture = new System.Globalization.CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentCulture = viCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = viCulture;

            List<int> employeeIds = timeBAL.GetEmployeeIds();
            foreach (int id in employeeIds)
            {
                tbMa.Items.Add(id);
            }

            tbMa.SelectedIndexChanged += tbMa_SelectedIndexChanged;

            RefreshData();
        }

        private void dgvTimekeeping_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvTimekeeping.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbMa.Text = row.Cells[0].Value.ToString();
                tbTen.Text = row.Cells[1].Value.ToString();
                cbTinhtrang.Text = row.Cells[2].Value.ToString();
                dtNgaychc.Text = row.Cells[3].Value.ToString();
            }
        }
        private void RefreshData()
        {
            List<TimekeepingBEL> lstCl = timeBAL.ReadTimekeeping();
            dgvTimekeeping.Rows.Clear();

            foreach (TimekeepingBEL cl in lstCl)
            {
                dgvTimekeeping.Rows.Add(
                    cl.Manv,
                    cl.Tennv,
                    cl.Tinhtrang.Tentt, // Accessing the status name from the StatusBEL instance
                    cl.Ngay
                );
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(tbMa.Text) ||
                string.IsNullOrWhiteSpace(tbTen.Text) ||
                string.IsNullOrWhiteSpace(dtNgaychc.Text) ||
                cbTinhtrang.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                TimekeepingBEL time = new TimekeepingBEL();
                time.Manv = int.Parse(tbMa.Text);
                time.Tennv = tbTen.Text;
                time.Tinhtrang = (StatusBEL)cbTinhtrang.SelectedItem;
                time.Ngay = dtNgaychc.Text;
                timeBAL.NewTimekeeping(time);

                dgvTimekeeping.Rows.Add(time.Manv, time.Tennv, time.Tinhtrang.Tentt, time.Ngay);

                tbMa.Text = "";
                tbTen.Text = "";
                cbTinhtrang.SelectedIndex = -1; // Xóa mục đã chọn.
                dtNgaychc.Text = "";

                MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTimekeeping.CurrentRow;
            if (row != null)
            {
                int TimekeepingId = int.Parse(row.Cells[0].Value.ToString());

                // Yêu cầu xác nhận trước khi xóa.
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    // Xóa nhân viên từ database
                    TimekeepingBEL TimekeepingToDelete = timeBAL.GetTimekeepingId(TimekeepingId);
                    if (TimekeepingToDelete != null)
                    {
                        timeBAL.DeleteTimekeeping(TimekeepingToDelete);
                    }

                    dgvTimekeeping.Rows.RemoveAt(row.Index);

                    MessageBox.Show("Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private bool IsEmployeeIdDuplicate(int id)
        {
            foreach (DataGridViewRow row in dgvTimekeeping.Rows)
            {
                if (row.Cells[0].Value != null && int.Parse(row.Cells[0].Value.ToString()) == id)
                {
                    return true; // ID trùng
                }
            }
            return false; // ID không trùng
        }
        private void btSua_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                DataGridViewRow row = dgvTimekeeping.CurrentRow;
                if (row != null)
                {

                    int currentMa = int.Parse(row.Cells[0].Value.ToString());

                    if (int.Parse(tbMa.Text) != currentMa && IsEmployeeIdDuplicate(int.Parse(tbMa.Text)))
                    {
                        MessageBox.Show("ID nhân viên đã tồn tại. Vui lòng chọn một ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    TimekeepingBEL time = new TimekeepingBEL();
                    time.Manv = int.Parse(tbMa.Text);
                    time.Tennv = tbTen.Text;
                    time.Tinhtrang = (StatusBEL)cbTinhtrang.SelectedItem;
                    time.Ngay = dtNgaychc.Text;
                    timeBAL.EditTimekeeping(time);

                    row.Cells[0].Value = time.Manv;
                    row.Cells[1].Value = time.Tennv;
                    row.Cells[2].Value = time.Tentt;
                    row.Cells[3].Value = time.Ngay;

                    MessageBox.Show("Sửa thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvTimekeeping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btXuatfile_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportDialog = new SaveFileDialog();
            exportDialog.Filter = "Excel Files|*.xlsx";

            if (exportDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Timekeeping Data");

                    // Thêm tiêu đề
                    for (int col = 0; col < dgvTimekeeping.Columns.Count; col++)
                    {
                        worksheet.Cell(1, col + 1).Value = dgvTimekeeping.Columns[col].HeaderText;
                    }

                    // Điền dữ liệu vào các hàng.
                    for (int row = 0; row < dgvTimekeeping.Rows.Count; row++)
                    {
                        for (int col = 0; col < dgvTimekeeping.Columns.Count; col++)
                        {
                            object cellValue = dgvTimekeeping.Rows[row].Cells[col].Value;
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
