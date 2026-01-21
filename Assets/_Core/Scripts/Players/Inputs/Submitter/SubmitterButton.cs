using UnityEngine;

namespace ColoredGess.Players
{
    using Colors;
    
    public class SubmitterButton : MonoBehaviour
    {
        [SerializeField] private ColorsType _submitterColors;
        
        private SubmitterHandler _submitterHandler;

        private void Awake()
        {
            _submitterHandler = FindAnyObjectByType<SubmitterHandler>();
        }

        private void OnMouseDown()
        {
            _submitterHandler.OnSubmittedColors?.Invoke(_submitterColors);
        }
    }
}
