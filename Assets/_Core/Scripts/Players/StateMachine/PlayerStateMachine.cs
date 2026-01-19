namespace ColoredGess.Players
{
    using StateMachine;
    using Colors;
    
    public class PlayerStateMachine : StateMachine<PlayerStateData>
    {
        protected void Awake()
        {
            _data = new PlayerStateData
            {
                CurrentLineIndex = 0,
                ColorToGessArray = new ColorsType[ColoredGessParameter.MaxColorsToGess],
                ColorSubmitToGessArray = new ColorsType[ColoredGessParameter.MaxColorsToGess],
            };
            
            TransitionTo(new AutoChooseColor());
        }
    }
}
