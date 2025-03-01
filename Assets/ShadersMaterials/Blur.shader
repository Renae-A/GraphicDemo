﻿Shader "PostProcessing/Blur"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_DeltaX("Delta X", Float) = 0.01
		_DeltaY("Delta Y", Float) = 0.01
	}
		SubShader
		{
			// No culling or depth
			Cull Off ZWrite Off ZTest Always

			Pass
			{
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

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				float _DeltaX;
				float _DeltaY;
				sampler2D _CameraDepthTexture;

				float sobel(sampler2D tex, float2 uv)
				{
					float2 delta = float2(_DeltaX, _DeltaY);

					float4 horiz = float4(0, 0, 0, 0);
					float4 vert = float4(0, 0, 0, 0);

					horiz += tex2D(tex, (uv + float2(-1, -1) * delta)) * 1.0;
					horiz += tex2D(tex, (uv + float2(-1, 0) * delta)) * 2.0;
					horiz += tex2D(tex, (uv + float2(-1, 1) * delta)) * 1.0;
					horiz += tex2D(tex, (uv + float2(1, -1) * delta)) * -1.0;
					horiz += tex2D(tex, (uv + float2(1, 0) * delta)) * -2.0;
					horiz += tex2D(tex, (uv + float2(1, 1) * delta)) * -1.0;


					vert += tex2D(tex, (uv + float2(-1, -1) * delta)) * 1.0;
					vert += tex2D(tex, (uv + float2(0, -1) * delta)) * 2.0;
					vert += tex2D(tex, (uv + float2(1, -1) * delta)) * 1.0;
					vert += tex2D(tex, (uv + float2(-1, 1) * delta)) * -1.0;
					vert += tex2D(tex, (uv + float2(0, 1) * delta)) * -2.0;
					vert += tex2D(tex, (uv + float2(1, 1) * delta)) * -1.0;

					return saturate(10 * sqrt(horiz * horiz + vert * vert));
				}

				fixed4 boxBlur(sampler2D tex, float2 uv, int radius)
				{
					float2 delta = float2(1.0 / _ScreenParams.x, 1.0 / _ScreenParams.y);

					float4 col = float4(0, 0, 0, 0);

					float count = 0;

					for (int i = -radius; i < radius; i++)
					{
						for (int j = -radius; j < radius; j++)
						{
							col += tex2D(tex, (uv + float2(i, j) * delta));
							count += 1;
						}
					}

					col = col / count;
					return float4(col.r, col.g, col.b, 1);
				}

				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 col = boxBlur(_MainTex, i.uv, 4);
					//// just invert the colors
					//col.rgb = 1 - col.rgb;


					float sb = sobel(_CameraDepthTexture, i.uv);
					//fixed4 col = fixed4(sb, sb, sb, 1);

					return col * (1 - sb);
				}
				ENDCG
			}
		}
}