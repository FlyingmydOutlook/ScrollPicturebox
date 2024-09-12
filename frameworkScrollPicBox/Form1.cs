using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frameworkScrollPicBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.scrollPicturebox1.SetLabelLongPressHandler(this.scrollPicturebox1.label1,Add_num);
            this.scrollPicturebox1.SetLabelLongPressHandler(this.scrollPicturebox1.label2,Add_num);
            this.scrollPicturebox1.SetLabelClickHandler(this.scrollPicturebox1.label1, ClickTest);
            this.scrollPicturebox1.SetLabelClickHandler(this.scrollPicturebox1.label2, ClickTest);
            this.scrollPicturebox1.SetLabelClickHandler(this.scrollPicturebox1.label3, ClickTest);
        }

        int num = 0;
        Size panel2OriginalSize = new System.Drawing.Size(1153, 533);

        private List<string> button1ImagePaths = new List<string>
        {
            @"C:\Users\Flying\Desktop\number-1-circle-icon-2048x2048-gcq2ulld.png",
            @"C:\Users\Flying\Desktop\number-2-circle-icon-2048x2048-72567p6x.png"
        };

        private List<string> button2ImagePaths = new List<string>
        {
            @"C:\Users\Flying\Desktop\resTest\1920x1080bmp.bmp",
            @"C:\Users\Flying\Desktop\resTest\1920x1080bmp1.bmp"
        };
        private List<string> button3ImagePaths = new List<string>
        {
            @"C:\Users\Flying\Desktop\resTest\512x512Black(1).bmp",
            @"C:\Users\Flying\Desktop\resTest\512x512Black.bmp"
        };
        private List<string> button4ImagePaths = new List<string>
        {
            @"C:\Users\Flying\Desktop\resTest\3723x2009bmp(1).bmp",
            @"C:\Users\Flying\Desktop\resTest\3723x2009bmp.bmp"
        };

        private int currentImageIndex = 0;
        private System.Threading.Timer imageSwitchTimer;
        private List<string> currentImagePaths;

        

        private void Add_num(object sender,EventArgs eventArgs)
        {
            
            Debug.WriteLine("long press");
        }

        private void ClickTest(object sender,EventArgs eventArgs)
        {

            Debug.WriteLine("Click");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.scrollPicturebox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartImageSwitching(button1ImagePaths);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartImageSwitching(button2ImagePaths);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StartImageSwitching(button3ImagePaths);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            StartImageSwitching(button4ImagePaths);
        }

        private void StartImageSwitching(List<string> imagePaths)
        {
            currentImagePaths = imagePaths;
            currentImageIndex = 0;

            if (imageSwitchTimer != null)
            {
                imageSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);
                imageSwitchTimer.Dispose();
            }

            imageSwitchTimer = new System.Threading.Timer(SwitchImage, null, 0, 500);
        }

        private void SwitchImage(object state)
        {
            // 切换到下一张图片
            currentImageIndex = (currentImageIndex + 1) % currentImagePaths.Count;

            // 加载图片
            Bitmap bitmap = Image.FromFile(currentImagePaths[currentImageIndex]) as Bitmap;
            scrollPicturebox1.LoadImage(bitmap);
            AdjustScrollPictureboxSize(bitmap);
        }

        private void AdjustScrollPictureboxSize(Bitmap bitmap)
        {
            //避免跨线程调用
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<Bitmap>(AdjustScrollPictureboxSize), bitmap);
                return;
            }

            // 固定 panel2 的尺寸
            this.panel2.Size = panel2OriginalSize;

            if (bitmap.Width > panel2.Size.Width || bitmap.Height > panel2.Size.Height)
            {
                this.scrollPicturebox1.Visible = true;
                this.scrollPicturebox1.Size = new Size(panel2.Size.Width, panel2.Size.Height);
            }
            else
            {
                this.scrollPicturebox1.Visible = true;
                this.scrollPicturebox1.Size = new Size(bitmap.Width, bitmap.Height);
            }

            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
