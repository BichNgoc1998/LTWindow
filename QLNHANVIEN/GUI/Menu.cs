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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btQLNV_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
        }

        private void btQLCC_Click(object sender, EventArgs e)
        {
            TimekeepingGUI TimekeepingGUI = new TimekeepingGUI();
            TimekeepingGUI.Show();
        }

        private void btQLCV_Click(object sender, EventArgs e)
        {
            InforjobGUI Inforjob = new InforjobGUI();
            Inforjob.Show();
        }
    }
}
