using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace PicCommon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Int32.MaxValue.ToString());
            //Common.SaveAs(@"D:\4.jpg", @"C:\4.jpg");
            //Image image=Image.FromFile(@"C:\Users\HY\Desktop\4.jpg");
            //int height = image.Height;
            //int width = image.Width;
            //image.Dispose();

            //Common.GetPicThumbnail(@"C:\Users\HY\Desktop\4.jpg", @"D:\4.jpg",height,width, 1);
            Common.Compress(@"C:\Users\HY\Desktop\picTest.txt");
        }

        public static void S()
        {
            WebClient web = new WebClient();
            HttpWebRequest
        }
    }
}
