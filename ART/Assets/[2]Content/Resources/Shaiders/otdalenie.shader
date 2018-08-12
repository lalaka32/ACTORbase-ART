﻿// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/NewSurfaceShader" {
	Properties {
		_MainTex ("Image (RGB)", 2D) = "white" {}
		_EffectIntensity("Effect power", float) = 0.001
	}
		SubShader{
		 Tags { "RenderType" = "Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert vertex:vert addshadow

		uniform float _EffectIntensity;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v)
		{
			float4 vv = mul(unity_ObjectToWorld,v.vertex);
			vv.xyz -= _WorldSpaceCameraPos.xyz;

			vv = float4(0.0f, (vv.z*vv.z)* -_EffectIntensity, 0.0f, 0.0f);

			v.vertex += mul(unity_WorldToObject, vv);
		}

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
