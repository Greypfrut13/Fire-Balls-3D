using System;
using Tower.Obstacles;
using Tower.TowerBlocks;
using UnityEngine;
using UnityEngine.Events;

namespace Tank.Shoot
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        public event UnityAction<Bullet> OnBulletDisabled;

        [SerializeField] [Min(0.0f)] private float _speed;
        [SerializeField] [Min(0.0f)] private float _bounceForce;
        [SerializeField] [Min(0.0f)] private float _bounceRadius;
        
        private Vector3 _moveDirection;

        private void Start()
        {
            _moveDirection = Vector3.forward;
        }

        private void Update()
        {
            MoveBullet();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TowerBlock block))
            {
                block.Break();
                OnBulletDisabled?.Invoke(this);
            }

            if (other.TryGetComponent(out Obstacle obstacle))
            {
                Bounce();
            }
        }

        private void MoveBullet()
        {
            transform.Translate(_moveDirection * (_speed * Time.deltaTime));
        }

        private void Bounce()
        {
            _moveDirection = Vector3.back + Vector3.up;
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            rigidbody.AddExplosionForce(_bounceForce, transform.position + new Vector3(0, -1, 1), _bounceRadius);
        }
    }
}