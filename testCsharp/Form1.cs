using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        unsafe public static extern int* sfxFaceDetect(IntPtr result_buffer, IntPtr rgb_image_data, int width, int height, int step);


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
        unsafe private void openPic()
        {


            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                String filename = this.openFileDialog1.FileName;
                var Image = new Image<Bgr, byte>(filename);

                Stopwatch watch = new Stopwatch();
                watch.Start();
                //MessageBox.Show(r.ToString());
                //申请非托管指针
                IntPtr result_buffer = Marshal.AllocHGlobal(sizeof(byte) * DETECT_BUFFER_SIZE);
                //byte[] result_buffer = new byte[DETECT_BUFFER_SIZE];


                Mat mat =Image.Mat;
                int* pResults = sfxFaceDetect(result_buffer, mat.DataPointer, mat.Cols, mat.Rows, mat.Step);
                for (int i = 0; i < *pResults; i++)
                {
                    short* p = ((short*)(pResults + 1)) + 142 * i;
                    int x = p[0];
                    int y = p[1];
                    int w = p[2];
                    int h = p[3];
                    int confidence = p[4];
                    int angle = p[5];

                    //printf("face_rect=[%d, %d, %d, %d], confidence=%d, angle=%d\n", x, y, w, h, confidence, angle);
                    //rectangle(result_cnn, Rect(x, y, w, h), Scalar(0, 255, 0), 2);
                    Rectangle face = new Rectangle(x, y, w, h);
                    CvInvoke.Rectangle(mat, face, new Bgr(Color.Red).MCvScalar, 2);
                }
                this.imageBox1.Image = mat.Clone();
                watch.Stop();
                System.Diagnostics.Trace.WriteLine("耗时:" + watch.ElapsedMilliseconds + "ms");
                //释放指针
                Marshal.FreeHGlobal(result_buffer);
            }
        }
        private void test()
        {
         
        }
    }
}
