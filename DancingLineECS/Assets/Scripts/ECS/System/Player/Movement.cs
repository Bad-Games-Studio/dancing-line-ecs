using Leopotam.Ecs;
using UnityEngine;
using PlayerTag = ECS.Component.Player.Tag;

namespace ECS.System.Player
{
    public class Movement : IEcsRunSystem
    {
        private EcsFilter<
            PlayerTag,
            Component.RigidBodyRef, 
            Component.Player.Movement> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var rigidBodyRef = ref _filter.Get2(i);
                ref var movement = ref _filter.Get3(i);
                HandleMovement(rigidBodyRef.Rigidbody, ref movement);
            }
        }

        private static void HandleMovement(Rigidbody rigidbody, ref Component.Player.Movement movement)
        {
            movement.CurrentDirection = NewDirectionFromInput(movement.CurrentDirection);
            
            var newVelocity = movement.Velocity;
            newVelocity.y = rigidbody.velocity.y;
            
            rigidbody.velocity = newVelocity;
        }

        private static Vector3 NewDirectionFromInput(Vector3 oldDirection)
        {
            var shouldSwitch = Input.GetKeyDown(KeyCode.Mouse0);
            if (!shouldSwitch)
            {
                return oldDirection;
            }

            return oldDirection == Vector3.forward ? Vector3.right : Vector3.forward;
        }

    }
}