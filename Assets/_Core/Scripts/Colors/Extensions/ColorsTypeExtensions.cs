using UnityEngine;

namespace ColoredGess.Colors
{
    public static class ColorsTypeExtensions
    {
        public static Color Color(this ColorsType colorsType)
        {
            switch (colorsType)
            {
                default:
                    return UnityEngine.Color.magenta;
                
                case ColorsType.Color_A:
                    return new Color(1f, .894f, .769f, 1f);
                case ColorsType.Color_B:
                    return new Color(.498f, 1f, .831f, 1f);
                case ColorsType.Color_C:
                    return new Color(.804f, .361f, .361f, 1f);
                case ColorsType.Color_D:
                    return new Color(0f, .502f, 0f, 1f);
                case ColorsType.Color_E:
                    return new Color(1f, .961f, .933f, 1f);
                case ColorsType.Color_F:
                    return new Color(.545f, .270f, .074f, 1f);
                case ColorsType.Color_G:
                    return new Color(.541f, .169f, .882f, 1f);
            }
        } 
    }
}