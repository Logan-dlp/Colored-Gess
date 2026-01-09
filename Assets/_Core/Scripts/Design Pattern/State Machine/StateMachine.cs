using UnityEngine;

namespace ColoredGess.StateMachine
{
    public abstract class StateMachine<T> : MonoBehaviour where T : struct
    {
        protected T _data;
        
        private IState<T> _currentState;

        protected virtual void Update()
        {
            IState<T> nextState = _currentState?.Update(_data);
            if (nextState != null)
                TransitionTo(nextState);
        }

        protected void TransitionTo(IState<T> nextState)
        {
            _currentState?.Exit(_data);
            _currentState = nextState;
            _currentState?.Enter(_data);
        }
    }
}