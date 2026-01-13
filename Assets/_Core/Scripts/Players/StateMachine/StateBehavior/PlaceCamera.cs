using UnityEngine;

namespace ColoredGess.Players
{
    using StateMachine;
    
    public class PlaceCamera : IState<PlayerStateData>
    {
        private Camera _currentCamera;
        private Vector3 _targetPosition;
        
        public void Enter(PlayerStateData data)
        {
            _currentCamera = Camera.main;
            
            var lineHandler = GameObject.FindAnyObjectByType<GessLineHandler>();
            if (lineHandler == null)
                return;
            
            _targetPosition.y = lineHandler.GetPositionAt(data.CurrentLineIndex).y;
        }

        public IState<PlayerStateData> Update(PlayerStateData data)
        {
            _currentCamera.transform.Translate((new Vector3(_currentCamera.transform.position.x, 
                                                                    _targetPosition.y, 
                                                                    _currentCamera.transform.position.z) - _currentCamera.transform.position) * Time.deltaTime);

            if (Mathf.Abs(_targetPosition.y - _currentCamera.transform.position.y) < .1f)
                return new SubmitColor();
            
            return null;
        }

        public void Exit(PlayerStateData data)
        {
            
        }
    }
}