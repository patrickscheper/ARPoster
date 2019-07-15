Shader "Packt Publising/Window"
{
	SubShader
{ 
		Tags{ "Queue" = "Geometry-1"  }
	ZWrite off
	ColorMask 0
	Cull off

	Stencil{
		Ref 1
		Pass replace
	}
		Pass
		{
		}
	}
}
