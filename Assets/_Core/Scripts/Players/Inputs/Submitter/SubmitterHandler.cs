using System;
using UnityEngine;

namespace ColoredGess.Players
{
    using Colors;
    
    public class SubmitterHandler : MonoBehaviour
    {
        public Action<ColorsType> OnSubmittedColors;
        
        public Action OnValidateColors;
        
        public Action OnActivateValidateInputs;
        public Action OnDesactivateValidateInputs;
    }
}