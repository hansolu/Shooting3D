Shader "Custom/TestShader"
{
    Properties 
    {
        _Color ("Color", Color) = (1,1,1,1) //(0,1,0,1)
        /*_Bright("Bright", Range(-1,1)) =0
        _GlowR ("RedLight", Range(-1,1)) = 0
        _GlowG("GreenLight", Range(-1,1)) = 0
        _GlowB("BlueLight", Range(-1,1)) = 0*/
        
        _MainTex ("MainTex", 2D) = "white" {}
        _MainTex2("MainTex2", 2D) = "white" {}

        _BlendVal("Blend Value",Range(0,1)) = 0

            _X("HorizonCount", float) = 1
            _Y("VerticalCount", float) = 1
       /* _Glossiness ("Glossiness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0*/
    }
    SubShader
    {
            //Tags { "RenderType" = "Opaque" }
        Tags { "RenderType"="Transparent" "Queue"= "Transparent"}
        
        CGPROGRAM
        
        #pragma surface surf Standard alpha:fade //alpha:blend //fullforwardshadows

        sampler2D _MainTex;
        sampler2D _MainTex2;

        struct Input
        {
            float2 uv_MainTex; //MainTex1용 UV
            float2 uv_MainTex2;//MainTex2용 UV
        };

        float _BlendVal;
      /*  half _Bright;
    half _GlowR;
    half _GlowG;
    half _GlowB;*/

        float _X;
        float _Y;
        //half _Glossiness;
        //half _Metallic;
        //float / half / fixed // R8G8B8

        fixed4 _Color;                

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //fixed4 c1 = tex2D (_MainTex, float2( IN.uv_MainTex.x * _X, IN.uv_MainTex.y _Y)) /** _Color*/; //타일링. UV에다가 곱하기 혹은 나누기는 타일링
            
            fixed4 c2 = tex2D(_MainTex2, float2(IN.uv_MainTex2.x, IN.uv_MainTex2.y - _Time.y)) /** _Color*/; //노이즈 //UV에다가 더하기 혹은 빼기는 오프셋 수정
            //fixed4 c1 = tex2D(_MainTex, IN.uv_MainTex +c2.r*0.2 /* + 0.5*/); //불그림
            fixed4 c1 = tex2D(_MainTex, IN.uv_MainTex +c2.r/* + 0.5*/); //불그림
            
            //o.Albedo  //빛과 그림자의 영향을 받음.
            //o.Emission = c1.rgb * c2.rgb;
            o.Emission = lerp(c1, c2, 0 /*1-( c1.a * _BlendVal)*/); //c.rgb+ _Bright;//_Color.r; /*(0,1,0,1)*/ /*+ float3(1, 0, 0)*/;            
            //o.Emission = float3(_Color.b, _Color.g, _Color.r) ; //float3(_Color.b, _Color.g, _Color.r) == _Color.bgr //float3(_GlowR, _GlowG, _GlowB); //0~ 0.****** ~ 1   => 0 (0,0,0) // 1 (1,1,1)
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
            //o.Alpha = c1.a * c2.a;
                        
            o.Alpha = c1.a ;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
