using UnityEngine;

namespace ColoredGess.Players
{
    using Colors;
    using Scenes;
    using StateMachine;
    
    public class ValidationColor : IState<PlayerStateData>
    {
        private readonly ValidateType[] _validationResultArray = new ValidateType[ColoredGessParameter.MaxColorsToGess];
        
        public void Enter(PlayerStateData data)
        {
            for (int i = 0; i < data.ColorSubmitToGessArray.Length; i++)
            {
                if (data.ColorSubmitToGessArray[i] == data.ColorToGessArray[i])
                    _validationResultArray[i] = ValidateType.RIGHT_PLACE;
                else
                {
                    for (int j = 0; j < data.ColorToGessArray.Length; j++)
                    {
                        if (data.ColorSubmitToGessArray[i] == data.ColorToGessArray[j] &&
                            _validationResultArray[j] != ValidateType.RIGHT_PLACE)
                        {
                            _validationResultArray[i] = ValidateType.NOT_RIGHT_PLACE;
                            break;
                        }
                    }

                    if (_validationResultArray[i] == ValidateType.UNDEFINED)
                        _validationResultArray[i] = ValidateType.NO_PLACE;
                }
            }
            
            var validatorHandler = GameObject.FindAnyObjectByType<ValidatorHandler>();
            if (validatorHandler != null)
                validatorHandler.ColorLine(data.CurrentLineIndex, _validationResultArray);
        }

        public IState<PlayerStateData> Update(PlayerStateData data)
        {
            foreach (ValidateType validateType in _validationResultArray)
            {
                if (validateType == ValidateType.UNDEFINED)
                {
                    return null;
                }
            }

            foreach (ValidateType validateType in _validationResultArray)
            {
                if (validateType == ValidateType.NOT_RIGHT_PLACE || validateType == ValidateType.NO_PLACE)
                {
                    if (data.CurrentLineIndex + 1 < ColoredGessParameter.MaxLineCount)
                    {
                        return new PlaceCamera();
                    }
                    
                    return new LooseGame();
                }
            }
            
            return new WinGame();
        }

        public void Exit(PlayerStateData data)
        { 
            if (data.CurrentLineIndex + 1 < ColoredGessParameter.MaxLineCount)
                data.CurrentLineIndex++;
        }
    }
}