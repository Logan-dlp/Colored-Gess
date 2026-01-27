using UnityEngine;

namespace ColoredGess.Players
{
    using StateMachine;
    using Scenes;
    
    public class WinGame : IState<PlayerStateData>
    {
        public void Enter(PlayerStateData data)
        {
            GameObject.FindGameObjectWithTag(GameTag.FINISHED_GAME).GetComponent<Canvas>().enabled = true;
            GameObject.FindGameObjectWithTag(GameTag.LOOSE_GAME).SetActive(false);
        }

        public IState<PlayerStateData> Update(PlayerStateData data)
        {
            return null;
        }

        public void Exit(PlayerStateData data)
        {
            
        }
    }
}