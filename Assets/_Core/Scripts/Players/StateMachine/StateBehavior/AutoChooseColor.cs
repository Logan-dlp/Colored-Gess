using UnityEngine;

namespace ColoredGess.Players
{
    using StateMachine;
    using Colors;
    
    public class AutoChooseColor : IState<PlayerStateData>
    {
        public void Enter(PlayerStateData data)
        {
            for (int i = 0; i < data.ColorToGessArray.Length; i++)
            {
                int randomColor = Random.Range(0, System.Enum.GetValues(typeof(ColorsType)).Length - 1);
                data.ColorToGessArray[i] = (ColorsType)(randomColor + 1);
            }
        }

        public IState<PlayerStateData> Update(PlayerStateData data)
        {
            foreach (ColorsType colorsType in data.ColorToGessArray)
            {
                if (colorsType == ColorsType.UNDEFINED)
                {
                    return null;
                }
            }
            
            return new SubmitColor();
        }

        public void Exit(PlayerStateData data)
        {
            
        }
    }
}