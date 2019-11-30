#pragma once
#include "glew.h"

/***********OpenGL***************/
GLuint CreateBufferObject(GLenum bufferType, GLsizeiptr size, GLenum usage, void* data = nullptr);

GLuint CreateGPUProgram(const char* vsShaderPath, const char* fsShaderPath);

GLuint CompileShader(GLenum shaderType, const char* const& shaderPath);

GLuint CreateTextureFromFile(const char* const& imagePath);

void CheckGLError(const char* const& file, const int& line);





/***********File***************/
char* LoadFileContent(const char* path);

unsigned char* DecodeBMP(const char* const& fileContent, int& width, int& height);

unsigned char* DecodeDXTData(const char* const& fileContent, int& width, int& height, int& pixelDataSize);

void SavePixelDataToBMP(const char* const& filePath, unsigned char* const& pixelData, const int& width, const int& height);




//macros
#define GL_CALL(x)\
do \
{\
	x;\
	CheckGLError(__FILE__, __LINE__);\
} while (0)