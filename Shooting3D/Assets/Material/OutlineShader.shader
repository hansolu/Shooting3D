Shader "Custom/OutlineShader"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _MainTex("Main Texture", 2D) = "white"{}
        _OutLineColor("OutLineColor", Color) = (1,1,1,1)
        _OutLineWidth("OutLine Width", Float) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue" ="Transparent" "IgnoreProjector"="True"}
        
        //////////여기까지만
        
        
        LOD 200

        CGPROGRAM        
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };
                
        fixed4 _Color;
        fixed4 _OutLineColor;
        half _OutLineWidth;

        
        UNITY_INSTANCING_BUFFER_START(Props)        
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables            
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
