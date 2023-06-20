Shader "Custom/Test2Shader" //림라이트
{
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _BumpMap("Bumpmap", 2D) = "bump" {}
        _RimColor("Rim Color", Color) = (0.26,0.19,0.16,0.0)
        _RimPower("Rim Power", Range(0.5,8.0)) = 3.0
    }
        SubShader{
          Tags { "RenderType" = "Opaque" }
          CGPROGRAM
          #pragma surface surf Lambert
          struct Input {
              float2 uv_MainTex;
              float2 uv_BumpMap;
              float3 viewDir; //이 바라보는 방향이라는 것은 카메라가 바라보는 벡터. 
          };
          sampler2D _MainTex;
          sampler2D _BumpMap;
          float4 _RimColor;
          float _RimPower;
          void surf(Input IN, inout SurfaceOutput o) {
              o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb;
              o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));

              //half rim = 1.0 - saturate(dot(normalize(IN.viewDir), o.Normal) * 0.5 + 0.5);  //하프 램버트 공식. 원래 값이 -1~1 사이인데 0~1 사이로 보간해줌

              half rim = 1.0 - saturate(   dot(normalize(IN.viewDir), o.Normal)  ); //빛 대신 카메라의 뷰벡터와 노멀벡터를 연산하게 되면 
              // 카메라의 벡터와 마주보는 노말 벡터일수록 각도차이가 적어지기 때문에 카메라가 바라보는 곳은 언제나 밝아지고 
              //카메라를 바라보지않는 곳은 반드시 어두워지게됨.
              o.Emission = _RimColor.rgb * pow(rim, _RimPower);
          }
          ENDCG
        }
    FallBack "Diffuse"
}
