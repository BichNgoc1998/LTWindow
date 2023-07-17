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
    public partial class Cau02 : Form
    {
        public Cau02()
        {
            InitializeComponent();
        }
        void Cau02_ResizeEnd(object sender, System.EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            this.Text = width.ToString() + "-" + height.ToString();
        }
        void Cau02_Load(object sender, System.EventArgs e)
        {
            int width = this.Size.Width;
            int height = this.Size.Height;
            this.Text = width.ToString() + "-" + height.ToString();
        }
    }
}
