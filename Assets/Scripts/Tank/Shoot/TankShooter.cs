using System;
using Tank.Effects;
using UnityEngine;

namespace Tank.Shoot
{
    public class TankShooter : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _delayBetwenShoots;
        [SerializeField] [Min(0)] private int _initialBulletPoolSize;
        
        [SerializeField] private Transform _bulletPoolParent;
        
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private TankEffectsHandler _tankEffectsHandler;
        
        private BulletPool _bulletPool;
        private float _timeAfterShot;

        private void Start()
        {
            _bulletPool = new BulletPool(_bulletPrefab, _bulletPoolParent, _initialBulletPoolSize);
        }

        private void Update()
        {
            UpdateShootCooldown();
            HandleShootingInput();
        }

        private void HandleShootingInput()
        {
            if (Input.GetMouseButton(0) && _timeAfterShot >= _delayBetwenShoots)
            {
                Shoot();
            }  
        }

        private void Shoot()
        {
            Bullet bullet = _bulletPool.GetBullet();
            _tankEffectsHandler.PlayShootAnimation(_delayBetwenShoots / 2f);
            _timeAfterShot = 0;
        }

        private void UpdateShootCooldown()
        {
            _timeAfterShot += Time.deltaTime;
        }
    }
}