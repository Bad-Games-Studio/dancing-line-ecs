using System;
using ECS.Component;
using ECS.Component.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Entity
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour, IEcsWorldEntity
    {
        [SerializeField] private Movement movement;
        
        private EcsEntity _entity;


        public void CreateEntityIn(EcsWorld world)
        {
            _entity = world.NewEntity();
            _entity.Get<Tag>();

            ref var mov = ref _entity.Get<Movement>();
            mov = movement;
            mov.CurrentDirection = Vector3.right;
            
            
            ref var transformRef = ref _entity.Get<TransformRef>();
            transformRef.Transform = transform;

            ref var rigidBodyRef = ref _entity.Get<RigidBodyRef>();
            rigidBodyRef.Rigidbody = transform.GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CollisionTag.LevelFinish>(out _))
            {
                _entity.Get<Component.Player.Event.FinishReached>();
            }
        }

        public void OnDestroy()
        {
            Debug.Log("status: ded");
        }
    }
}