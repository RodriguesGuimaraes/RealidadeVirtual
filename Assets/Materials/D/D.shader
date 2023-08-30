Shader "Custom/SummerPalette"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "Queue"="Transparent" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
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

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);

                // Define a paleta de cores de verão
                fixed3 summerColors[5]; //lista de 5 alementos apenas RGB
                summerColors[0] = fixed3(0.137f, 0.431f, 0.588f); // #236E96
                summerColors[1] = fixed3(0.071f, 0.698f, 0.827f); // #12B2D3
                summerColors[2] = fixed3(1.0f, 0.843f, 0.0f);     // #FFD700
                summerColors[3] = fixed3(0.952f, 0.529f, 0.184f); // #F3872F
                summerColors[4] = fixed3(1.0f, 0.349f, 0.561f);   // #FF598F

                fixed3 convertedColor = summerColors[int(col.r * 4.9999f)]; // nessa parte não sabia como converter tudo para 1 cor apenas, essa foi ideia do chatgpt msm

                return fixed4(convertedColor, col.a);
            }
            ENDCG
        }
    }
}
