using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CBImgSave
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string fname;
        public string imgfrm;
        public ImageFormat imgfrm1;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Clipboard.ContainsImage())
            {
                pictureBox1.Image = Clipboard.GetImage();
            }
            Console.WriteLine(GetDownloadFolderPath());
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
                if (Clipboard.ContainsImage())
                {
                    pictureBox1.Image = Clipboard.GetImage();
                }
            else
            {
                button2.Text = "No image detected!";
                button2.Enabled = false;
                Task.Delay(1);
                button2.Text = "Preview image";
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            try
            {
                if (textBox2.Text.Contains("-jpeg"))
                {
                    imgfrm = ".jpeg";
                    imgfrm1 = ImageFormat.Jpeg;
                }
                if (textBox2.Text.Contains("-png"))
                {
                    imgfrm = ".png";
                    imgfrm1 = ImageFormat.Png;
                }
                if (textBox2.Text.Contains("-gif"))
                {
                    imgfrm = ".gif";
                    imgfrm1 = ImageFormat.Gif;
                }
                if (textBox2.Text.Contains("-gif"))
                {
                    imgfrm = ".gif";
                    imgfrm1 = ImageFormat.Gif;
                }
                if (Clipboard.ContainsImage())
                {
                    if (textBox2.Text.Contains("-randomizefilename"))
                    {
                        fname = GetDownloadFolderPath() + @"\" + rnd.Next(1, 100000000) + imgfrm;
                    }
                    else
                    {
                        fname = GetDownloadFolderPath() + @"\" + textBox1.Text + imgfrm;
                    }
                    Clipboard.GetImage().Save(fname, imgfrm1);
                }
                else
                {
                    MessageBox.Show("No image detected!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }
        string GetDownloadFolderPath()
        {
            return Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
        }
    }
}
