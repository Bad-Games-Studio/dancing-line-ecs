using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Entity
{
    public class Level : MonoBehaviour, IEcsWorldEntity
    {
        public GameObject platformPrefab;
        public GameObject finishPrefab;
        
        public Component.Level.Settings settings; 
        
        public void CreateEntityIn(EcsWorld world)
        {
            var entity = world.NewEntity();
            entity.Get<Component.Level.Tag>();
        }
    }
}