//==================================================
//  SimpleDepthFog.Shader
//  简单实现后处理深度雾效果，模拟线性效果
//==================================================
Shader "Custom/SimpleDepthFog"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FogColor("Fog Color", Color) = (1, 0, 0, 0)        // 雾色
        _FogStart("Fog Start", float) = 0                   // 雾的开始距离
        _FogEnd("Fog End", float) = 300                     // 雾的结束距离
    }

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv :TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;          // UV纹理
                float4 vertex : SV_POSITION;    // 顶点坐标
                float3 ray : TEXCOORD1;         // 摄像机朝向顶点的射线
            };
            
            float4x4 _Ray;      // 摄像机射线，通过C#传入

            v2f vert(appdata v, uint vid : SV_VertexID)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.ray = _Ray[vid];
                return o;
            }

            sampler2D _MainTex;
            float4 _MainTex_ST;

            sampler2D _CameraDepthTexture;  // 获取摄像机深度纹理

            float GetViewSpaceDist(float3 ray, float2 uv)
            {
                float dist = 0;
                // 从摄像机深度纹理中获取当前顶点的非线性深度值
                float depth = SAMPLE_DEPTH_TEXTURE(_CameraDepthTexture, uv);
                // 获取一个[0,1]范围的线性深度值
                float linear01Depth = Linear01Depth(depth);
                // 获取当前顶点在裁剪空间中与摄像机的距离
                //dist = length(_WorldSpaceCameraPos.xyz + ray.xyz * linear01Depth);
                dist = length(ray * linear01Depth);
                return dist;
            }

            float _FogStart;
            float _FogEnd;

            /// 获取线性雾的雾效因子
            float4 GetLinearFogFactor(float dist)
            {
                float factor = (_FogEnd - dist) / (_FogEnd - _FogStart);
                factor = saturate(factor);
                return factor;
            }

            float4 _FogColor;

            float4 frag(v2f i):SV_Target
            {
                float dist = GetViewSpaceDist(i.ray, i.uv);
                float factor = GetLinearFogFactor(dist);
                float4 c = tex2D(_MainTex, i.uv);
                c = lerp(_FogColor, c, factor);
                return c;
            }
            ENDCG
        }
    }
}
