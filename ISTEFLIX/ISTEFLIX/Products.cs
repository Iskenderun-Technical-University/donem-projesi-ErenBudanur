using Dizi_Film_Uyfulaması;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Policy;
using System.Diagnostics;
using System.Windows.Forms;
namespace ISTEFLIX
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }
        private Prod myProd;
        public void set_prod(Prod myP)
        {
            myProd = myP;
            label1.Text = myProd.name;
            using (WebClient client = new WebClient())
            {
                string fileName = "image.jpg"; // Kaydedilecek dosya adı ve uzantısı

                try
                {
                    byte[] imageData = client.DownloadData(myProd.PHOTOURL); // Fotoğraf verilerini indir
                    using (var stream = new System.IO.MemoryStream(imageData))
                    {
                        pictureBox1.Image = System.Drawing.Image.FromStream(stream); // PictureBox'a fotoğrafı atama
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Görüntüyü PictureBox'a sığdırmak için
                        pictureBox1.Show(); // PictureBox'ı görüntüleme
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
            }
        }
        public void goToWeb()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = myProd.URL,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı açılırken bir hata oluştu: " + ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            goToWeb();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            goToWeb();
        }
    }
}
