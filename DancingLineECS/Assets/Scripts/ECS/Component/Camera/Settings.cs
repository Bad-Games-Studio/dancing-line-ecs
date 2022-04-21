using System;
using UnityEngine;

namespace ECS.Component.Camera
{
    [Serializable]
    public struct Settings
    {
        public Transform target;

        public Vector3 offset;
    }
}