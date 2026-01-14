using UnityEngine;

namespace ColoredGess.Players
{
    using StateMachine;
    using Colors;
    
    public class SubmitColor : IState<PlayerStateData>
    {
        private readonly ColorsType[] _colorSubmitArray = new ColorsType[ColoredGessParameter.MaxColorsToGess];
        
        private bool _isActivateValid;
        private bool _isTryToNext;
        
        private int _colorIndex;
        private int _lineIndex;
        
        private GessLineHandler _lineHandler;
        private SubmitterHandler _submitterHandler;
        
        public void Enter(PlayerStateData data)
        {
            _lineIndex = data.CurrentLineIndex;
            
            _submitterHandler = GameObject.FindAnyObjectByType<SubmitterHandler>();
            if (_submitterHandler == null)
                return;
            
            _lineHandler = GameObject.FindAnyObjectByType<GessLineHandler>();
            if (_lineHandler == null)
                return;
            
            _lineHandler.OnIndexChange += (index) => _colorIndex = index;
            _lineHandler.EnableLine(data.CurrentLineIndex);
            
            _submitterHandler.OnSubmittedColors += SubmitColors;
            _submitterHandler.OnValidateColors += TryToNext;
        }

        public IState<PlayerStateData> Update(PlayerStateData data)
        {
            if (_submitterHandler == null)
            {
                Debug.LogError("No Color submitter handler found !");
                return null;
            }
            
            if (_colorSubmitArray != null)
            {
                foreach (ColorsType colorsType in _colorSubmitArray)
                {
                    if (colorsType == ColorsType.UNDEFINED)
                        return null;
                }

                if (!_isActivateValid)
                {
                    _submitterHandler.OnActivateValidateInputs?.Invoke();
                    _isActivateValid = true;
                }

                if (_isTryToNext)
                {
                    Debug.Log("Trying to Next Color");
                }
            }
            return null;
        }

        public void Exit(PlayerStateData data)
        {
            _lineHandler.OnIndexChange -= (index) => _colorIndex = index;
            _lineHandler.DisableLine(data.CurrentLineIndex);
            
            _submitterHandler.OnDesactivateValidateInputs?.Invoke();
            _submitterHandler.OnSubmittedColors -= SubmitColors;
            _submitterHandler.OnValidateColors -= TryToNext;
        }

        private void SubmitColors(ColorsType colorsType)
        {
            if (colorsType == ColorsType.UNDEFINED)
                return;
            
            _colorSubmitArray[_colorIndex] = colorsType;
            _lineHandler.SetUpColorAt(_lineIndex, _colorIndex, colorsType);
            
            if (_colorIndex + 1 < ColoredGessParameter.MaxColorsToGess)
                NextIndex();
        }

        private void NextIndex()
        {
            _colorIndex++;
            _lineHandler.SetUpCursorPosition(_lineIndex, _colorIndex);
        }

        private void TryToNext()
        {
            _isTryToNext = true;
        }
    }
}