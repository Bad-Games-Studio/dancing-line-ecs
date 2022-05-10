using System;
using UnityEngine;

namespace ECS.Component.Player
{
    [Serializable]
    public struct Movement
    {
        public float speed;

        [NonSerialized]
        public Vector3 CurrentDirection;

        public Vector3 Velocity => speed * CurrentDirection;
    }
}