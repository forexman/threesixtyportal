Shader "Unlit/PortalDoor"
{
    SubShader
    {
        ZWrite off
        ColorMask 0
        Cull Off

        Stencil
        {
            Ref 1
            Pass replace
        }
        Pass
        {
            
        }
    }
}
