using Leopotam.Ecs;
using ECS.Component.Player;
using UnityEngine;
using PlayerTag = ECS.Component.Player.Tag;
using PlayerSpeed = ECS.Component.Player.MovementSpeed;

namespace ECS.System.Player
{
    public class Movement : IEcsRunSystem
    {
        private EcsFilter<PlayerTag, Component.TransformRef, PlayerSpeed> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformRef = ref _filter.Get2(i);
                ref var speed = ref _filter.Get3(i);
                HandleMovement(transformRef.Transform, ref speed);
            }
        }

        private static void HandleMovement(Transform transform, ref MovementSpeed movementSpeed)
        {
            transform.position += Time.deltaTime * movementSpeed.Value * Vector3.up;
        }
    }
}