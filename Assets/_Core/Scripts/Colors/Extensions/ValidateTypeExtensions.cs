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
                    return new Color(.486f, .812f, .208f, 1f);
                case  ValidateType.NOT_RIGHT_PLACE:
                    return new Color(1f, .537f, .016f, 1f);
                case ValidateType.NO_PLACE:
                    return new Color(.906f, .094f, .043f, 1f);
            }
        }
    }
}