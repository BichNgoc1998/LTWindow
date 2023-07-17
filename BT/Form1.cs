using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCau1_Click(object sender, EventArgs e)
        {
            Cau01 cau1 = new Cau01();
            cau1.Show();
        }
        private void btnCau2_Click(object sender, EventArgs e)
        {
            Cau02 cau2 = new Cau02();
            cau2.Show();
        }
        private void btnCau3_Click(object sender, EventArgs e)
        {
            Article01 article01 = new Article01();
            article01.Show();
        }
    }
}
