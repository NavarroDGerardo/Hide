// KaIa + kdId * dot(nu, lu) +  ksIs * dot(ru, vu)^alpha
// For ru: it is the normalized version of the reflection of te light vector
// float3 r = reflect(l, n)         then normalize it and use it

Shader "Lit/PhongShader"
{

    Properties
    {
        _Color("Color", Color) = (1,1,1,1) // kdr, kdg, kdb DIFFUSE
        _Alpha("Alpha", Float) = 50 // Alpha power ror Shininess
        _Specular("Specular", Color) = (1,1,1,1) // KSR, KSG, KSB SPECULAR
        _Ambient("Ambient", Color) = (0.1, 0.1, 0.1, 1) // kar, kag. kab
        _MainTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
        Tags { "LightMode" = "ForwardBase" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float4 posWorld : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float4 _Specular;
            uniform float _Alpha;
            uniform float _Ambient;
            //uniform float4 _LightColor0; // It lives in UnityCG.inc

            v2f vert(appdata v)
            {
                v2f o;

                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.normal = normalize(mul(float4(v.normal, 0.9), unity_WorldToObject).xyz);

                o.vertex = UnityObjectToClipPos(v.vertex);

                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {

                float3 ambient = UNITY_LIGHTMODEL_AMBIENT * _Ambient;

                float3 nu = i.normal;
                float3 lu = normalize(_WorldSpaceLightPos0.xyz - i.posWorld.xyz);
                float3 diffuse = _Color.rgb * _LightColor0.rgb * max(0.0, dot(nu, lu));

                //Homework
                // KaIa + kdId * dot(nu, lu) +  ksIs * dot(ru, vu)^alpha
                // For ru: it is the normalized version of the reflection of te light vector
                // float3 r = reflect(l, n)         then normalize it and use it

                float3 r = reflect(lu, nu);
                float3 ru = normalize(r);
                float3 vu = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);;
                float3 specular = _Specular.rgb * _LightColor0.rgb * pow(max(0.0, dot(ru, vu)), _Alpha); // Falta cambiar la multiplicación (*) de Alpha por elevación (power). Falta encontrar el valor de Is.

                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv)
                fixed4 col = float4(ambient + diffuse + specular, 1);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
