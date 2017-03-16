Shader "Dicast/test_character_shadow" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "gray" {}
        _Ramp ("Ramp", 2D) = "gray" {}
        _SelfIllum ("SelfIllum", 2D) = "black" {}
        _GlowMax ("GlowMax", Float ) = 1.2
        _GlowMin ("GlowMin", Float ) = 0.5
		_GlowSpeed("GlowSpeed", Float) = 1
        [MaterialToggle] _Pulsation ("Pulsation", Float ) = 0.85
        _MetalMask ("MetalMask", 2D) = "black" {}
        _MetalRamp ("MetalRamp", 2D) = "gray" {}
        _Metalness ("Metalness", Range(0, 1)) = 0.5185784
        _SpecularPower ("SpecularPower", Range(0, 1)) = 0.1930839
        [MaterialToggle] _RimLight ("Rim Light", Float ) = 0
        _RimPower ("Rim Power", Range(0, 1)) = 0.5
        _RimWidth ("Rim Width", Range(0, 1)) = 0.5
        _RimMask ("Rim Mask", 2D) = "white" {}
        _Toplight ("Toplight", Range(0, 1)) = 1
        _edgeGlowColor ("edgeGlowColor", Color) = (0.5,0.5,0.5,1)
        _edgeGlowStrength ("edgeGlowStrength", Range(0, 1)) = 0
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
            "CanUseSpriteAtlas"="True"

        }
//        Pass {
//            Name "FORWARD"
//            Tags {
//                "LightMode"="ForwardBase"
//
//            }
//            
//            
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//            #define UNITY_PASS_FORWARDBASE
//            #include "UnityCG.cginc"
////            #include "AutoLight.cginc"
//            //#include "Lighting.cginc"
//            #pragma multi_compile_fwdbase//_fullshadows
//            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
//            #pragma target 2.0
//            uniform fixed4 _TimeEditor;
////            uniform sampler2D _Diffuse; uniform fixed4 _Diffuse_ST;
////            uniform sampler2D _Ramp; uniform fixed4 _Ramp_ST;
////            uniform fixed _Metalness;
////            uniform fixed _SpecularPower;
////            uniform fixed _RimPower;
////            uniform fixed _RimWidth;
////            uniform fixed _RimLight;
//            uniform sampler2D _SelfIllum; uniform fixed4 _SelfIllum_ST;
//            uniform fixed _Pulsation;
////            uniform fixed _Toplight;
////            uniform sampler2D _MetalMask; uniform fixed4 _MetalMask_ST;
////            uniform sampler2D _RimMask; uniform fixed4 _RimMask_ST;
//            uniform fixed _GlowMin;
//            uniform fixed _GlowMax;
////            uniform sampler2D _MetalRamp; uniform fixed4 _MetalRamp_ST;
////            uniform fixed4 _edgeGlowColor;
////            uniform fixed _edgeGlowStrength;
//            struct VertexInput {
//                fixed4 vertex : POSITION;
//                fixed3 normal : NORMAL;
//                fixed2 texcoord0 : TEXCOORD0;
//            };
//            struct VertexOutput {
//                fixed4 pos : SV_POSITION;
//                fixed2 uv0 : TEXCOORD0;
//                fixed4 posWorld : TEXCOORD1;
//                fixed3 normalDir : TEXCOORD2;
////                LIGHTING_COORDS(3,4)
//            };
//            VertexOutput vert (VertexInput v) {
//                VertexOutput o = (VertexOutput)0;
//                o.uv0 = v.texcoord0;
//                o.normalDir = UnityObjectToWorldNormal(v.normal);
//                fixed4 objPos = mul ( _Object2World, fixed4(0,0,0,1) );
//                o.posWorld = mul(_Object2World, v.vertex);
////                fixed3 lightColor = _LightColor0.rgb;
//                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
////                TRANSFER_VERTEX_TO_FRAGMENT(o)
//                return o;
//            }
//            fixed4 frag(VertexOutput i) : COLOR {
//                fixed4 objPos = mul ( _Object2World, fixed4(0,0,0,1) );
//                i.normalDir = normalize(i.normalDir);
//                fixed3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
//                fixed3 normalDirection = i.normalDir;
////                fixed3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////                fixed3 lightColor = _LightColor0.rgb;
//////// Lighting:
////                fixed attenuation = LIGHT_ATTENUATION(i);
//////// Emissive:
//                fixed4 node_9266 = _Time + _TimeEditor;
//                fixed node_7042 = 1.0;
//                fixed node_7178 = (-1*node_7042);
//                fixed4 _SelfIllum_var = tex2D(_SelfIllum,TRANSFORM_TEX(i.uv0, _SelfIllum));
//                fixed3 emissive = (lerp( _GlowMax, (_GlowMin + ( (sin(node_9266.b) - node_7178) * (_GlowMax - _GlowMin) ) / (node_7042 - node_7178)), _Pulsation )*_SelfIllum_var.rgb);
////                fixed node_766 = dot(viewDirection,i.normalDir);
////                fixed node_8336 = (_Metalness*4.0+0.5);
////                fixed4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
////                fixed2 node_4972 = fixed2((dot(lightDirection,i.normalDir)*0.5+0.5),0.5);
////                fixed4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4972, _Ramp));
////                fixed2 node_7497 = fixed2((node_766*0.5+0.5),0.5);
////                fixed4 _MetalRamp_var = tex2D(_MetalRamp,TRANSFORM_TEX(node_7497, _MetalRamp));
////                fixed4 _MetalMask_var = tex2D(_MetalMask,TRANSFORM_TEX(i.uv0, _MetalMask));
////                fixed4 _RimMask_var = tex2D(_RimMask,TRANSFORM_TEX(i.uv0, _RimMask));
//                fixed3 finalColor = emissive;// + (((saturate((saturate((clamp(((lerp(_Ramp_var.rgb,(_MetalRamp_var.rgb*((_Ramp_var.r+_Ramp_var.g+_Ramp_var.b)/3.0)*1.5),_MetalMask_var.g)+0.1)*(((i.posWorld.g-objPos.g)*_Toplight)+1.0)),0,1.5)*_Diffuse_var.rgb))/(1.0-saturate((pow(node_766,(pow(node_8336,node_8336)-0.5))*_SpecularPower*_Diffuse_var.a)))))+((_Diffuse_var.rgb*2.9+0.1)*saturate((max(0,dot(i.normalDir,fixed3(0,1,0)))*lerp( 0.0, pow(1.0-max(0,dot(normalDirection, viewDirection)),(_RimWidth*-9.0+10.0)), _RimLight )*(_RimPower*5.0)))*_RimMask_var.r*_RimMask_var.r))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*5.0)*_edgeGlowColor.rgb*_edgeGlowStrength))*attenuation*_LightColor0.rgb);
//                return fixed4(finalColor,1);
//            }
//            ENDCG
//        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
//                "ForceNoShadowCasting"="True"
            }
//            Blend One One
                        Blend One Zero
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Lighting.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform fixed4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform fixed4 _Diffuse_ST;
            uniform sampler2D _Ramp; uniform fixed4 _Ramp_ST;
            uniform fixed _Metalness;
            uniform fixed _SpecularPower;
            uniform fixed _RimPower;
            uniform fixed _RimWidth;
            uniform fixed _RimLight;
            uniform sampler2D _SelfIllum; uniform fixed4 _SelfIllum_ST;
            uniform fixed _Pulsation;
            uniform fixed _Toplight;
            uniform sampler2D _MetalMask; uniform fixed4 _MetalMask_ST;
            uniform sampler2D _RimMask; uniform fixed4 _RimMask_ST;
            uniform fixed _GlowMin;
            uniform fixed _GlowMax;
			uniform fixed _GlowSpeed;
            uniform sampler2D _MetalRamp; uniform fixed4 _MetalRamp_ST;
            uniform fixed4 _edgeGlowColor;
            uniform fixed _edgeGlowStrength;
            struct VertexInput {
                fixed4 vertex : POSITION;
                fixed3 normal : NORMAL;
                fixed2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                fixed4 pos : SV_POSITION;
                fixed2 uv0 : TEXCOORD0;
                fixed4 posWorld : TEXCOORD1;
                fixed3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                fixed4 objPos = mul ( _Object2World, fixed4(0,0,0,1) );
                o.posWorld = mul(_Object2World, v.vertex);
                fixed3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                fixed4 objPos = mul ( _Object2World, fixed4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                fixed3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                fixed3 normalDirection = i.normalDir;
                fixed3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                fixed3 lightColor = _LightColor0.rgb;
////// Emissive:
				fixed4 node_9261 = _Time + _TimeEditor;
				fixed4 node_9266 = node_9261*_GlowSpeed;
				fixed node_7042 = 1.0;
				fixed node_7178 = (-1 * node_7042);
				fixed4 _SelfIllum_var = tex2D(_SelfIllum, TRANSFORM_TEX(i.uv0, _SelfIllum));
				fixed3 emissive = (lerp(_GlowMax, (_GlowMin + ((sin(node_9266.b) - node_7178) * (_GlowMax - _GlowMin)) / (node_7042 - node_7178)), _Pulsation)*_SelfIllum_var.rgb);
////// Lighting:
                fixed attenuation = LIGHT_ATTENUATION(i);
                fixed node_766 = dot(viewDirection,i.normalDir);
                fixed node_8336 = (_Metalness*4.0+0.5);
                fixed4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                fixed2 node_4972 = fixed2((dot(lightDirection,i.normalDir)*0.5+0.5),0.5);
                fixed4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4972, _Ramp));
                fixed2 node_7497 = fixed2((node_766*0.5+0.5),0.5);
                fixed4 _MetalRamp_var = tex2D(_MetalRamp,TRANSFORM_TEX(node_7497, _MetalRamp));
                fixed4 _MetalMask_var = tex2D(_MetalMask,TRANSFORM_TEX(i.uv0, _MetalMask));
                fixed4 _RimMask_var = tex2D(_RimMask,TRANSFORM_TEX(i.uv0, _RimMask));
                fixed3 finalColor = (((saturate((saturate((clamp(((lerp(_Ramp_var.rgb,(_MetalRamp_var.rgb*((_Ramp_var.r+_Ramp_var.g+_Ramp_var.b)/3.0)*1.5),_MetalMask_var.g)+0.1)*(((i.posWorld.g-objPos.g)*_Toplight)+1.0)),0,1.5)*_Diffuse_var.rgb))/(1.0-saturate((pow(node_766,(pow(node_8336,node_8336)-0.5))*_SpecularPower*_Diffuse_var.a)))))+((_Diffuse_var.rgb*2.9+0.1)*saturate((max(0,dot(i.normalDir,fixed3(0,1,0)))*lerp( 0.0, pow(1.0-max(0,dot(normalDirection, viewDirection)),(_RimWidth*-9.0+10.0)), _RimLight )*(_RimPower*5.0)))*_RimMask_var.r*_RimMask_var.r))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*5.0)*_edgeGlowColor.rgb*_edgeGlowStrength))*attenuation*_LightColor0.rgb+emissive);
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
//        Pass {
//            Name "Meta"
//            Tags {
//                "LightMode"="Meta"
//            }
//            Cull Off
//            
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//            #define UNITY_PASS_META 1
//            #include "UnityCG.cginc"
//            #include "UnityMetaPass.cginc"
//            #pragma fragmentoption ARB_precision_hint_fastest
//            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
//            #pragma target 2.0
//            uniform fixed4 _TimeEditor;
//            uniform sampler2D _SelfIllum; uniform fixed4 _SelfIllum_ST;
//            uniform fixed _Pulsation;
//            uniform fixed _GlowMin;
//            uniform fixed _GlowMax;
//            struct VertexInput {
//                fixed4 vertex : POSITION;
//                fixed2 texcoord0 : TEXCOORD0;
//                fixed2 texcoord1 : TEXCOORD1;
//                fixed2 texcoord2 : TEXCOORD2;
//            };
//            struct VertexOutput {
//                fixed4 pos : SV_POSITION;
//                fixed2 uv0 : TEXCOORD0;
//            };
//            VertexOutput vert (VertexInput v) {
//                VertexOutput o = (VertexOutput)0;
//                o.uv0 = v.texcoord0;
//                o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST );
//                return o;
//            }
//            fixed4 frag(VertexOutput i) : SV_Target {
//                UnityMetaInput o;
//                UNITY_INITIALIZE_OUTPUT( UnityMetaInput, o );
//                
//                fixed4 node_9266 = _Time + _TimeEditor;
//                fixed node_7042 = 1.0;
//                fixed node_7178 = (-1*node_7042);
//                fixed4 _SelfIllum_var = tex2D(_SelfIllum,TRANSFORM_TEX(i.uv0, _SelfIllum));
//                o.Emission = (lerp( _GlowMax, (_GlowMin + ( (sin(node_9266.b) - node_7178) * (_GlowMax - _GlowMin) ) / (node_7042 - node_7178)), _Pulsation )*_SelfIllum_var.rgb);
//                
//                fixed3 diffColor = fixed3(0,0,0);
//                o.Albedo = diffColor;
//                
//                return UnityMetaFragment( o );
//            }
//            ENDCG
//        }
    }
    FallBack "Mobile/Diffuse"
    //CustomEditor "ShaderForgeMaterialInspector"
}
