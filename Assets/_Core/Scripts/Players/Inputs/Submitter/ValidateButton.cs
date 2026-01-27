using UnityEngine;

namespace ColoredGess.Players
{
    public class ValidateButton : MonoBehaviour
    {
        private SubmitterHandler _submitterHandler;
        
        private void Awake()
        {
            _submitterHandler = FindAnyObjectByType<SubmitterHandler>();

            _submitterHandler.OnActivateValidateInputs += ActivateValidateInputs;
            _submitterHandler.OnDesactivateValidateInputs += DesactivateValidateInputs;
        }

        private void OnDestroy()
        {
            _submitterHandler.OnActivateValidateInputs -= ActivateValidateInputs;
            _submitterHandler.OnDesactivateValidateInputs -= DesactivateValidateInputs;
        }

        private void ActivateValidateInputs()
        {
            if (TryGetComponent(out Collider2D collider2D))
                collider2D.enabled = true;

            if (TryGetComponent(out SpriteRenderer spriteRenderer))
                spriteRenderer.color = new Color(spriteRenderer.color.r, 
                                                    spriteRenderer.color.g, 
                                                    spriteRenderer.color.b, 
                                                    1);
        }
        
        private void DesactivateValidateInputs()
        {
            if (TryGetComponent(out Collider2D collider2D))
                collider2D.enabled = false;

            if (TryGetComponent(out SpriteRenderer spriteRenderer))
                spriteRenderer.color = new Color(spriteRenderer.color.r, 
                    spriteRenderer.color.g, 
                    spriteRenderer.color.b, 
                    .5f);
        }
        
        private void OnMouseDown()
        {
            _submitterHandler.OnValidateColors?.Invoke();
        }
    }
}