
#include<opencv2/opencv.hpp> 


using namespace cv;
using namespace std;
//-----------------------------------【main()函数】--------------------------------------------
//                描述：控制台应用程序的入口函数，我们的程序从这里开始
//-------------------------------------------------------------------------------------------------
//stringname = "我的摄像头";
int main()
{
	//【1】从摄像头读入视频
	VideoCapture capture(0);
	//若测试摄像头有没有打开，/*if(!capture.isOpened())                {cout<< "cannot open the camera.";cin.get();return -1;}*

	Mat edges; //定义一个Mat变量，用于存储每一帧的图像
	//【2】循环显示每一帧
	while (1)
	{
		Mat frame; //定义一个Mat变量，用于存储每一帧的图像
		capture >> frame;  //读取当前帧                        
		if (frame.empty())
		{
			printf("--(!) No captured frame -- Break!");
			//break;                
		}
		else
		{
			cvtColor(frame, edges, CV_BGR2GRAY);//彩色转换成灰度
			blur(edges, edges, Size(7, 7));//模糊化
			Canny(edges, edges, 0, 30, 3);//边缘化
			imshow("读取被边缘后的视频", frame); //显示当前帧

		}

		waitKey(30); //延时30ms
	}
	return 0;
}

