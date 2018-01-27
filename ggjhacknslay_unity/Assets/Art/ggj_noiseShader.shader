Shader "Unlit/ggj_noiseShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_speed1 ("speed 1", Vector) = (0,0,0,0)
		_speed2 ("speed 2", Vector) = (0,0,0,0)
		_speed3 ("speed 3", Vector) = (0,0,0,0)
	}
	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="transparent" }
		LOD 100

		Pass
		{
			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha
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

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _speed1;
			float4 _speed2;
			float4 _speed3;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col1 = tex2D(_MainTex, i.uv + _Time.y * _speed1.xy).r;
				fixed4 col2 = tex2D(_MainTex, i.uv + _Time.y * _speed2.xy).g;
				fixed4 col3 = tex2D(_MainTex, i.uv + _Time.y * _speed3.xy).b;
				fixed4 cola = min(col1, min(col2, col3));
				fixed4 colb = max(col2, col3) + col1 * _speed1.z + _speed1.w;
				//fixed4 col = lerp(cola, colb, frac(_Time.w*2));
				fixed4 col = colb;
				col = saturate(col);
				col.a = _speed2.w;
				return col;
			}
			ENDCG
		}
	}
}
