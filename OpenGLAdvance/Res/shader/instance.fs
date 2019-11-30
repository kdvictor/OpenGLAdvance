#version 430

in vec3 V_Normal;
in vec4 V_WorldPos;
in vec2 V_Texcoord;

uniform sampler2D U_MainTexture;


void main()
{
    vec3 lightPos=vec3(10.0, 10.0, 0.0); //平行光
    vec3 L = lightPos; //点到光源的向量，因为是平行光，所以所有点的向量一致
    L = normalize(L);
    vec3 n = normalize(V_Normal);

    //ambient
    vec4 AmbientLightColor = vec4(0.2,0.2,0.2,1.0);
    vec4 AmbientMaterial = vec4(0.2,0.2,0.2, 1.0); //只反射0.2 -- -- 
    vec4 ambientColor = AmbientLightColor*AmbientMaterial;

    //diffuse
    vec4 DiffuseLightColor = vec4(1.0,1.0,1.0,1.0);
    vec4 DiffuseMaterial = vec4(1.0, 1.0, 1.0, 1.0);
    vec4 diffuseColor = DiffuseLightColor*DiffuseMaterial*max(0.0, dot(L,n)); //max(0.0, dot(L,n):影响光照强度


    gl_FragColor = ambientColor + texture2D(U_MainTexture, V_Texcoord)*(diffuseColor); //纹理的光照不要乱乘，选择性取舍
}