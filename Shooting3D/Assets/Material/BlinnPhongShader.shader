Shader "Custom/BlinnPhongShader"
{
    Properties
    {
        //_Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SpecColor("Specular Color", Color) = (1,1,1,1) //BlinnPhong 공식이 구현된 내부 코드안에서 받고 있는 예약어. 다른이름을 쓰거나, 코드 내부에서 받으면 안됨.
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
        
        //float4 _SpecColor; //***********에러 발생... 

        /*UNITY_INSTANCING_BUFFER_START(Props)
            
        UNITY_INSTANCING_BUFFER_END(Props)*/

        void surf (Input IN, inout SurfaceOutput/*SurfaceOutputStandard*/ o)
        {            
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;            
            o.Specular = 0.5; //Specular의 크기
            o.Gloss = 1; //Specular의 강도. 0이면 둔탁한 재질 1이면 매끄러운 재질
            /*o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;*/
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
