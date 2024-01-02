using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bilgiayarli_goru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                
                if (comboBox1.Text == "Histogram")
                {
                    DrawGrayScaleHistogram((Bitmap)pictureBox1.Image);
                }
                if (comboBox1.Text == "Gri yap")
                {
                    griformat((Bitmap)pictureBox1.Image);
                }
                pixelsayisi((Bitmap)pictureBox1.Image);
                pixelsayisi((Bitmap)pictureBox2.Image);
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin!");
            }
        }
        public void griformat(Bitmap resim)
        {
            Bitmap yeniResim = new Bitmap(resim.Width, resim.Height);

            for (int x = 0; x < resim.Width; x++)
            {
                for (int y = 0; y < resim.Height; y++)
                {
                    Color pixelrenk = resim.GetPixel(x, y);
                    int griDeger = (int)(pixelrenk.R * 0.3 + pixelrenk.G * 0.59 + pixelrenk.B * 0.11);
                    Color yeniRenk = Color.FromArgb(griDeger, griDeger, griDeger);

                    yeniResim.SetPixel(x, y, yeniRenk);
                }
            }

            // Yeni resmi pictureBox2'ye at
            pictureBox2.Image = yeniResim;
        }
        public void DrawGrayScaleHistogram(Bitmap resim)
        {
            
            { // Histogram verilerini hesapla
                int[] histogram = new int[256];

                for (int x = 0; x < resim.Width; x++)
                {
                    for (int y = 0; y < resim.Height; y++)
                    {
                        Color pixelrenk = resim.GetPixel(x, y);
                        int histogramdeger = (int)(pixelrenk.R * 0.3 + pixelrenk.G * 0.59 + pixelrenk.B * 0.11);
                        histogram[histogramdeger]++;
                    }
                }

                // Chart'ı temizle"
                chart1.Series.Clear();

                // Gri tonları için seriyi ekle
                Series seriesGray = new Series("Gray");
                seriesGray.ChartType = SeriesChartType.Column; // Grafik tipi belirle
                seriesGray.Color = Color.Black;

                for (int i = 0; i < 256; i++)
                {
                    seriesGray.Points.AddXY(i, histogram[i]);
                }

                // Seriyi Chart'a ekle
                chart1.Series.Add(seriesGray);

                // Achsen stilini düzenle
                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Red;
                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Red;

                // Bar genişliklerini düzenle
                chart1.Series["Gray"].CustomProperties = "PointWidth = 0.5";

                // Chart'ı güncelle
                chart1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }
        


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Histogram");
            comboBox1.Items.Add("Gri yap");
            comboBox1.Items.Add("KM intensity");
            comboBox1.Items.Add("KM öklit RGB");
            comboBox1.Items.Add("sobel");
           
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void pixelsayisi(Bitmap resim)
        {
            if (resim == null)
            {

                listView1.Items.Add("pixsel değeri bulunmadı");
            }
            else
            {
                string deger1=pictureBox1.Image.ToString();
                string deger2=pictureBox2.Image.ToString();
                int pikselSayisi = resim.Width * resim.Height;
                string pikselSayisiString = pikselSayisi.ToString();
                ListViewItem item = new ListViewItem(deger1);
                item.SubItems.Add(deger2);

               
                listView1.Items.Add(item);



            }
        }
    }
    }

    
