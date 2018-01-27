Shader "Custom/ggj_baseShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Metallic ("Metallic / Gloss", 2D) = "white" {}
		_Wireframe ("Wireframe", 2D) = "black" {}
		_Scramble ("Scramble", 2D) = "white" {}
		_ToWhite ("Fade to White", Float) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert finalcolor:mycolor
		#pragma multi_compile_fog
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0


		sampler2D _MainTex;
		uniform half4 unity_FogStart;
		uniform half4 unity_FogEnd;

		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			half fog;
		};

		float _shdrWireframe;
		float _shdrScramble;
		float _ToWhite;
		sampler2D _Metallic;
		sampler2D _Scramble;
		sampler2D _Wireframe;
		fixed4 _Color;


		void vert (inout appdata_full v, out Input data) {
			fixed4 s = tex2Dlod (_Scramble, v.vertex);
			v.vertex.xyz += v.normal * _shdrScramble * s;

			UNITY_INITIALIZE_OUTPUT(Input,data);
    		float pos = length(UnityObjectToViewPos(v.vertex).xyz);
   			float diff = unity_FogEnd.x - unity_FogStart.x;
   			float invDiff = 1.0f / diff;
    		data.fog = saturate ((unity_FogEnd.x - pos) * invDiff);
			
		}

		void mycolor (Input IN, SurfaceOutputStandard o, inout fixed4 color){
			
			fixed wA = saturate(_shdrWireframe);
			fixed4 w = tex2D (_Wireframe, IN.uv_MainTex);
			color = lerp(color, w, wA);
			float tw = saturate(_ToWhite);
			color = max(color, _ToWhite);
			color.a = 1;
			color *= IN.fog;

   			
   		   	
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			//fixed4 w = tex2D (_Wireframe, IN.uv_MainTex);
			fixed4 m = tex2D (_Metallic, IN.uv_MainTex);

			o.Albedo = c.rgb;

			o.Metallic = m.r;
			o.Smoothness = m.a;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
