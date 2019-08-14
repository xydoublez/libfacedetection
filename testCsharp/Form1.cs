using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace testCsharp
{
    public partial class Form1 : Form
    {
        [DllImport(@"F:\github\libfacedetection\sln\Debug\SfxFaceDetect.dll", CallingConvention = CallingConvention.Cdecl,SetLastError = true)]
        public static extern int add(int a, int b);
        [DllImport(@"F:\github\libfacedetection\sln\Debug\SfxFaceDetect.dll", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        public static extern IntPtr sfxFaceDetect(IntPtr result_buffer, IntPtr rgb_image_data, int width, int height, int step);


        const int DETECT_BUFFER_SIZE = 0x20000;
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            openPic();
            //test();
        }
        private void openPic()
        {


            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.imageBox1.Load(this.openFileDialog1.FileName);

                //MessageBox.Show(r.ToString());
                //申请非托管指针
                IntPtr result_buffer = Marshal.AllocHGlobal(sizeof(byte) * DETECT_BUFFER_SIZE);

                var rgb_image_data = this.imageBox1.Image.Ptr;
                Mat mat =(Mat)this.imageBox1.Image;
 

                IntPtr result = sfxFaceDetect(result_buffer, rgb_image_data, mat.Cols, mat.Rows, mat.Step);

                //释放指针
                Marshal.FreeHGlobal(result_buffer);
            }
        }
        private void test()
        {
         
        }
    }
}
