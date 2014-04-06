// https://github.com/izmhr/DrawLineFromMesh/blob/master/Assets/material/MakeLineFromMesh.cs
Shader "Custom/MakeLine" {
	Properties {
		_Color ("Color", Color) = (1, 1, 1, 1)
		_RotVector ("Rotation Vector", Vector) = (0.0, 0.0, 0.0)
	}
	SubShader {
		Tags { "RenderType"="Transparent" }
        Blend SrcAlpha One
        Pass {
            CGPROGRAM
            
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "Transform.cginc"
            
            struct v2f {
                float4 pos : SV_POSITION;
            };
            
            float4 _Color;
            float4 _RotVector;
            
            v2f vert(appdata_base v)
            {
                v2f o;
//                v.vertex.x *= sin(_Time.z);
//				float3 rotateX(float3 v, float angle, float3 center){
//				o.vertex = rotateX(o.vertex, 180 * (1.0 + sin(_Time.z)), fixed3(0.0, 0.0, 0.0));
                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.pos.xyz = rotateZ(o.pos.xyz, _RotVector, fixed3(0.0, 0.0, 0.0));
//                o.pos.x *= sin(_Time.z);
                return o;
            }
            
            half4 frag (v2f i) : COLOR
            {
                return _Color;
            }
            ENDCG
        }
	} 
	FallBack Off
}