using Leopotam.Ecs;
using UnityEngine;

namespace ECS
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private Entity.Player player;
        
        private EcsSystems _systems;
        private EcsWorld _world;
    
        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
            _systems.Add(new System.Player.Initialize())
                .Inject(player);

            _systems.Add(new System.Player.Movement());
            
            _systems.Init();
        }

        private void Update()
        {
            _systems.Run();
        }

        private void OnDestroy()
        {
            _systems.Destroy();
            _world.Destroy();
        }
    }
}
