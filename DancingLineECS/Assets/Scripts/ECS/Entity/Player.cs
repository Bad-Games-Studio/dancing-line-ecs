using ECS.Component;
using ECS.Component.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Entity
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private MovementSpeed movementSpeed;
        
        public void CreateEntityIn(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<Tag>();

            ref var transformRef = ref entity.Get<TransformRef>();
            transformRef.Transform = transform;

            entity.Get<MovementSpeed>() = movementSpeed;
        }
    }
}