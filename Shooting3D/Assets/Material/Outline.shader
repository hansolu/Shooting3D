Shader "Custom/Outline"
{
    Properties
    {
        _MainTex("Albedo (RGB)", 2D) = "white" {} //나의 기본 텍스쳐
        _OutLineColor("OutLine Color", Color) = (0,0,0,0) //아웃라인의 색
        _OutLineWidth("OutLine Width", float) = 1 //아웃라인의 두께
    }
        SubShader
        {
            Tags { "RenderType" = "Transparent" "Queue" = "Transparent"}
            LOD 200

            //여기서부터

            cull front 
            zwrite off
            CGPROGRAM
            #pragma surface surf NoLight vertex:vert noshadow noambient
            #pragma target 3.0

            float4 _OutLineColor;
            float _OutLineWidth;

            void vert(inout appdata_full v) {
                v.vertex.xyz += v.normal.xyz * _OutLineWidth;
            }
            struct Input
            {
                float4 color;
            };
            void surf(Input IN, inout SurfaceOutput o)
            {
            }
            float4 LightingNoLight(SurfaceOutput s, float3 lightDir, float atten) 
            {
                return float4(_OutLineColor.rgb, 1);
            }
            ENDCG  //여기까지가 첫번째 그려냄.

                //여기서부터 기본 그려냄
            cull back
            zwrite on
            CGPROGRAM  //여기서부터는 기본과 동일. 
            #pragma surface surf Lambert
            #pragma target 3.0

            sampler2D _MainTex;
            struct Input
            {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                fixed4 c = tex2D(_MainTex, IN.uv_MainTex); //기본텍스쳐 반영해서 그림.
                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }
            ENDCG //기본 그려냄 끝
        }
            FallBack "Diffuse"
}