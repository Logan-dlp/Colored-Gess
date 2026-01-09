using System;
using UnityEngine;

namespace ColoredGess.Players
{
    using Colors;
    
    public class SubmitterHandler : MonoBehaviour
    {
        public Action<ColorsType> OnSubmittedColors;
    }
}