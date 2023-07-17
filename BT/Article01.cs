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
using System.Xml.Serialization;

namespace BT
{
    public partial class Article01 : Form
    {
        string path = @"D:\form.xml";
        public Article01()
        {
            InitializeComponent();
        }
        public void Write(InfoWindows iw)
        {
            XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
            StreamWriter file = new StreamWriter(path);
            writer.Serialize(file, iw);
            file.Close();
        }
        void Article01_ResizeEnd(object sender, System.EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            int width = this.Size.Width;
            int height = this.Size.Height;
            this.Text = width.ToString() + "-" + height.ToString();
        }
        void Article01_Load(object sender, System.EventArgs e)
        {
            InfoWindows iw = new InfoWindows();
            int width = this.Size.Width;
            int height = this.Size.Height;
            this.Text = width.ToString() + "-" + height.ToString();
        }
    }
}
