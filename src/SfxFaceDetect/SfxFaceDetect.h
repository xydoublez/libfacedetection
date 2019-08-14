#pragma once
extern "C" _declspec(dllexport) int add(int a, int b);
extern "C" _declspec(dllexport) int * sfxFaceDetect(unsigned char * result_buffer, unsigned char * rgb_image_data, int width, int height, int step);