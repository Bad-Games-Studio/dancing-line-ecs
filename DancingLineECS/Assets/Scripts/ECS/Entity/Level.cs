using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Entity
{
    public class Level : MonoBehaviour, IEcsWorldEntity
    {
        public void CreateEntityIn(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<Component.Level.Tag>();
        }
    }
}