Shader "Custom/GravityBubbleTransparentShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1) // Default to opaque white
        _Transparency ("Transparency", Range(0, 1)) = 0.5 // Default transparency
        _Distortion ("Distortion", Range(0, 1)) = 0.5 // Default distortion
        _NoiseTex ("Noise Texture", 2D) = "white" {} // Default to white texture
        _InnerRadius ("Inner Radius", Range(0, 1)) = 0.3 // Default inner radius
        _OuterRadius ("Outer Radius", Range(0, 1)) = 0.6 // Default outer radius
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

        GrabPass { "_GrabTexture" }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 screenPos: TEXCOORD1;
            };

            sampler2D _GrabTexture;
            sampler2D _NoiseTex;
            float4 _GrabTexture_TexelSize;
            float4 _Color;
            float _InnerRadius;
            float _OuterRadius;
            float _Transparency;
            float _Distortion;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.screenPos = ComputeScreenPos(o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 screenUV = i.screenPos.xy / i.screenPos.w; // Normalize
                // screenUV = screenUV * 0.5 + 0.5; // Transform to [0,1] range
                
                
                float2 center = float2(0.5, 0.5);
                float2 uv = i.uv;

                float blend = smoothstep(_InnerRadius, _OuterRadius, distance(uv, center));

                float noise = tex2D(_NoiseTex, uv).r;

                float2 displacement = normalize(uv - center) * _Distortion * noise * blend;
                
                fixed4 col = tex2D(_GrabTexture, screenUV - displacement);
                
                col.a *= _Transparency; // Adjust the color's alpha by the transparency value
                return col * _Color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
