using UnityEngine;

namespace ColoredGess.Players
{
    using Colors;
    
    public class ValidatorHandler : MonoBehaviour
    {
        [SerializeField] GameObject[] _lineArray;

        public void ColorLine(int lineIndex, ValidateType[] validateType)
        {
            if (lineIndex >= _lineArray.Length)
                return;

            for (int i = 0; i < validateType.Length; i++)
            {
                _lineArray[lineIndex].transform.GetChild(i).transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color = validateType[i].Color();
            }
        }
    }
}