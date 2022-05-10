using Leopotam.Ecs;

namespace ECS.System.Camera
{
    public class InitSystem : IEcsInitSystem
    {
        private ECS.Entity.StaticFollowingCamera _camera;
        private EcsWorld _world;
        
        public void Init()
        {
            _camera.CreateEntityIn(_world);
        }
    }
}