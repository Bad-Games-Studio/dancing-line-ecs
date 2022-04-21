using Leopotam.Ecs;
using UnityEngine;

namespace ECS.System.Level
{
    public class InitSystem : IEcsInitSystem
    {
        private ECS.Entity.Level _level;
        private EcsWorld _world;
        
        public void Init()
        {
            _level.CreateEntityIn(_world);
            Debug.Log("Level created");
        }
    }
}