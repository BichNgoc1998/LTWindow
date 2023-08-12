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
        List<string> imageNames = new List<string>();

        public MainForm()
        {
            InitializeComponent();
            dgvEmployee.CellEndEdit += dgvEmployee_CellEndEdit;
            dgvEmployee.CellClick += dgvEmployee_CellClick;
            tbName.KeyPress += tbName_KeyPress;
        }
        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a letter, a control key (like backspace), or a space
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                // Prevent the character from being entered
                e.Handled = true;
            }
        }
        private void dgvEmployee_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
            {
                string newImageName = dgvEmployee.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                UpdateImageInPictureBox(newImageName);
            }
        }
        private void UpdateImageInPictureBox(string imageName)
        {
            string imagePath = Path.Combine(@"d:\", imageName);
            pb.ImageLocation = imagePath;
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEmployee.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvEmployee.Rows[e.RowIndex];

                string Id = selectedRow.Cells[0].Value?.ToString() ?? "";
                string Name = selectedRow.Cells[1].Value?.ToString() ?? "";
                string Ngsinh = selectedRow.Cells[2].Value?.ToString() ?? "";
                string Cccd = selectedRow.Cells[3].Value?.ToString() ?? "";
                string Ngcap = selectedRow.Cells[4].Value?.ToString() ?? "";
                string Diachi = selectedRow.Cells[7].Value?.ToString() ?? "";
                string Email = selectedRow.Cells[8].Value?.ToString() ?? "";
                string Sdt = selectedRow.Cells[9].Value?.ToString() ?? "";
                string selectedImageName = selectedRow.Cells[6].Value?.ToString() ?? "";

                tbId.Text = Id;
                tbName.Text = Name;
                dtNgsinh.Text = Ngsinh;
                tbCccd.Text = Cccd;
                dtNgcap.Text = Ngcap;
                tbDiachi.Text = Diachi;
                tbEmail.Text = Email;
                tbSdt.Text = Sdt;
                
                // Update the PictureBox with the selected image
                if (!string.IsNullOrEmpty(selectedImageName))
                {
                    string imagePath = Path.Combine(@"d:\", selectedImageName); // Assuming the images are located in the d:\ directory
                    try
                    {
                        pb.Image = Image.FromFile(imagePath);
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that might occur when loading the image
                        pb.Image = Properties.Resources.DefaultBackgroundImage; // Set a default image
                    }
                }
                else
                {
                    pb.Image = Properties.Resources.DefaultBackgroundImage; // Set a default image
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
        private void btNew_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                EmployeeBEL nv = new EmployeeBEL();
                nv.Id = int.Parse(tbId.Text);
                nv.Name = tbName.Text;
                nv.Ngsinh = dtNgsinh.Text;
                nv.Cccd = tbCccd.Text;
                nv.Ngcap = dtNgcap.Text;

                // Handle the gender ComboBox
                nv.Gioitinh = cbMale.Checked ? "Nam" : (cbFemale.Checked ? "Nữ" : "Khác");

                nv.Diachi = tbDiachi.Text;
                nv.Email = tbEmail.Text;
                nv.Sdt = int.Parse(tbSdt.Text);

                // Assuming Mabang and Maphong are the properties that hold the IDs
                DegreeBEL selectedDegree = (DegreeBEL)cbBang.SelectedItem;
                DepartmentBEL selectedDepartment = (DepartmentBEL)cbPhong.SelectedItem;

                nv.MaBang = selectedDegree.Mabang;
                nv.MaPhong = selectedDepartment.Maphong;

                nvBAL.NewEmployee(nv);

                dgvEmployee.Rows.Add(nv.Id, nv.Name, nv.Ngsinh, nv.Cccd, nv.Ngcap, nv.Gioitinh, selectedImageName, nv.Diachi, nv.Email, nv.Sdt, nv.MaBang, nv.MaPhong);

                // Show success notification for new employee
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
                    EmployeeBEL nv = new EmployeeBEL();
                    nv.Id = int.Parse(tbId.Text);
                    nv.Name = tbName.Text;
                    nv.Ngsinh = dtNgsinh.Text;
                    nv.Cccd = tbCccd.Text;
                    nv.Ngcap = dtNgcap.Text;

                    // Handle the gender ComboBox
                    nv.Gioitinh = cbMale.Checked ? "Nam" : (cbFemale.Checked ? "Nữ" : "Khác");

                    nv.Diachi = tbDiachi.Text;
                    nv.Email = tbEmail.Text;
                    nv.Sdt = int.Parse(tbSdt.Text);

                    // Assuming Mabang and Maphong are the properties that hold the IDs
                    DegreeBEL selectedDegree = (DegreeBEL)cbBang.SelectedItem;
                    DepartmentBEL selectedDepartment = (DepartmentBEL)cbPhong.SelectedItem;

                    nv.MaBang = selectedDegree.Mabang;
                    nv.MaPhong = selectedDepartment.Maphong;

                    nvBAL.EditEmployee(nv);

                    row.Cells[0].Value = nv.Id;
                    row.Cells[1].Value = nv.Name;
                    row.Cells[2].Value = nv.Ngsinh;
                    row.Cells[3].Value = nv.Cccd;
                    row.Cells[4].Value = nv.Ngcap;
                    row.Cells[5].Value = nv.Gioitinh;
                    row.Cells[7].Value = nv.Diachi;
                    row.Cells[8].Value = nv.Email;
                    row.Cells[9].Value = nv.Sdt;
                    row.Cells[10].Value = nv.MaBang;
                    row.Cells[11].Value = nv.MaPhong;

                    // Get the image name from the PictureBox if it exists
                    string imageFileName = Path.GetFileName(selectedImageName);

                    // Update the image name in the DataGridView
                    row.Cells[6].Value = imageFileName;

                    // Show success notification for editing employee
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

                // Prompt for confirmation before deleting
                DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    // Delete the customer from the database
                    EmployeeBEL customerToDelete = nvBAL.GetEmployeeById(employeeId);
                    if (customerToDelete != null)
                    {
                        nvBAL.DeleteEmployee(customerToDelete);
                    }

                    // Remove the customer from the DataGridView
                    dgvEmployee.Rows.RemoveAt(row.Index);

                    // Show success notification for deleting customer
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
                   cl.Diachi,
                   cl.Email,
                   cl.Sdt,
                   cl.MaBang,
                   cl.MaPhong
                   );
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
            pb.Image = Properties.Resources.DefaultBackgroundImage; // Replace with your actual default image
            pb.Location = new Point(370, 50); // Set the desired location for the default background
            gbNhanvien.BackgroundImage = Properties.Resources.DefaultBackgroundImage; // Replace with your actual default image
            gbNhanvien.BackgroundImageLayout = ImageLayout.Stretch; // Adjust the layout as needed

            // Add the default background image PictureBox to the GroupBox
            gbNhanvien.Controls.Add(pb);

            RefreshData();
        }
        private string ChonGT()
        {
            if (cbFemale.Checked)
            {
                return "Nam";
            }
            else if (cbMale.Checked)
            {
                return "Nu";
            }
            else
            {
                return "Khac";
            }
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
                    // Handle the gender radio buttons accordingly
                    tbCccd.Text = row.Cells[3].Value.ToString();
                    dtNgcap.Text = row.Cells[4].Value.ToString();
                    cbFemale.Checked = row.Cells[5].Value.ToString() == "Nam";
                    cbMale.Checked = row.Cells[5].Value.ToString() == "Nu";

                    tbDiachi.Text = row.Cells[7].Value.ToString();
                    tbEmail.Text = row.Cells[8].Value.ToString();
                    tbSdt.Text = row.Cells[9].Value.ToString();
                    // Set the selected item in the comboboxes
                    string selectedBang = row.Cells[9].Value.ToString();
                    string selectedPhong = row.Cells[10].Value.ToString();
                    cbBang.SelectedIndex = cbBang.FindStringExact(selectedBang);
                    cbPhong.SelectedIndex = cbPhong.FindStringExact(selectedPhong);

                    if (imageNames.Count > idx)
                    {
                        string imageName = imageNames[idx];
                        UpdateImageInPictureBox(imageName);
                    }
                }
            }
        }

        private void btExit_1_Click(object sender, EventArgs e)
        {

        }
        private string selectedImageName = "";
        private void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                selectedImageName = openFileDialog.FileName;

                // Create a new PictureBox for the selected image
                PictureBox selectedPictureBox = new PictureBox();
                selectedPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                selectedPictureBox.Size = new Size(100, 100);
                selectedPictureBox.Image = Image.FromFile(imagePath);

                // Set the desired location for the selected PictureBox
                selectedPictureBox.Location = new Point(370, 50); // Adjust the location as needed

                // Remove the existing PictureBoxes from the GroupBox
                gbNhanvien.Controls.RemoveByKey("DefaultBackgroundPictureBox");
                gbNhanvien.Controls.RemoveByKey("SelectedPictureBox");

                // Add the default background image PictureBox to the GroupBox
                pb.Name = "DefaultBackgroundPictureBox";
                gbNhanvien.Controls.Add(pb);

                // Add the selected image PictureBox to the GroupBox
                selectedPictureBox.Name = "SelectedPictureBox";
                gbNhanvien.Controls.Add(selectedPictureBox);

                // Bring the selected image PictureBox to the front
                selectedPictureBox.BringToFront();
            }
        }

    }
}
