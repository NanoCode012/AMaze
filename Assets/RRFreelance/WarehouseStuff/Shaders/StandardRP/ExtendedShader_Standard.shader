// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "RRF/Standard/ExtendedShader_Standard"
{
	Properties
	{
		_BaseTint("BaseTint", Color) = (1,1,1,0)
		_Albedo("Albedo", 2D) = "white" {}
		_HueShiftvColMasked("HueShift(vColMasked)", Range( 0 , 1)) = 1
		_ORM("ORM(Ao,Roughness,Metal)", 2D) = "white" {}
		[Toggle(_TOGGLEROUGHNESSTOGLOSS_ON)] _ToggleRoughnessToGloss("ToggleRoughnessToGloss", Float) = 1
		_GlossAdjust("GlossAdjust", Range( -1 , 1)) = 0
		_MetalnessAdjust("MetalnessAdjust", Range( -1 , 1)) = 0
		_AO_Power("AO_Power", Range( 0 , 3)) = 1
		_AO_IntoAlbedo("AO_IntoAlbedo", Range( 0 , 1)) = 0.25
		_Emissive("Emissive", Range( 0 , 1)) = 0
		_NormalMap("NormalMap", 2D) = "bump" {}
		_NormalMap_Power("NormalMap_Power", Range( 0 , 3)) = 1
		[Toggle(_FLIPGREEN_ON)] _FlipGreen("FlipGreen?", Float) = 0
		[Header (Custom Colouring)][Space (5)]_CustomColouringAmount("CustomColouringAmount", Range( 0 , 1)) = 0
		_PreAdd("PreAdd", Range( 0 , 1)) = 0.7811089
		_PreSelfMultiply("PreSelfMultiply", Range( 0 , 1)) = 0.1223966
		_UpColour("UpColour", Color) = (0.9339623,0.8798372,0.7665539,0)
		_HighColour("HighColour", Color) = (1,1,1,1)
		_LowColour("LowColour", Color) = (0,0,0,1)
		_UpColourNoiseScale("UpColourNoiseScale", Range( 0 , 1)) = 0.5
		_UpColourNoisePower("UpColourNoisePower", Range( 0 , 1)) = 0.4681104
		_UpColourRange("UpColourRange", Range( -1 , 1)) = 0.11
		_UpColourAmount("UpColourAmount", Range( 0 , 1)) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGINCLUDE
		#include "UnityPBSLighting.cginc"
		#include "Lighting.cginc"
		#pragma target 3.0
		#pragma shader_feature _FLIPGREEN_ON
		#pragma shader_feature _TOGGLEROUGHNESSTOGLOSS_ON
		#ifdef UNITY_PASS_SHADOWCASTER
			#undef INTERNAL_DATA
			#undef WorldReflectionVector
			#undef WorldNormalVector
			#define INTERNAL_DATA half3 internalSurfaceTtoW0; half3 internalSurfaceTtoW1; half3 internalSurfaceTtoW2;
			#define WorldReflectionVector(data,normal) reflect (data.worldRefl, half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal)))
			#define WorldNormalVector(data,normal) half3(dot(data.internalSurfaceTtoW0,normal), dot(data.internalSurfaceTtoW1,normal), dot(data.internalSurfaceTtoW2,normal))
		#endif
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
			float3 worldNormal;
			INTERNAL_DATA
		};

		uniform sampler2D _NormalMap;
		uniform float4 _NormalMap_ST;
		uniform float _NormalMap_Power;
		uniform float4 _BaseTint;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float _HueShiftvColMasked;
		uniform sampler2D _ORM;
		uniform float4 _ORM_ST;
		uniform float _AO_Power;
		uniform float _AO_IntoAlbedo;
		uniform float4 _LowColour;
		uniform float4 _HighColour;
		uniform float _PreAdd;
		uniform float _PreSelfMultiply;
		uniform float _CustomColouringAmount;
		uniform float4 _UpColour;
		uniform float _UpColourRange;
		uniform float _UpColourNoiseScale;
		uniform float _UpColourNoisePower;
		uniform float _UpColourAmount;
		uniform float _Emissive;
		uniform float _MetalnessAdjust;
		uniform float _GlossAdjust;


		float3 HSVToRGB( float3 c )
		{
			float4 K = float4( 1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0 );
			float3 p = abs( frac( c.xxx + K.xyz ) * 6.0 - K.www );
			return c.z * lerp( K.xxx, saturate( p - K.xxx ), c.y );
		}


		float3 RGBToHSV(float3 c)
		{
			float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
			float4 p = lerp( float4( c.bg, K.wz ), float4( c.gb, K.xy ), step( c.b, c.g ) );
			float4 q = lerp( float4( p.xyw, c.r ), float4( c.r, p.yzx ), step( p.x, c.r ) );
			float d = q.x - min( q.w, q.y );
			float e = 1.0e-10;
			return float3( abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
		}

		float3 mod3D289( float3 x ) { return x - floor( x / 289.0 ) * 289.0; }

		float4 mod3D289( float4 x ) { return x - floor( x / 289.0 ) * 289.0; }

		float4 permute( float4 x ) { return mod3D289( ( x * 34.0 + 1.0 ) * x ); }

		float4 taylorInvSqrt( float4 r ) { return 1.79284291400159 - r * 0.85373472095314; }

		float snoise( float3 v )
		{
			const float2 C = float2( 1.0 / 6.0, 1.0 / 3.0 );
			float3 i = floor( v + dot( v, C.yyy ) );
			float3 x0 = v - i + dot( i, C.xxx );
			float3 g = step( x0.yzx, x0.xyz );
			float3 l = 1.0 - g;
			float3 i1 = min( g.xyz, l.zxy );
			float3 i2 = max( g.xyz, l.zxy );
			float3 x1 = x0 - i1 + C.xxx;
			float3 x2 = x0 - i2 + C.yyy;
			float3 x3 = x0 - 0.5;
			i = mod3D289( i);
			float4 p = permute( permute( permute( i.z + float4( 0.0, i1.z, i2.z, 1.0 ) ) + i.y + float4( 0.0, i1.y, i2.y, 1.0 ) ) + i.x + float4( 0.0, i1.x, i2.x, 1.0 ) );
			float4 j = p - 49.0 * floor( p / 49.0 );  // mod(p,7*7)
			float4 x_ = floor( j / 7.0 );
			float4 y_ = floor( j - 7.0 * x_ );  // mod(j,N)
			float4 x = ( x_ * 2.0 + 0.5 ) / 7.0 - 1.0;
			float4 y = ( y_ * 2.0 + 0.5 ) / 7.0 - 1.0;
			float4 h = 1.0 - abs( x ) - abs( y );
			float4 b0 = float4( x.xy, y.xy );
			float4 b1 = float4( x.zw, y.zw );
			float4 s0 = floor( b0 ) * 2.0 + 1.0;
			float4 s1 = floor( b1 ) * 2.0 + 1.0;
			float4 sh = -step( h, 0.0 );
			float4 a0 = b0.xzyw + s0.xzyw * sh.xxyy;
			float4 a1 = b1.xzyw + s1.xzyw * sh.zzww;
			float3 g0 = float3( a0.xy, h.x );
			float3 g1 = float3( a0.zw, h.y );
			float3 g2 = float3( a1.xy, h.z );
			float3 g3 = float3( a1.zw, h.w );
			float4 norm = taylorInvSqrt( float4( dot( g0, g0 ), dot( g1, g1 ), dot( g2, g2 ), dot( g3, g3 ) ) );
			g0 *= norm.x;
			g1 *= norm.y;
			g2 *= norm.z;
			g3 *= norm.w;
			float4 m = max( 0.6 - float4( dot( x0, x0 ), dot( x1, x1 ), dot( x2, x2 ), dot( x3, x3 ) ), 0.0 );
			m = m* m;
			m = m* m;
			float4 px = float4( dot( x0, g0 ), dot( x1, g1 ), dot( x2, g2 ), dot( x3, g3 ) );
			return 42.0 * dot( m, px);
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_NormalMap = i.uv_texcoord * _NormalMap_ST.xy + _NormalMap_ST.zw;
			float3 tex2DNode33 = UnpackNormal( tex2D( _NormalMap, uv_NormalMap ) );
			float3 break101 = tex2DNode33;
			#ifdef _FLIPGREEN_ON
				float staticSwitch102 = ( 1.0 - tex2DNode33.g );
			#else
				float staticSwitch102 = 0.0;
			#endif
			float4 appendResult103 = (float4(break101.x , staticSwitch102 , break101.z , 0.0));
			float4 lerpResult34 = lerp( float4( 0,0,1,0 ) , appendResult103 , _NormalMap_Power);
			float4 out_normal37 = lerpResult34;
			o.Normal = out_normal37.xyz;
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode1 = tex2D( _Albedo, uv_Albedo );
			float3 hsvTorgb117 = RGBToHSV( tex2DNode1.rgb );
			float3 hsvTorgb116 = HSVToRGB( float3(( hsvTorgb117.x + _HueShiftvColMasked ),hsvTorgb117.y,hsvTorgb117.z) );
			float4 lerpResult124 = lerp( tex2DNode1 , float4( hsvTorgb116 , 0.0 ) , i.vertexColor);
			float4 temp_output_105_0 = ( _BaseTint * lerpResult124 );
			float2 uv_ORM = i.uv_texcoord * _ORM_ST.xy + _ORM_ST.zw;
			float4 tex2DNode2 = tex2D( _ORM, uv_ORM );
			float3 temp_cast_3 = (tex2DNode2.r).xxx;
			float temp_output_2_0_g1 = _AO_Power;
			float temp_output_3_0_g1 = ( 1.0 - temp_output_2_0_g1 );
			float3 appendResult7_g1 = (float3(temp_output_3_0_g1 , temp_output_3_0_g1 , temp_output_3_0_g1));
			float3 out_ao11 = saturate( ( ( temp_cast_3 * temp_output_2_0_g1 ) + appendResult7_g1 ) );
			float4 lerpResult18 = lerp( temp_output_105_0 , ( float4( out_ao11 , 0.0 ) * temp_output_105_0 ) , _AO_IntoAlbedo);
			float4 out_albedo21 = lerpResult18;
			float saferPower70 = max( ( ( ( tex2DNode1.r + tex2DNode1.g + tex2DNode1.b ) / 3.0 ) + _PreAdd ) , 0.0001 );
			float4 lerpResult57 = lerp( _LowColour , _HighColour , saturate( pow( saferPower70 , ( _PreSelfMultiply * 100.0 ) ) ));
			float4 customColouring58 = lerpResult57;
			float4 lerpResult62 = lerp( out_albedo21 , customColouring58 , _CustomColouringAmount);
			float3 ase_worldNormal = WorldNormalVector( i, float3( 0, 0, 1 ) );
			float clampResult77 = clamp( ( ase_worldNormal.y + _UpColourRange ) , 0.0 , 1.0 );
			float temp_output_85_0 = ( _UpColourNoiseScale * 50.0 );
			float simplePerlin3D81 = snoise( float3( i.uv_texcoord ,  0.0 )*temp_output_85_0 );
			simplePerlin3D81 = simplePerlin3D81*0.5 + 0.5;
			float simplePerlin3D95 = snoise( float3( i.uv_texcoord ,  0.0 )*( temp_output_85_0 * 0.5 ) );
			simplePerlin3D95 = simplePerlin3D95*0.5 + 0.5;
			float blendOpSrc83 = ( simplePerlin3D81 * simplePerlin3D95 );
			float blendOpDest83 = clampResult77;
			float lerpResult86 = lerp( clampResult77 , ( saturate( (( blendOpSrc83 > 0.5 ) ? ( blendOpDest83 / max( ( 1.0 - blendOpSrc83 ) * 2.0 ,0.00001) ) : ( 1.0 - ( ( ( 1.0 - blendOpDest83 ) * 0.5 ) / max( blendOpSrc83,0.00001) ) ) ) )) , _UpColourNoisePower);
			float upMask93 = ( lerpResult86 * _UpColourAmount );
			float4 lerpResult80 = lerp( lerpResult62 , _UpColour , upMask93);
			o.Albedo = lerpResult80.rgb;
			o.Emission = ( lerpResult62 * _Emissive ).rgb;
			float out_metal10 = saturate( ( tex2DNode2.b + _MetalnessAdjust ) );
			o.Metallic = out_metal10;
			#ifdef _TOGGLEROUGHNESSTOGLOSS_ON
				float staticSwitch3 = ( 1.0 - tex2DNode2.g );
			#else
				float staticSwitch3 = tex2DNode2.g;
			#endif
			float out_gloss12 = saturate( ( staticSwitch3 + _GlossAdjust ) );
			o.Smoothness = out_gloss12;
			o.Occlusion = out_ao11.x;
			o.Alpha = 1;
		}

		ENDCG
		CGPROGRAM
		#pragma surface surf Standard keepalpha fullforwardshadows 

		ENDCG
		Pass
		{
			Name "ShadowCaster"
			Tags{ "LightMode" = "ShadowCaster" }
			ZWrite On
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#pragma multi_compile_shadowcaster
			#pragma multi_compile UNITY_PASS_SHADOWCASTER
			#pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
			#include "HLSLSupport.cginc"
			#if ( SHADER_API_D3D11 || SHADER_API_GLCORE || SHADER_API_GLES || SHADER_API_GLES3 || SHADER_API_METAL || SHADER_API_VULKAN )
				#define CAN_SKIP_VPOS
			#endif
			#include "UnityCG.cginc"
			#include "Lighting.cginc"
			#include "UnityPBSLighting.cginc"
			struct v2f
			{
				V2F_SHADOW_CASTER;
				float2 customPack1 : TEXCOORD1;
				float4 tSpace0 : TEXCOORD2;
				float4 tSpace1 : TEXCOORD3;
				float4 tSpace2 : TEXCOORD4;
				half4 color : COLOR0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};
			v2f vert( appdata_full v )
			{
				v2f o;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_INITIALIZE_OUTPUT( v2f, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				Input customInputData;
				float3 worldPos = mul( unity_ObjectToWorld, v.vertex ).xyz;
				half3 worldNormal = UnityObjectToWorldNormal( v.normal );
				half3 worldTangent = UnityObjectToWorldDir( v.tangent.xyz );
				half tangentSign = v.tangent.w * unity_WorldTransformParams.w;
				half3 worldBinormal = cross( worldNormal, worldTangent ) * tangentSign;
				o.tSpace0 = float4( worldTangent.x, worldBinormal.x, worldNormal.x, worldPos.x );
				o.tSpace1 = float4( worldTangent.y, worldBinormal.y, worldNormal.y, worldPos.y );
				o.tSpace2 = float4( worldTangent.z, worldBinormal.z, worldNormal.z, worldPos.z );
				o.customPack1.xy = customInputData.uv_texcoord;
				o.customPack1.xy = v.texcoord;
				TRANSFER_SHADOW_CASTER_NORMALOFFSET( o )
				o.color = v.color;
				return o;
			}
			half4 frag( v2f IN
			#if !defined( CAN_SKIP_VPOS )
			, UNITY_VPOS_TYPE vpos : VPOS
			#endif
			) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				Input surfIN;
				UNITY_INITIALIZE_OUTPUT( Input, surfIN );
				surfIN.uv_texcoord = IN.customPack1.xy;
				float3 worldPos = float3( IN.tSpace0.w, IN.tSpace1.w, IN.tSpace2.w );
				half3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				surfIN.worldNormal = float3( IN.tSpace0.z, IN.tSpace1.z, IN.tSpace2.z );
				surfIN.internalSurfaceTtoW0 = IN.tSpace0.xyz;
				surfIN.internalSurfaceTtoW1 = IN.tSpace1.xyz;
				surfIN.internalSurfaceTtoW2 = IN.tSpace2.xyz;
				surfIN.vertexColor = IN.color;
				SurfaceOutputStandard o;
				UNITY_INITIALIZE_OUTPUT( SurfaceOutputStandard, o )
				surf( surfIN, o );
				#if defined( CAN_SKIP_VPOS )
				float2 vpos = IN.pos;
				#endif
				SHADOW_CASTER_FRAGMENT( IN )
			}
			ENDCG
		}
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=18800
375.3333;800.6667;1195;647;3202.333;987.7862;1.621927;True;False
Node;AmplifyShaderEditor.CommentaryNode;32;-2826.037,-894.3008;Inherit;False;2036.983;412.1455;Albedo;9;21;18;20;19;17;1;116;104;119;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;31;-1763.908,-494.3143;Inherit;False;1303.667;490;AO Roughness metalness;15;6;2;7;4;11;8;14;3;13;9;16;15;12;10;107;;1,1,1,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;92;-1679.434,-2043.192;Inherit;False;1797.643;615.8351;Noise on the Up;15;84;85;82;75;77;81;89;83;87;86;88;95;96;97;98;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;1;-2789.638,-685.3842;Inherit;True;Property;_Albedo;Albedo;1;0;Create;True;0;0;0;False;0;False;-1;feb518fa33e305b428f01d5d4e5480dd;feb518fa33e305b428f01d5d4e5480dd;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.CommentaryNode;106;-1845.862,-1378.246;Inherit;False;1574.727;481.307;New Colouring;11;41;42;69;71;68;72;70;63;55;56;57;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SamplerNode;2;-1713.908,-444.3143;Inherit;True;Property;_ORM;ORM(Ao,Roughness,Metal);3;0;Create;False;0;0;0;False;0;False;-1;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;84;-1650.692,-1867.183;Inherit;False;Property;_UpColourNoiseScale;UpColourNoiseScale;19;0;Create;True;0;0;0;False;0;False;0.5;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;6;-1697.199,-221.6921;Inherit;False;Property;_AO_Power;AO_Power;7;0;Create;True;0;0;0;False;0;False;1;0;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;119;-2451.597,-581.6277;Inherit;False;Property;_HueShiftvColMasked;HueShift(vColMasked);2;0;Create;True;0;0;0;False;0;False;1;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RGBToHSVNode;117;-2463.919,-798.3715;Inherit;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.FunctionNode;107;-1397.271,-241.5978;Inherit;False;Lerp White To;-1;;1;047d7c189c36a62438973bad9d37b1c2;0;2;1;FLOAT3;0,0,0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleAddOpNode;118;-2112.218,-907.772;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;41;-1795.862,-1088.602;Inherit;False;3;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;85;-1586.433,-1783.372;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;50;False;1;FLOAT;0
Node;AmplifyShaderEditor.HSVToRGBNode;116;-2109.619,-744.6718;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.VertexColorNode;127;-2071.507,-456.6181;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;69;-1438.313,-1018.939;Inherit;False;Property;_PreAdd;PreAdd;14;0;Create;True;0;0;0;False;0;False;0.7811089;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;7;-1213.908,-223.3143;Inherit;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TextureCoordinatesNode;82;-1593.176,-1985.598;Inherit;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;99;-1506.539,-1449.252;Inherit;False;Property;_UpColourRange;UpColourRange;21;0;Create;True;0;0;0;False;0;False;0.11;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;96;-1445.993,-1737.282;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.WorldNormalVector;75;-1491.243,-1593.102;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.RangedFloatNode;71;-1162.313,-1015.939;Inherit;False;Property;_PreSelfMultiply;PreSelfMultiply;15;0;Create;True;0;0;0;False;0;False;0.1223966;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleDivideOpNode;42;-1639.862,-1150.602;Inherit;True;2;0;FLOAT;0;False;1;FLOAT;3;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;11;-1068.908,-226.3143;Inherit;False;out_ao;-1;True;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;81;-1269.376,-2012.198;Inherit;True;Simplex3D;True;False;2;0;FLOAT3;34.8,56.19,0;False;1;FLOAT;8.74;False;1;FLOAT;0
Node;AmplifyShaderEditor.CommentaryNode;38;-1768.748,59.56625;Inherit;False;1299.091;395.3757;NormalMap;4;37;34;33;36;;1,1,1,1;0;0
Node;AmplifyShaderEditor.SimpleAddOpNode;98;-1104.367,-1549.42;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;68;-1306.313,-1151.939;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;95;-1268.993,-1799.282;Inherit;True;Simplex3D;True;False;2;0;FLOAT3;34.8,56.19,0;False;1;FLOAT;8.74;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;104;-2711.369,-876.1337;Inherit;False;Property;_BaseTint;BaseTint;0;0;Create;True;0;0;0;False;0;False;1,1,1,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;124;-1853.695,-648.3673;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;72;-874.3125,-1029.939;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;100;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;105;-1697.579,-774.6199;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;77;-967.2172,-1680.356;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.PowerNode;70;-1115.313,-1149.939;Inherit;False;True;2;0;FLOAT;0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;97;-1005.993,-1962.282;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;33;-1747.205,128.6277;Inherit;True;Property;_NormalMap;NormalMap;10;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;17;-1591.463,-844.3008;Inherit;False;11;out_ao;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;87;-718.4337,-1750.372;Inherit;False;Property;_UpColourNoisePower;UpColourNoisePower;20;0;Create;True;0;0;0;False;0;False;0.4681104;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-1378.003,-651.9402;Inherit;False;Property;_AO_IntoAlbedo;AO_IntoAlbedo;8;0;Create;True;0;0;0;False;0;False;0.25;0.25;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;55;-690.1351,-1080.146;Inherit;False;Property;_LowColour;LowColour;18;0;Create;True;0;0;0;False;0;False;0,0,0,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SaturateNode;63;-891.4066,-1236.835;Inherit;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.OneMinusNode;4;-1311.908,-336.3143;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;56;-686.9355,-1338.648;Inherit;False;Property;_HighColour;HighColour;17;0;Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;100;-1426.02,323.1903;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;19;-1346.003,-843.9401;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.BlendOpsNode;83;-755.1055,-1990.081;Inherit;True;VividLight;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;86;-396.6886,-1993.192;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StaticSwitch;102;-1283.015,305.1899;Inherit;False;Property;_FlipGreen;FlipGreen?;12;0;Create;True;0;0;0;False;0;False;0;0;0;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-1632.908,-126.3143;Inherit;False;Property;_MetalnessAdjust;MetalnessAdjust;6;0;Create;True;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;57;-459.1353,-1243.246;Inherit;True;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;14;-1120.908,-305.3143;Inherit;False;Property;_GlossAdjust;GlossAdjust;5;0;Create;True;0;0;0;False;0;False;0;0;-1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;89;-412.7021,-1750.695;Inherit;False;Property;_UpColourAmount;UpColourAmount;22;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;18;-1198.003,-764.9404;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StaticSwitch;3;-1311.908,-430.3143;Inherit;False;Property;_ToggleRoughnessToGloss;ToggleRoughnessToGloss;4;0;Create;True;0;0;0;True;0;False;0;1;1;True;;Toggle;2;Key0;Key1;Create;False;True;9;1;FLOAT;0;False;0;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT;0;False;7;FLOAT;0;False;8;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;101;-1416.02,139.1829;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.DynamicAppendNode;103;-1189.011,138.1828;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;21;-1037.72,-770.1394;Inherit;False;out_albedo;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;88;-53.79092,-1907.892;Inherit;True;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;36;-1029.673,288.5242;Inherit;False;Property;_NormalMap_Power;NormalMap_Power;11;0;Create;True;0;0;0;False;0;False;1;0;0;3;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;9;-1337.908,-137.3143;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;13;-964.9083,-420.3143;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;58;-225.6105,-1248.503;Inherit;False;customColouring;-1;True;1;0;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;22;72.6189,-559.3063;Inherit;False;21;out_albedo;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.GetLocalVarNode;59;37.23428,-488.3627;Inherit;False;58;customColouring;1;0;OBJECT;;False;1;COLOR;0
Node;AmplifyShaderEditor.SaturateNode;16;-845.9083,-408.3143;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;61;-5.374512,-413.0155;Inherit;False;Property;_CustomColouringAmount;CustomColouringAmount;13;0;Create;True;0;0;0;False;2;Header (Custom Colouring);Space (5);False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;34;-963.6849,121.3522;Inherit;False;3;0;FLOAT4;0,0,1,0;False;1;FLOAT4;0,0,0,0;False;2;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;93;168.5313,-1902.048;Inherit;False;upMask;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SaturateNode;15;-1203.908,-142.3143;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;62;328.6255,-556.0155;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;12;-708.9083,-413.3143;Inherit;False;out_gloss;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;94;269.6649,-626.5638;Inherit;False;93;upMask;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;37;-751.1581,118.3221;Inherit;False;out_normal;-1;True;1;0;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.RegisterLocalVarNode;10;-1065.908,-145.3143;Inherit;False;out_metal;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;27;303.1044,-192.3905;Inherit;False;Property;_Emissive;Emissive;9;0;Create;True;0;0;0;False;0;False;0;0;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;79;282.5718,-442.4784;Inherit;False;Property;_UpColour;UpColour;16;0;Create;True;0;0;0;False;0;False;0.9339623,0.8798372,0.7665539,0;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;24;385.606,-44.28076;Inherit;False;12;out_gloss;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;39;381.5867,-260.3188;Inherit;False;37;out_normal;1;0;OBJECT;;False;1;FLOAT4;0
Node;AmplifyShaderEditor.GetLocalVarNode;25;381.4683,-121.3381;Inherit;False;10;out_metal;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;23;389.5602,29.82246;Inherit;False;11;out_ao;1;0;OBJECT;;False;1;FLOAT3;0
Node;AmplifyShaderEditor.LerpOp;80;584.7324,-644.3802;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;591.1621,-239.8124;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;785.9964,-283.8502;Float;False;True;-1;2;;0;0;Standard;RRF/Standard/ExtendedShader_Standard;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;117;0;1;0
WireConnection;107;1;2;1
WireConnection;107;2;6;0
WireConnection;118;0;117;1
WireConnection;118;1;119;0
WireConnection;41;0;1;1
WireConnection;41;1;1;2
WireConnection;41;2;1;3
WireConnection;85;0;84;0
WireConnection;116;0;118;0
WireConnection;116;1;117;2
WireConnection;116;2;117;3
WireConnection;7;0;107;0
WireConnection;96;0;85;0
WireConnection;42;0;41;0
WireConnection;11;0;7;0
WireConnection;81;0;82;0
WireConnection;81;1;85;0
WireConnection;98;0;75;2
WireConnection;98;1;99;0
WireConnection;68;0;42;0
WireConnection;68;1;69;0
WireConnection;95;0;82;0
WireConnection;95;1;96;0
WireConnection;124;0;1;0
WireConnection;124;1;116;0
WireConnection;124;2;127;0
WireConnection;72;0;71;0
WireConnection;105;0;104;0
WireConnection;105;1;124;0
WireConnection;77;0;98;0
WireConnection;70;0;68;0
WireConnection;70;1;72;0
WireConnection;97;0;81;0
WireConnection;97;1;95;0
WireConnection;63;0;70;0
WireConnection;4;0;2;2
WireConnection;100;0;33;2
WireConnection;19;0;17;0
WireConnection;19;1;105;0
WireConnection;83;0;97;0
WireConnection;83;1;77;0
WireConnection;86;0;77;0
WireConnection;86;1;83;0
WireConnection;86;2;87;0
WireConnection;102;0;100;0
WireConnection;57;0;55;0
WireConnection;57;1;56;0
WireConnection;57;2;63;0
WireConnection;18;0;105;0
WireConnection;18;1;19;0
WireConnection;18;2;20;0
WireConnection;3;1;2;2
WireConnection;3;0;4;0
WireConnection;101;0;33;0
WireConnection;103;0;101;0
WireConnection;103;1;102;0
WireConnection;103;2;101;2
WireConnection;21;0;18;0
WireConnection;88;0;86;0
WireConnection;88;1;89;0
WireConnection;9;0;2;3
WireConnection;9;1;8;0
WireConnection;13;0;3;0
WireConnection;13;1;14;0
WireConnection;58;0;57;0
WireConnection;16;0;13;0
WireConnection;34;1;103;0
WireConnection;34;2;36;0
WireConnection;93;0;88;0
WireConnection;15;0;9;0
WireConnection;62;0;22;0
WireConnection;62;1;59;0
WireConnection;62;2;61;0
WireConnection;12;0;16;0
WireConnection;37;0;34;0
WireConnection;10;0;15;0
WireConnection;80;0;62;0
WireConnection;80;1;79;0
WireConnection;80;2;94;0
WireConnection;40;0;62;0
WireConnection;40;1;27;0
WireConnection;0;0;80;0
WireConnection;0;1;39;0
WireConnection;0;2;40;0
WireConnection;0;3;25;0
WireConnection;0;4;24;0
WireConnection;0;5;23;0
ASEEND*/
//CHKSM=8C327BF2B141816C3EB5AE16ADA01C5E1CDFA23B