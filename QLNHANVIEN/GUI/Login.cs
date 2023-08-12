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

namespace QLNHANVIEN.GUI
{
    public partial class Login : Form
    {
        LoginBAL accBAL = new LoginBAL();
        public Login()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            List<LoginBEL> lstAcc = accBAL.ReadCustomer();
            LoginBEL foundAccount = lstAcc.FirstOrDefault(acc => acc.Acc_name == username && acc.Acc_password == password);

            if (foundAccount != null)
            {
                // Đăng nhập thành công, thực hiện các thao tác sau khi đăng nhập
                MessageBox.Show("Đăng nhập thành công!");
                // Mở form chính của ứng dụng sau khi đăng nhập thành công
                Menu menu = new Menu();
                menu.Show();
                this.Hide();
            }
            else
            {
                // Đăng nhập không thành công, hiển thị thông báo lỗi
                MessageBox.Show("Tên tài khoản hoặc mật khẩu không chính xác!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
