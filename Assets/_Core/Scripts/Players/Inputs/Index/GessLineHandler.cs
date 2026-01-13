using UnityEngine;
using System;

namespace ColoredGess.Players
{
    using Colors;
    
    public class GessLineHandler : MonoBehaviour
    {
        public Action<int> OnIndexChange;

        [SerializeField] private GameObject _cursorObject;
        [SerializeField] private GameObject[] _lineArray;
        
        public void EnableLine(int index)
        {
            int currentIndex = 0;
            
            foreach (Transform child in _lineArray[index].transform)
            {
                var indexController = child.gameObject.AddComponent<IndexController>();
                indexController.SetUp(currentIndex);
                indexController.OnIndexChange += (indexChange, position) =>
                {
                    OnIndexChange?.Invoke(indexChange);
                    SetUpCursorPosition(position);
                };

                if (currentIndex == 0)
                {
                    SetUpCursorPosition(child.position);
                }
                
                currentIndex++;
            }
        }

        public void DisableLine(int index)
        {
            foreach (Transform child in _lineArray[index].transform)
            {
                if (child.TryGetComponent(out IndexController indexController))
                {
                    indexController.OnIndexChange -= (indexChange, position) =>
                    {
                        OnIndexChange?.Invoke(indexChange);
                        SetUpCursorPosition(position);
                    };
                    Destroy(indexController);
                }
            }
        }

        public void SetUpColorAt(int line, int index, ColorsType color)
        {
            _lineArray[line].transform.GetChild(index).gameObject.GetComponent<SpriteRenderer>().color = color.Color();
        }

        public void SetUpCursorPosition(int line, int index)
        {
            _cursorObject.transform.position = _lineArray[line].transform.GetChild(index).transform.position;
        }

        public Vector3 GetPositionAt(int line)
        {
            return _lineArray[line].transform.GetChild(0).transform.position;
        }

        private void SetUpCursorPosition(Vector3 position)
        {
            _cursorObject.transform.position = position;
        }
    }
}