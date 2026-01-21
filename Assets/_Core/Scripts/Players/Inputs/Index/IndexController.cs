using System;
using UnityEngine;

namespace ColoredGess.Players
{
    public class IndexController : MonoBehaviour
    {
        public Action<int, Vector3> OnIndexChange;
        
        private int _currentIndex;
        
        public void SetUp(int index)
        {
            _currentIndex = index;
        }

        private void OnMouseDown()
        {
            OnIndexChange?.Invoke(_currentIndex, transform.position);
        }
    }
}