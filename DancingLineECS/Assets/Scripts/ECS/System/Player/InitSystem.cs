using System.Xml;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.System.Player
{
    public class InitSystem : IEcsInitSystem
    {
        private ECS.Entity.Player _player;
        private EcsWorld _world;
        
        public void Init()
        {
            _player.CreateEntityIn(_world);
            Debug.Log("Player Init Success");
        }
    }
}