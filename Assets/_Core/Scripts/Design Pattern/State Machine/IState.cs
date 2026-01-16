namespace ColoredGess.StateMachine
{
    public interface IState<T> where T : class
    {
        public void Enter(T data);
        public IState<T> Update(T data);
        public void Exit(T data);
    }
}