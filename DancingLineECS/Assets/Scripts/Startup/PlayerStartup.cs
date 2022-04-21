using ECS;
using Leopotam.Ecs;
using UnityEngine;

namespace Startup
{
    public class PlayerStartup : MonoBehaviour, ISystemStartup
    {
        [SerializeField] private ECS.Entity.Player player;
        
        public void AddSystemsTo(EcsSystems systems)
        {
            systems.Add(new ECS.System.Player.InitSystem())
                .Inject(player);

            systems
                .Add(new ECS.System.Player.Movement())
                .Add(new ECS.System.Player.DeathCondition())
                .Add(new ECS.System.Player.LevelFinish());
        }
    }
}