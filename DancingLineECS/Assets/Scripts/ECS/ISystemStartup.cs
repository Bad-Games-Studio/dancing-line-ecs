using Leopotam.Ecs;

namespace ECS
{
    public interface ISystemStartup
    {
        public void AddSystemsTo(EcsSystems systems);
    }
}