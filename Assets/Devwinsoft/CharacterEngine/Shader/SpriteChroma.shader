Shader "devwin/SpriteChroma"
{
    Properties
    {
        _MainTex ("Base (RGB)", 2D) = "white" {}
        _Chroma("Chroma", Float) = 1
		_Color ("Tint", Color) = (1,1,1,1)
    }
    
    Category
    {
		Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

		Lighting Off
		ZWrite Off
		Cull Off
		Blend SrcAlpha OneMinusSrcAlpha
		
		SubShader
        {
            Pass
            {
				Alphatest Greater [_Cutoff]
				CGPROGRAM
					#pragma fragment frag
					#pragma vertex vert
					#pragma multi_compile DUMMY PIXELSNAP_ON
					//#pragma fragmentoption ARB_fog_exp2
					#include "UnityCG.cginc"

					uniform sampler2D _MainTex;
					uniform float _Chroma;
					uniform float4 _Color;

					struct appdata_t
					{
						float4 vertex   : POSITION;
						float4 color    : COLOR;
						float2 texcoord : TEXCOORD0;
					};
					struct v2f
					{
						float4 vertex : SV_POSITION;
						fixed4 color : COLOR;
						float2 texcoord : TEXCOORD0;
					};

					v2f vert (appdata_t v)
					{
						v2f o;
						o.vertex = mul (UNITY_MATRIX_MVP, v.vertex);
						o.texcoord = v.texcoord;
						o.color = v.color * _Color;
						
		                #ifdef PIXELSNAP_ON
							o.vertex = UnityPixelSnap (o.vertex);
						#endif
						return o;
					}

					half4 frag (v2f i) : COLOR
					{
						float4 color = i.color * tex2D(_MainTex, i.texcoord);
						float r = color.r * 255;
						float g = color.g * 255;
						float b = color.b * 255;
						float a = color.a;
						float y = (0.299*r) + (0.587*g) + (0.114*b);
						float u = -(0.147*r) - (0.289*g) + (0.436*b);
						float v = (0.615*r) - (0.515*g) - (0.1*b);
						u = u * _Chroma;
						v = v * _Chroma;
						r = y + 1.140 * v;
						g = y - 0.395 * u - 0.581 * v;
						b = y + 2.032 * u;
						return float4(r/255 * _Color.r, g/255 * _Color.g, b/255 * _Color.b, a * _Color.a);
					}
				ENDCG
			}

		} 
    }
    
    FallBack "Diffuse"

}
