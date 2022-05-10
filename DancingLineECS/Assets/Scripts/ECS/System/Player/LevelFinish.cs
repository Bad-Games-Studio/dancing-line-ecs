using Leopotam.Ecs;
using UnityEngine;
using PlayerTag = ECS.Component.Player.Tag;

namespace ECS.System.Player
{
    public class LevelFinish : IEcsRunSystem
    {
        private EcsFilter<
            PlayerTag,
            Component.Player.Event.FinishReached,
            Component.Player.Movement,
            Component.RigidBodyRef> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var entity = _filter.GetEntity(i);
                HandleStopOnFinishReached(entity);

                Debug.Log("Finish reached");
            }
        }

        private static void HandleStopOnFinishReached(EcsEntity entity)
        {
            ref var movement = ref entity.Get<Component.Player.Movement>();
            movement.CurrentDirection = Vector3.zero;
            
            ref var rigidBodyRef = ref entity.Get<Component.RigidBodyRef>();
            rigidBodyRef.Rigidbody.isKinematic = true;
            
            entity.Del<Component.Player.Movement>();
        }
    }
}