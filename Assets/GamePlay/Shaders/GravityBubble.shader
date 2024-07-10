Shader "Custom/GravityBubbleTransparentShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1) // Default to opaque white
        _Transparency ("Transparency", Range(0, 1)) = 0.5 // Default transparency
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        LOD 200

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
            };

            fixed4 _Color;
            float _Transparency;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Adjust the color's alpha by the transparency value
                fixed4 col = _Color;
                col.a *= _Transparency;
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
