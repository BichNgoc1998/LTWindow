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
    public partial class InfoWindows : Form
    {
        public InfoWindows()
        {
            InitializeComponent();
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
