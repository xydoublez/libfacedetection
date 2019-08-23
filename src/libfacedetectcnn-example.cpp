
#include<opencv2/opencv.hpp> 


using namespace cv;
using namespace std;
//-----------------------------------��main()������--------------------------------------------
//                ����������̨Ӧ�ó������ں��������ǵĳ�������￪ʼ
//-------------------------------------------------------------------------------------------------
//stringname = "�ҵ�����ͷ";
int main()
{
	//��1��������ͷ������Ƶ
	VideoCapture capture(0);
	//����������ͷ��û�д򿪣�/*if(!capture.isOpened())                {cout<< "cannot open the camera.";cin.get();return -1;}*

	Mat edges; //����һ��Mat���������ڴ洢ÿһ֡��ͼ��
	//��2��ѭ����ʾÿһ֡
	while (1)
	{
		Mat frame; //����һ��Mat���������ڴ洢ÿһ֡��ͼ��
		capture >> frame;  //��ȡ��ǰ֡                        
		if (frame.empty())
		{
			printf("--(!) No captured frame -- Break!");
			//break;                
		}
		else
		{
			cvtColor(frame, edges, CV_BGR2GRAY);//��ɫת���ɻҶ�
			blur(edges, edges, Size(7, 7));//ģ����
			Canny(edges, edges, 0, 30, 3);//��Ե��
			imshow("��ȡ����Ե�����Ƶ", frame); //��ʾ��ǰ֡

		}

		waitKey(30); //��ʱ30ms
	}
	return 0;
}

