using System;
using Tower.Obstacles;
using Tower.TowerBlocks;
using UnityEngine;
using UnityEngine.Events;

namespace Tank.Shoot
{
    public class Bullet : MonoBehaviour
    {
        public event UnityAction<Bullet> OnBulletDisabled;

        [SerializeField] [Min(0.0f)] private float _speed;
        
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
        }

        private void MoveBullet()
        {
            transform.Translate(_moveDirection * (_speed * Time.deltaTime));
        }
    }
}