using Leopotam.Ecs;
using UnityEngine;
using ECS.Component.Camera;

namespace ECS.Entity
{
    public class StaticFollowingCamera : MonoBehaviour, IEcsWorldEntity
    {
        [SerializeField] private Settings settings;
        
        public void CreateEntityIn(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<Tag>();
            
            ref var transformRef = ref entity.Get<Component.TransformRef>();
            transformRef.Transform = transform;

            ref var rSettings = ref entity.Get<Settings>();
            rSettings = settings;
        }
    }
}