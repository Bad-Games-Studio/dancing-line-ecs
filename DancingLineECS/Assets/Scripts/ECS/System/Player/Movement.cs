using Leopotam.Ecs;
using ECS.Component.Player;
using UnityEngine;
using PlayerTag = ECS.Component.Player.Tag;

namespace ECS.System.Player
{
    public class Movement : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, Component.TransformRef, Component.Player.Movement> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformRef = ref _filter.Get2(i);
                ref var movement = ref _filter.Get3(i);
                HandleMovement(transformRef.Transform, ref movement);
            }
        }

        private static void HandleMovement(Transform transform, ref Component.Player.Movement movement)
        {
            transform.position += Time.deltaTime * movement.speed * Vector3.up;
        }
    }
}