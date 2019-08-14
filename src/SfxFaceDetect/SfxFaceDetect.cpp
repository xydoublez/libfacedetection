#include "SfxFaceDetect.h"
#include "facedetectcnn.h"
int add(int a, int b)
{
	return a + b;
}

int * sfxFaceDetect(unsigned char * result_buffer, unsigned char * rgb_image_data, int width, int height, int step)
{
	return facedetect_cnn(result_buffer,rgb_image_data, width, height, step);
}