// Shader created with Shader Forge v1.30 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.30;sub:START;pass:START;ps:flbk:Mobile/Diffuse,iptp:0,cusa:False,bamd:1,lico:0,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:False,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:True,stva:3,stmr:255,stmw:255,stcp:6,stps:2,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:True,fnsp:True,fnfb:False;n:type:ShaderForge.SFN_Final,id:9361,x:34675,y:32581,varname:node_9361,prsc:2|emission-5096-OUT;n:type:ShaderForge.SFN_LightColor,id:3406,x:32371,y:33256,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:30613,y:32404,prsc:2,pt:False;n:type:ShaderForge.SFN_Tex2d,id:851,x:32623,y:32092,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False;n:type:ShaderForge.SFN_Vector1,id:9409,x:31562,y:32491,varname:node_9409,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Dot,id:1658,x:31161,y:32445,varname:node_1658,prsc:2,dt:0|A-8099-OUT,B-9684-OUT;n:type:ShaderForge.SFN_RemapRange,id:1087,x:31439,y:32440,varname:node_1087,prsc:1,frmn:-1,frmx:1,tomn:0,tomx:1|IN-1658-OUT;n:type:ShaderForge.SFN_Append,id:4972,x:31742,y:32257,varname:node_4972,prsc:2|A-1087-OUT,B-9409-OUT;n:type:ShaderForge.SFN_Tex2d,id:7851,x:31905,y:32257,ptovrint:False,ptlb:Ramp,ptin:_Ramp,varname:_Ramp,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False|UVIN-4972-OUT;n:type:ShaderForge.SFN_Multiply,id:5649,x:33350,y:32467,varname:node_5649,prsc:2|A-6262-OUT,B-851-RGB,C-3406-RGB;n:type:ShaderForge.SFN_Vector3,id:9009,x:31183,y:32944,varname:node_9009,prsc:1,v1:0,v2:1,v3:0;n:type:ShaderForge.SFN_Dot,id:9017,x:31589,y:32923,varname:node_9017,prsc:1,dt:1|A-9684-OUT,B-9009-OUT;n:type:ShaderForge.SFN_Multiply,id:426,x:32417,y:32899,varname:node_426,prsc:0|A-9017-OUT,B-9608-OUT,C-336-OUT,D-3406-RGB;n:type:ShaderForge.SFN_Fresnel,id:8534,x:31772,y:33157,varname:node_8534,prsc:2|EXP-2135-OUT;n:type:ShaderForge.SFN_LightVector,id:8099,x:30691,y:32615,varname:node_8099,prsc:2;n:type:ShaderForge.SFN_ViewVector,id:375,x:30945,y:31874,varname:node_375,prsc:2;n:type:ShaderForge.SFN_Dot,id:766,x:31621,y:31945,varname:node_766,prsc:1,dt:0|A-375-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Slider,id:7644,x:30984,y:31655,ptovrint:False,ptlb:Metalness,ptin:_Metalness,varname:_Metalness,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5185784,max:1;n:type:ShaderForge.SFN_Power,id:960,x:32030,y:31942,varname:node_960,prsc:2|VAL-766-OUT,EXP-1051-OUT;n:type:ShaderForge.SFN_Multiply,id:5616,x:33136,y:32232,varname:node_5616,prsc:2|A-960-OUT,B-8812-OUT,C-851-A;n:type:ShaderForge.SFN_Slider,id:8812,x:32753,y:32337,ptovrint:False,ptlb:SpecularPower,ptin:_SpecularPower,varname:_SpecularPower,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.1930839,max:1;n:type:ShaderForge.SFN_Blend,id:2181,x:33714,y:32406,varname:node_2181,prsc:1,blmd:7,clmp:True|SRC-5501-OUT,DST-199-OUT;n:type:ShaderForge.SFN_Slider,id:163,x:31473,y:33398,ptovrint:False,ptlb:Rim Power,ptin:_RimPower,varname:_RimPower,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Slider,id:7673,x:31207,y:33169,ptovrint:False,ptlb:Rim Width,ptin:_RimWidth,varname:_RimWidth,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_RemapRange,id:2135,x:31551,y:33178,varname:node_2135,prsc:2,frmn:0,frmx:1,tomn:10,tomx:1|IN-7673-OUT;n:type:ShaderForge.SFN_RemapRange,id:8336,x:31332,y:31673,varname:node_8336,prsc:1,frmn:0,frmx:1,tomn:0.5,tomx:4.5|IN-7644-OUT;n:type:ShaderForge.SFN_Power,id:6089,x:31500,y:31673,varname:node_6089,prsc:2|VAL-8336-OUT,EXP-8336-OUT;n:type:ShaderForge.SFN_Subtract,id:1051,x:31772,y:31667,varname:node_1051,prsc:2|A-6089-OUT,B-2057-OUT;n:type:ShaderForge.SFN_Vector1,id:2057,x:31631,y:31750,varname:node_2057,prsc:2,v1:0.5;n:type:ShaderForge.SFN_SwitchProperty,id:9608,x:31992,y:33095,ptovrint:False,ptlb:Rim Light,ptin:_RimLight,varname:_RimLight,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-4921-OUT,B-8534-OUT;n:type:ShaderForge.SFN_Vector1,id:4921,x:31772,y:33084,varname:node_4921,prsc:2,v1:0;n:type:ShaderForge.SFN_Time,id:9266,x:32056,y:31221,varname:node_9266,prsc:1;n:type:ShaderForge.SFN_Sin,id:5195,x:32245,y:31267,varname:node_5195,prsc:1|IN-9266-TDB;n:type:ShaderForge.SFN_Multiply,id:3403,x:32899,y:31423,varname:node_3403,prsc:1|A-6178-OUT,B-2563-RGB;n:type:ShaderForge.SFN_Tex2d,id:2563,x:32755,y:31538,ptovrint:False,ptlb:SelfIllum,ptin:_SelfIllum,varname:_SelfIllum,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_SwitchProperty,id:6178,x:32725,y:31256,ptovrint:False,ptlb:Pulsation,ptin:_Pulsation,varname:_Pulsation,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-2404-OUT,B-6751-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:3993,x:31732,y:33822,varname:node_3993,prsc:2;n:type:ShaderForge.SFN_Multiply,id:9512,x:32383,y:33976,varname:node_9512,prsc:1|A-4264-OUT,B-579-OUT;n:type:ShaderForge.SFN_ObjectPosition,id:211,x:31732,y:33954,varname:node_211,prsc:2;n:type:ShaderForge.SFN_Subtract,id:4264,x:31976,y:33804,varname:node_4264,prsc:1|A-3993-Y,B-211-Y;n:type:ShaderForge.SFN_Slider,id:579,x:31626,y:34173,ptovrint:False,ptlb:Toplight,ptin:_Toplight,varname:_Toplight,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:336,x:31882,y:33396,varname:node_336,prsc:2|A-163-OUT,B-9187-OUT;n:type:ShaderForge.SFN_Vector1,id:9187,x:31651,y:33524,varname:node_9187,prsc:2,v1:5;n:type:ShaderForge.SFN_Clamp01,id:5501,x:33350,y:32244,varname:node_5501,prsc:2|IN-5616-OUT;n:type:ShaderForge.SFN_Clamp01,id:2290,x:32605,y:32863,varname:node_2290,prsc:2|IN-426-OUT;n:type:ShaderForge.SFN_Multiply,id:4263,x:33448,y:32760,varname:node_4263,prsc:1|A-5261-OUT,B-3406-RGB,C-2290-OUT,D-4127-R;n:type:ShaderForge.SFN_Append,id:7497,x:31741,y:32589,varname:node_7497,prsc:2|A-3389-OUT,B-8222-OUT;n:type:ShaderForge.SFN_Vector1,id:8222,x:31539,y:32673,varname:node_8222,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Lerp,id:9875,x:32443,y:32558,varname:node_9875,prsc:1|A-7851-RGB,B-3534-OUT,T-8920-G;n:type:ShaderForge.SFN_Tex2d,id:8920,x:32145,y:32756,ptovrint:False,ptlb:MetalMask,ptin:_MetalMask,varname:_MetalMask,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Add,id:9734,x:34157,y:32623,varname:node_9734,prsc:1|A-2181-OUT,B-4263-OUT,C-3403-OUT;n:type:ShaderForge.SFN_Tex2d,id:4127,x:33083,y:32943,ptovrint:False,ptlb:Rim Mask,ptin:_RimMask,varname:_RimMask,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RemapRangeAdvanced,id:6751,x:32542,y:31538,varname:node_6751,prsc:2|IN-5195-OUT,IMIN-7178-OUT,IMAX-7042-OUT,OMIN-7884-OUT,OMAX-2404-OUT;n:type:ShaderForge.SFN_Vector1,id:7042,x:32092,y:31476,varname:node_7042,prsc:1,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:7884,x:32221,y:31700,ptovrint:False,ptlb:GlowMin,ptin:_GlowMin,varname:_GlowMin,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.5;n:type:ShaderForge.SFN_ValueProperty,id:2404,x:32369,y:31756,ptovrint:False,ptlb:GlowMax,ptin:_GlowMax,varname:_GlowMax,prsc:1,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1.2;n:type:ShaderForge.SFN_Negate,id:7178,x:32269,y:31476,varname:node_7178,prsc:1|IN-7042-OUT;n:type:ShaderForge.SFN_RemapRange,id:5261,x:32916,y:32659,varname:node_5261,prsc:2,frmn:0,frmx:1,tomn:0.1,tomx:3|IN-851-RGB;n:type:ShaderForge.SFN_Multiply,id:1590,x:32885,y:32492,varname:node_1590,prsc:1|A-8916-OUT,B-2202-OUT;n:type:ShaderForge.SFN_Add,id:2202,x:32548,y:33823,varname:node_2202,prsc:2|A-9512-OUT,B-1560-OUT;n:type:ShaderForge.SFN_Vector1,id:1560,x:32376,y:33847,varname:node_1560,prsc:2,v1:1;n:type:ShaderForge.SFN_ConstantClamp,id:6262,x:33098,y:32492,varname:node_6262,prsc:2,min:0,max:1.5|IN-1590-OUT;n:type:ShaderForge.SFN_Clamp01,id:199,x:33543,y:32467,varname:node_199,prsc:2|IN-5649-OUT;n:type:ShaderForge.SFN_Add,id:8916,x:32694,y:32529,varname:node_8916,prsc:2|A-9875-OUT,B-9015-OUT;n:type:ShaderForge.SFN_Vector1,id:9015,x:32459,y:32783,varname:node_9015,prsc:2,v1:0.1;n:type:ShaderForge.SFN_RemapRange,id:3389,x:31439,y:32220,varname:node_3389,prsc:1,frmn:-1,frmx:1,tomn:0,tomx:1|IN-766-OUT;n:type:ShaderForge.SFN_Tex2d,id:523,x:31936,y:32512,ptovrint:False,ptlb:MetalRamp,ptin:_MetalRamp,varname:_MetalRamp,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,ntxv:1,isnm:False|UVIN-7497-OUT;n:type:ShaderForge.SFN_Multiply,id:3534,x:32178,y:32575,varname:node_3534,prsc:2|A-523-RGB,B-6245-OUT,C-1296-OUT;n:type:ShaderForge.SFN_Add,id:8216,x:32104,y:32301,varname:node_8216,prsc:2|A-7851-R,B-7851-G,C-7851-B;n:type:ShaderForge.SFN_Divide,id:6245,x:32285,y:32301,varname:node_6245,prsc:2|A-8216-OUT,B-7665-OUT;n:type:ShaderForge.SFN_Vector1,id:7665,x:32104,y:32430,varname:node_7665,prsc:2,v1:3;n:type:ShaderForge.SFN_Vector1,id:1296,x:32055,y:32666,varname:node_1296,prsc:2,v1:1.5;n:type:ShaderForge.SFN_Add,id:5096,x:34393,y:32811,varname:node_5096,prsc:2|A-9734-OUT,B-7244-OUT;n:type:ShaderForge.SFN_Fresnel,id:9749,x:33945,y:32886,varname:node_9749,prsc:2|EXP-1166-OUT;n:type:ShaderForge.SFN_Vector1,id:1166,x:33739,y:32958,varname:node_1166,prsc:2,v1:3;n:type:ShaderForge.SFN_Multiply,id:7481,x:34117,y:32917,varname:node_7481,prsc:2|A-9749-OUT,B-7152-OUT;n:type:ShaderForge.SFN_Vector1,id:7152,x:33935,y:33020,varname:node_7152,prsc:2,v1:5;n:type:ShaderForge.SFN_Multiply,id:7244,x:34294,y:33075,varname:node_7244,prsc:2|A-7481-OUT,B-9131-RGB,C-7343-OUT;n:type:ShaderForge.SFN_Color,id:9131,x:33739,y:33106,ptovrint:False,ptlb:edgeGlowColor,ptin:_edgeGlowColor,varname:_edgeGlowColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Slider,id:7343,x:33868,y:33337,ptovrint:False,ptlb:edgeGlowStrength,ptin:_edgeGlowStrength,varname:_edgeGlowStrength,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;proporder:851-7851-2563-2404-7884-6178-8920-523-7644-8812-9608-163-7673-4127-579-9131-7343;pass:END;sub:END;*/

Shader "Dicast/test_character" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "gray" {}
        _Ramp ("Ramp", 2D) = "gray" {}
        _SelfIllum ("SelfIllum", 2D) = "black" {}
        _GlowMax ("GlowMax", Float ) = 1.2
        _GlowMin ("GlowMin", Float ) = 0.5
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
            "DisableBatching"="True"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            Stencil {
                Ref 3
                Pass Replace
            }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 2.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform sampler2D _Ramp; uniform float4 _Ramp_ST;
            uniform half _Metalness;
            uniform half _SpecularPower;
            uniform half _RimPower;
            uniform half _RimWidth;
            uniform fixed _RimLight;
            uniform sampler2D _SelfIllum; uniform float4 _SelfIllum_ST;
            uniform fixed _Pulsation;
            uniform half _Toplight;
            uniform sampler2D _MetalMask; uniform float4 _MetalMask_ST;
            uniform sampler2D _RimMask; uniform float4 _RimMask_ST;
            uniform half _GlowMin;
            uniform half _GlowMax;
            uniform sampler2D _MetalRamp; uniform float4 _MetalRamp_ST;
            uniform float4 _edgeGlowColor;
            uniform float _edgeGlowStrength;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                o.posWorld = mul(_Object2World, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( _Object2World, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
////// Emissive:
                half node_766 = dot(viewDirection,i.normalDir);
                half node_8336 = (_Metalness*4.0+0.5);
                half4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float2 node_4972 = float2((dot(lightDirection,i.normalDir)*0.5+0.5),0.5);
                half4 _Ramp_var = tex2D(_Ramp,TRANSFORM_TEX(node_4972, _Ramp));
                float2 node_7497 = float2((node_766*0.5+0.5),0.5);
                float4 _MetalRamp_var = tex2D(_MetalRamp,TRANSFORM_TEX(node_7497, _MetalRamp));
                half4 _MetalMask_var = tex2D(_MetalMask,TRANSFORM_TEX(i.uv0, _MetalMask));
                float4 _RimMask_var = tex2D(_RimMask,TRANSFORM_TEX(i.uv0, _RimMask));
                half4 node_9266 = _Time + _TimeEditor;
                half node_7042 = 1.0;
                half node_7178 = (-1*node_7042);
                half4 _SelfIllum_var = tex2D(_SelfIllum,TRANSFORM_TEX(i.uv0, _SelfIllum));
                float3 emissive = ((saturate((saturate((clamp(((lerp(_Ramp_var.rgb,(_MetalRamp_var.rgb*((_Ramp_var.r+_Ramp_var.g+_Ramp_var.b)/3.0)*1.5),_MetalMask_var.g)+0.1)*(((i.posWorld.g-objPos.g)*_Toplight)+1.0)),0,1.5)*_Diffuse_var.rgb*_LightColor0.rgb))/(1.0-saturate((pow(node_766,(pow(node_8336,node_8336)-0.5))*_SpecularPower*_Diffuse_var.a)))))+((_Diffuse_var.rgb*2.9+0.1)*_LightColor0.rgb*saturate((max(0,dot(i.normalDir,half3(0,1,0)))*lerp( 0.0, pow(1.0-max(0,dot(normalDirection, viewDirection)),(_RimWidth*-9.0+10.0)), _RimLight )*(_RimPower*5.0)*_LightColor0.rgb))*_RimMask_var.r)+(lerp( _GlowMax, (_GlowMin + ( (sin(node_9266.b) - node_7178) * (_GlowMax - _GlowMin) ) / (node_7042 - node_7178)), _Pulsation )*_SelfIllum_var.rgb))+((pow(1.0-max(0,dot(normalDirection, viewDirection)),3.0)*5.0)*_edgeGlowColor.rgb*_edgeGlowStrength));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Mobile/Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
