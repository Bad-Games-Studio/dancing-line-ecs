using ECS;
using Leopotam.Ecs;
using UnityEngine;

namespace Startup
{
    public class LevelStartup : MonoBehaviour, ISystemStartup
    {
        [SerializeField] private ECS.Entity.Level level;
        
        public void AddSystemsTo(EcsSystems systems)
        {
            systems.Add(new ECS.System.Level.InitSystem())
                .Inject(level);

            systems.Add(new ECS.System.Level.Generation())
                .Inject(level);
        }
    }
}