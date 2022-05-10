using Leopotam.Ecs;
using UnityEngine;

namespace ECS.System.Camera
{
    public class Movement : IEcsRunSystem
    {
        private EcsFilter<
            Component.Camera.Tag,
            Component.TransformRef,
            Component.Camera.Settings> _filter;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var transformRef = ref _filter.Get2(i);
                ref var settings = ref _filter.Get3(i);
                HandleMovement(transformRef.Transform, ref settings);
            }
        }

        private static void HandleMovement(Transform cameraTransform, ref Component.Camera.Settings settings)
        {
            var targetPosition = settings.target.position;
            var cameraPosition = targetPosition + settings.offset;
            
            var forward = targetPosition - cameraPosition;
            
            cameraTransform.position = cameraPosition;
            cameraTransform.rotation = Quaternion.LookRotation(forward);
        }
    }
}