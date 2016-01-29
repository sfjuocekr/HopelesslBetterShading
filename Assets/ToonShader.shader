Shader "Custom/ToonShader" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
		_MainTex ("Texture (RGB)", 2D) = "white" {}
		_BumpMap ("Bump Map (A)", 2D) = "bump" {}
		_OutlineColor ("Outline Color", Color) = (0,1, 0,1)
		_OutlineWidth ("Outline Width", Range (0.002, 0.03)) = 0.01
	}

	SubShader {
		Tags { "RenderType"="Opaque" }

		Name "Outline"
		LOD 200
		Tags { "LightMode" = "Always"}

		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag

		Pass {
			half4 frag(g2f IN) : COLOR {
            return 0;
            }

         	struct vertice {
            	float4 vertex;
            	float3 normal;
        	};

         	struct v2f {
            	float4 pos : POSITION;
            	float4 color : COLOR;
            	float fog : FOGC;
         	};

         	uniform float _Outline;
         	uniform float4 _OutlineColor;

         	v2f vert(vertice _vertex) {
            	v2f _outline;
            		_outline.pos = mul(UNITY_MATRIX_MVP, _vertex.vertex);

            	float3  _normal = mul (UNITY_MATRIX_MV, _vertex.normal);
            			_normal.x *= UNITY_MATRIX_P[0][0];
            			_normal.y *= UNITY_MATRIX_P[1][1];

            	_outline.pos.xy += _normal.xy * _outline.pos.z * _OutlineWidth;

            	_outline.fog = _outline.pos.z;
            	_outline.color = _OutlineColor;

            	return o;
         	}
        }
        ENDCG
	}

	FallBack "Diffuse"
}
