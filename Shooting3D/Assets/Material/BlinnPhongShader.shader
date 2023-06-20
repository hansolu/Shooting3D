Shader "Custom/BlinnPhongShader"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SpecColor("Specular Color", Color) = (1,1,1,1) //BlinnPhong ������ ������ ���� �ڵ�ȿ��� �ް� �ִ� �����. �ٸ��̸��� ���ų�, �ڵ� ���ο��� ������ �ȵ�.
        /*_Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0*/
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        
        #pragma surface surf BlinnPhong
                    
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        /*half _Glossiness;
        half _Metallic;
        fixed4 _Color;*/
        
        //float4 _SpecColor; //***********���� �߻�... 

        /*UNITY_INSTANCING_BUFFER_START(Props)
            
        UNITY_INSTANCING_BUFFER_END(Props)*/

        void surf (Input IN, inout SurfaceOutput/*SurfaceOutputStandard*/ o)
        {            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;            
            o.Specular = 0.5; //Specular�� ũ��
            o.Gloss = 1; //Specular�� ����. 0�̸� ��Ź�� ���� 1�̸� �Ų����� ����
            /*o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;*/
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
