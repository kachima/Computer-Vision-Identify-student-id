using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ZedGraph;
using AForge;
using AForge.Imaging.Filters;
using Tesseract;


namespace Final_Project
{
    public partial class Form1 : Form
    {
        Bitmap InputImage;
        Bitmap Hinhxam1;
        Bitmap SobelImage;
        Bitmap SegmentationImage;
        Bitmap HinhBinary;
        Bitmap HinhCrop;
        public Form1()
        {
            InitializeComponent();
            //Khởi tạo logo
        }
        public static Bitmap Sobel(Bitmap Hinhgoc, byte threshold)
        {
            Bitmap tempImage = new Bitmap(Hinhgoc.Width, Hinhgoc.Height);

            double[,] filter1 = new double[3, 3];

            filter1[0, 0] = -1;
            filter1[0, 1] = -2;
            filter1[0, 2] = -1;
            filter1[1, 0] = 0;
            filter1[1, 1] = 0;
            filter1[1, 2] = 0;
            filter1[2, 1] = 1;
            filter1[2, 2] = 2;
            filter1[2, 0] = 1;

            double[,] filter2 = new double[3, 3];

            filter2[0, 0] = -1;
            filter2[0, 1] = 0;
            filter2[0, 2] = 1;
            filter2[1, 0] = -2;
            filter2[1, 1] = 0;
            filter2[1, 2] = 2;
            filter2[2, 1] = -1;
            filter2[2, 2] = 0;
            filter2[2, 0] = 1;

            Color[,] result = new Color[Hinhgoc.Width, Hinhgoc.Height];

            for (int x = 0; x < Hinhgoc.Width; ++x)
            {
                for (int y = 0; y < Hinhgoc.Height; ++y)
                {
                    double redx = 0.0, greenx = 0.0, bluex = 0.0;
                    double redy = 0.0, greeny = 0.0, bluey = 0.0;
                    for (int filterX = 0; filterX < 3; filterX++)
                    {
                        for (int filterY = 0; filterY < 3; filterY++)
                        {
                            int imageX = (x - 3 / 2 + filterX + Hinhgoc.Width) % Hinhgoc.Width;
                            int imageY = (y - 3 / 2 + filterY + Hinhgoc.Height) % Hinhgoc.Height;
                            Color imageColor = Hinhgoc.GetPixel(imageX, imageY);
                            redx += imageColor.R * filter1[filterX, filterY];
                            redy += imageColor.R * filter2[filterX, filterY];
                        }
                    }
                    double gr = Math.Abs(redx) + Math.Abs(redy);
                    if (gr <= threshold)
                    {
                        result[x, y] = Color.FromArgb(0, 0, 0);
                    }
                    else result[x, y] = Color.FromArgb(255, 255, 255);
                }
            }

            for (int i = 0; i < Hinhgoc.Width; ++i)
            {
                for (int j = 0; j < Hinhgoc.Height; ++j)
                {
                    tempImage.SetPixel(i, j, result[i, j]);
                }
            }

            return tempImage;
        }
        public Bitmap ChuyenHinhRGBSangHinhXamLuminance(Bitmap HinhGoc)
        {
            Bitmap HinhXamLuminance = new Bitmap(HinhGoc.Width, HinhGoc.Height);
            for (int x = 0; x < HinhGoc.Width; x++)
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    // lấy điểm ảnh
                    Color pixel = HinhGoc.GetPixel(x, y);
                    byte R = pixel.R;
                    byte G = pixel.G;
                    byte B = pixel.B;

                    // Tính giá trị mức xám cho điểm ảnh tại x,y
                    byte gray = (byte)(0.2126 * R + 0.7152 * G + 0.0722 * B);

                    // Gán giá trị vừa tính vào hình mức xám
                    HinhXamLuminance.SetPixel(x, y, Color.FromArgb(gray, gray, gray));

                }
            return HinhXamLuminance;
        }
        public Image RotateImage(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bmp;
        }
        public int[] Segmentation(Bitmap HinhGoc, double a)
        {
            int[] range = new int[4];
            double count = 0;
            double[] NumberpointinRow = new double[HinhGoc.Width];
            double[] NumberpointinColumn = new double[HinhGoc.Height];
            double averagex = 0;
            double averagey = 0;
            int fristpointx = 0;
            int lastpointx = 0;
            int fristpointy = 0;
            int lastpointy = 0;

            for (int x = 0; x < HinhGoc.Width; x++)
            {
                for (int y = 0; y < HinhGoc.Height; y++)
                {
                    // lấy điểm ảnh
                    Color color = HinhGoc.GetPixel(x, y);
                    if (color.R == 255)
                    {
                        count++;
                        NumberpointinColumn[y]++;
                    }
                }
                NumberpointinRow[x] = count;
                averagex = (count / HinhGoc.Width) + averagex;
                averagey = (count / HinhGoc.Height) + averagey;
                count = 0;
            }
            for (int x = 0; x < HinhGoc.Width; x++)
            {
                if (NumberpointinRow[x] > averagex * a)
                {
                    fristpointx = x;
                    break;
                }
            }
            for (int x = HinhGoc.Width -1; x > 0; x--)
            {
                if (NumberpointinRow[x] > averagex * a)
                {
                    lastpointx = x;
                    break;
                }
            }
            for (int x = 0; x < HinhGoc.Height; x++)
            {
                if (NumberpointinColumn[x] > averagey * a)
                {
                    fristpointy = x;
                    break;
                }
            }
            for (int x = HinhGoc.Height - 1; x > 0; x--)
            {
                if (NumberpointinColumn[x] > averagey * a)
                {
                    lastpointy = x;
                    break;
                }
            }
            range[0] = fristpointx;
            range[1] = lastpointx;
            range[2] = fristpointy;
            range[3] = lastpointy;
            return range;
        }
        private void InputPicture_Click(object sender, EventArgs e)
        {

        }
        private void SelectBT_Click(object sender, EventArgs e)
        {
            //Mở hình ảnh cần xác định
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg,*.png,*.gif)|*.jpg;*.png;*.gif";//lọc chỉ mở file 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Hiển thị hình ảnh cần xác định
                InputImage = new Bitmap(ofd.FileName);//Địa chỉ được gán vô hình input
                InputPicture.Image = InputImage;

                //Chuyển sang mức xám để dùng sobel
                Hinhxam1 = ChuyenHinhRGBSangHinhXamLuminance(InputImage);
                //crop image
                //Ban đầu tạo ra mảng 4 phần tử
                int[] arage = new int[4];
                //Lấy sobel hình đầu vào
                SobelImage = Sobel(Hinhxam1, 160);
                //Hàm segmen trả về 4 vị trí để mình cắt hình
                arage = Segmentation(SobelImage, 1.2);//Xác định viền 
                //
                double chieurong = arage[1] - arage[0];
                double chieudai = arage[3] - arage[2];
                //Cắt khung thẻ sinh viên
                Crop filter = new Crop(new Rectangle((int)arage[0], (int)arage[2], (int)chieurong, (int)chieudai));//2 tham số đầu là vị trí góc trái hình vuông
                Bitmap newImage = filter.Apply(InputImage);
                HinhCrop = newImage;
            }
            ofd.Dispose();
        }
        private void RotateBT_Click(object sender, EventArgs e)
        {
            //Xoay hình
            //Xoay hình gốc
            InputImage = (Bitmap)RotateImage(InputImage);
            //Hiển thị lại
            InputPicture.Image = InputImage;
            //Xoay hinh crop
            HinhCrop = (Bitmap)RotateImage(HinhCrop);
        }
        private void SobelBT_Click(object sender, EventArgs e)
        {
            //Hiển thị hình cắt khung của thẻ
            OutputPicture.Image = HinhCrop;
            //cắt mã số sinh viên theo tỷ lệ của thẻ
            Crop filter = new Crop(new Rectangle((int)(HinhCrop.Width *0.04), (int)(HinhCrop.Height * 0.82), (int)(HinhCrop.Width * 0.26), (int)(HinhCrop.Height * 0.1)));//2 tham số đầu là vị trí góc trái hình vuông
            Bitmap newImage = filter.Apply(HinhCrop);
            HinhCrop = newImage;
            //hiển thị hình sau khi cắt
            SegmenImage.Image = HinhCrop;
            //Thư viện nhận diện ký tự
            var img = HinhCrop;
            var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
            var page = ocr.Process(img);
            //Xử lý khoảng trống khi đưa ra kết quả
            string abc = page.GetText();
            abc = abc.Replace(" ", "");
            //Hiển thị kết quả
            txtResult.Text = abc;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Đóng form1
            this.Close();
        }
    }
}
