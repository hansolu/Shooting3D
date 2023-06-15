Shader "Custom/DissolveShader"
{
    Properties
    {        
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _NoiseTex("Noise", 2D) = "white"{}
        _Cut("Alpha Cut", Range(0,1)) = 0
        [HDR]_OutColor ("OutColor", Color) = (1,1,1,1)
        _OutThinkness ("OutThinkness", Range(1,1.5)) = 1.15
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
        LOD 200
            
            zwrite on
            ColorMask 0

        CGPROGRAM        
        #pragma surface surf nolight noambient noforwardadd nolightmap novertextlights noshadow
        
        #pragma target 3.0
            
            struct Input
        {
            float4 color:COLOR;
        };

        void surf(Input IN, inout SurfaceOutput o)
        {
        }

        float4 Lightingnolight(SurfaceOutput s, float3 lightDir, float atten)
        {
            return float4(0,0,0,0);
        }
        ENDCG

            zwrite off

            CGPROGRAM
#pragma surface surf Lambert alpha:fade

        sampler2D _MainTex;
        sampler2D _NoiseTex;
        float _Cut;
        float4 _OutColor;
        float _OutThinkness;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NoiseTex;
        };        

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            fixed4 noise = tex2D(_NoiseTex, IN.uv_NoiseTex);
            o.Albedo = c.rgb;
                        
            float alpha = 0;
            if (noise.r >= _Cut)
            {
                alpha = 1;
            }

            float outline = 1;
            if (noise.r >= _Cut * _OutThinkness)
            {
                outline = 0;
            }
            o.Emission = outline * _OutColor.rgb;
            o.Alpha = alpha;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
