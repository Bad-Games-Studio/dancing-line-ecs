using System;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace ECS.System.Level
{
    public class Generation : IEcsInitSystem
    {
        private ECS.Entity.Level _level;

        private float _platformsPosY; 
        
        public void Init()
        {
            _platformsPosY = _level.transform.position.y;
            
            GeneratePlatforms();   
        }

        
        private enum Axis
        {
            X, Z
        }

        private static Axis ChangeAxis(Axis currentAxis)
        {
            return currentAxis switch
            {
                Axis.X => Axis.Z,
                Axis.Z => Axis.X,
                _ => throw new ArgumentOutOfRangeException(nameof(currentAxis), currentAxis, null)
            };
        }
        
        private void GeneratePlatforms()
        {
            var axis = Axis.X;
            var previousScale = Vector3.zero;
            var previousPosition = Vector3.zero;
            for (var i = 0; i < _level.settings.platformsAmount; ++i)
            {
                var scale = RandomScale(axis);
                var position = i == 0 ? 
                    FirstPosition(ref scale, axis) :
                    AlignedPlatformPosition(ref scale, ref previousScale, ref previousPosition, axis);

                CreatePlatform(_level.platformPrefab, position, scale);

                previousScale = scale;
                previousPosition = position;
                axis = ChangeAxis(axis);
            }

            axis = ChangeAxis(axis);
            var finishScale = FinishPlatformScale();
            var finishPosition = AlignedFinishPosition(
                ref finishScale, ref previousScale, ref previousPosition, axis);
            CreatePlatform(_level.finishPrefab, finishPosition, finishScale);
        }
        
        private Vector3 RandomScale(Axis axis)
        {
            var width = Random.Range(_level.settings.minPlatformWidth, _level.settings.maxPlatformWidth);
            var length = Random.Range(_level.settings.minPlatformLength, _level.settings.maxPlatformLength);

            return axis switch
            {
                Axis.X => new Vector3(length, _level.settings.platformHeight, width),
                Axis.Z => new Vector3(width, _level.settings.platformHeight, length),
                _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
            };
        }

        private Vector3 FinishPlatformScale()
        {
            return new Vector3
            {
                x = _level.settings.finishPlatformSize,
                y = _level.settings.platformHeight,
                z = _level.settings.finishPlatformSize
            };
        }

        private Vector3 FirstPosition(ref Vector3 scale, Axis axis)
        {
            const float modifier = 0.9f;
            return axis switch
            {
                Axis.X => new Vector3
                {
                    x = modifier * scale.x / 2,
                    y = _platformsPosY,
                    z = 0
                },
                Axis.Z => new Vector3
                {
                    x = 0,
                    y = _platformsPosY,
                    z = modifier * scale.z / 2
                },
                _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
            };
        }

        private Vector3 AlignedPlatformPosition(
            ref Vector3 scale, ref Vector3 previousScale,
            ref Vector3 previousPosition, Axis axis)
        {
            return axis switch
            {
                Axis.X => new Vector3
                {
                    x = previousPosition.x - (previousScale.x / 2) + (scale.x / 2),
                    y = _platformsPosY,
                    z = previousPosition.z + (previousScale.z / 2) + (scale.z / 2)
                },
                Axis.Z => new Vector3
                {
                    x = previousPosition.x + (previousScale.x / 2) + (scale.x / 2),
                    y = _platformsPosY,
                    z = previousPosition.z - (previousScale.z / 2) + (scale.z / 2)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
            };
        }

        private Vector3 AlignedFinishPosition(
            ref Vector3 finishScale, ref Vector3 previousScale,
            ref Vector3 previousPosition, Axis axis)
        {
            return axis switch
            {
                Axis.X => new Vector3
                {
                    x = previousPosition.x + (previousScale.x / 2) + (finishScale.x / 2),
                    y = _platformsPosY,
                    z = previousPosition.z
                },
                Axis.Z => new Vector3
                {
                    x = previousPosition.x,
                    y = _platformsPosY,
                    z = previousPosition.z + (previousScale.z / 2) + (finishScale.z / 2)
                },
                _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
            };
        }

        private void CreatePlatform(GameObject platform, Vector3 position, Vector3 scale)
        {
            var clone = Object.Instantiate(platform, position, Quaternion.identity);
            clone.transform.localScale = scale;
            clone.transform.parent = _level.transform;
        }
    }
}