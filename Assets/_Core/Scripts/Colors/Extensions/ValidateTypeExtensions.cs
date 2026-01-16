using UnityEngine;

namespace ColoredGess.Colors
{
    public static class ValidateTypeExtensions
    {
        public static Color Color(this ValidateType validateType)
        {
            switch (validateType)
            {
                default:
                    return UnityEngine.Color.magenta;
                
                case ValidateType.RIGHT_PLACE:
                    return new Color(.004f, .4f, .188f, 1f);
                case  ValidateType.NOT_RIGHT_PLACE:
                    return new Color(.537f, .294f, .039f, 1f);
                case ValidateType.NO_PLACE:
                    return new Color(.623f, .027f, .07f, 1f);
            }
        }
    }
}