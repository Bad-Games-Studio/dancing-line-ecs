using ECS;
using Leopotam.Ecs;
using UnityEngine;

namespace Startup
{
    public class CameraStartup : MonoBehaviour, ISystemStartup
    {
        [SerializeField] private ECS.Entity.StaticFollowingCamera _camera;
        
        public void AddSystemsTo(EcsSystems systems)
        {
            systems.Add(new ECS.System.Camera.InitSystem())
                .Inject(_camera);

            systems.Add(new ECS.System.Camera.Movement());
        }
    }
}