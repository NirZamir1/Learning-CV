using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CV_
{
    public partial class Form1 : Form
    {
        Bitmap ToGray;
        Bitmap VerticalEdge;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToGray = new Bitmap(@"C:\Users\PC\Downloads\20201229_151533.jpg");
            VerticalEdge = new Bitmap(@"C:\Users\PC\Downloads\20201229_151533.jpg");
            pictureBox1.Image = ToGrayScale(ToGray);
            pictureBox2.Image = Verticaledge(ToGrayScale(VerticalEdge));
        }
        static Bitmap ToGrayScale(Bitmap bitmap)
        {
            int avg;
            Color color;
            int[] RGB = new int[3];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for(int y = 0; y<bitmap.Height; y++ )
                {
                    color = bitmap.GetPixel(x,y);
                    RGB[0] = color.R;
                    RGB[1] = color.G;
                    RGB[2] = color.B;
                    avg = Sum(RGB);
                    bitmap.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
                
            }
            return bitmap;
        }
        static Bitmap Verticaledge(Bitmap bitmap /* must be grayScale */)
        {
            int convolution = 0;
            int sumLeft = 0;
            int sumRight = 0;
            Bitmap _bitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for(int x = 1; x < bitmap.Width - 1; x ++)
            {
                for(int y = 1; y < bitmap.Height-1; y++ )
                {
                    sumLeft = 0;
                    sumRight = 0;
                    for(int i = -1; y-i<bitmap.Height && i<=1; i++)
                    {
                        sumLeft += bitmap.GetPixel(x - 1, y+i).R;
                    }
                    for (int i = -1; y - i < bitmap.Height && i<=1; i++)
                    {
                        sumRight += bitmap.GetPixel(x + 1, y+i).R;
                    }
                    convolution =Math.Abs(sumRight-sumLeft);
                    if(convolution>255)
                    {
                        convolution = 255;
                    }
                    _bitmap.SetPixel(x, y, Color.FromArgb(convolution, convolution, convolution));
                }
            }
            return _bitmap;
        }
        static int Sum(int[] Array)
        {
            int Container=0;
            for(int i = 0; i <Array.Length;i++)
            {
                Container += Array[i];
            }
            return Container / Array.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
    
}
