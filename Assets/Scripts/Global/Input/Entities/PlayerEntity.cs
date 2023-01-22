using UnityEngine;

namespace Input.Entities
{
    public class PlayerEntity
    {

        public Vector2 MoveAxis { get; private set; }
        public void SetMoveAxis(Vector2 moveAxis) => MoveAxis = moveAxis;
        
        public Vector2 LookAxis { get; private set; }
        public void SetLookAxis(Vector2 lookAxis) => LookAxis = lookAxis;

        public float PullDistance { get; private set; }
        public void SetPullDistance(float pullDistance) => PullDistance = pullDistance;
        
    }
}