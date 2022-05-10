using System;
using UnityEngine;

namespace ECS.Component.Level
{
    [Serializable]
    public struct Settings
    {
        [Header("Regular platforms")]
        [Range(1, 25)]
        public int platformsAmount;

        public float minPlatformWidth;
        public float maxPlatformWidth;
        
        public float minPlatformLength;
        public float maxPlatformLength;
        
        [Header("Finish platform")]
        public float finishPlatformSize;

        [Header("Shared data")]
        public float platformHeight;
    }
}