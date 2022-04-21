using Leopotam.Ecs;
using UnityEngine;
using PlayerTag = ECS.Component.Player.Tag;

namespace ECS.System.Player
{
    public class DeathCondition : IEcsRunSystem
    {
        private EcsFilter<
            PlayerTag,
            Component.TransformRef> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var transformRef = _filter.Get2(i);
                
                var shouldDestroy = HandleDeathCondition(transformRef.Transform);
                if (shouldDestroy)
                {
                    _filter.GetEntity(i).Destroy();
                }
            }
        }

        private static bool HandleDeathCondition(Transform transform)
        {
            if (transform.position.y > -5)
            {
                return false;
            }
            
            Object.Destroy(transform.gameObject);

            return true;
        }
    }
}