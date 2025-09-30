using System;
using UnityEngine;

namespace Tank.Shoot
{
    public class TankShooter : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _delayBetwenShoots;
        
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPoint;

        private float _timeAfterShot;

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
            Bullet createdBullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity);
            _timeAfterShot = 0;
        }

        private void UpdateShootCooldown()
        {
            _timeAfterShot += Time.deltaTime;
        }
    }
}