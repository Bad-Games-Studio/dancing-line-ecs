using ECS.Component;
using ECS.Component.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Entity
{
    public class Player : MonoBehaviour, IEcsWorldEntity
    {
        [SerializeField] private Movement movement;
        
        public void CreateEntityIn(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<Tag>();

            ref var transformRef = ref entity.Get<TransformRef>();
            transformRef.Transform = transform;

            entity.Get<Movement>() = movement;
        }
    }
}