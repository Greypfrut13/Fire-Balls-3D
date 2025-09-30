using System.Collections.Generic;
using UnityEngine;

namespace Tank.Shoot
{
    public class BulletPool 
    {
        private readonly Bullet _bulletPrefab;
        private readonly Transform _parent;
        private readonly int _initialPoolSize;
        
        private readonly Queue<Bullet> _availableBullets = new Queue<Bullet>();
        private readonly HashSet<Bullet> _activeBullets = new HashSet<Bullet>();

        public BulletPool(Bullet bulletPrefab, Transform parent, int initialPoolSize)
        {
            _bulletPrefab = bulletPrefab;
            _parent = parent;
            _initialPoolSize = initialPoolSize;
            
            InitializePool();
        }

        private void InitializePool()
        {
            for (int i = 0; i < _initialPoolSize; i++)
            {
                CreateBullet();    
            }
        }

        private void CreateBullet()
        {
            Bullet bullet = UnityEngine.Object.Instantiate(_bulletPrefab, _parent);
            bullet.gameObject.SetActive(false);
            bullet.OnBulletDisabled += ReturnBullet;
            _availableBullets.Enqueue(bullet);
        }

        public Bullet GetBullet()
        {
            if (_availableBullets.Count == 0)
            {
                CreateBullet();
            }
            
            Bullet bullet = _availableBullets.Dequeue();
            bullet.gameObject.SetActive(true);
            _activeBullets.Add(bullet);
            return bullet;
        }

        public void ReturnBullet(Bullet bullet)
        {
            if (_activeBullets.Contains(bullet))
            {
                _activeBullets.Remove(bullet);
                bullet.gameObject.SetActive(false);
                bullet.transform.SetParent(_parent);
                _availableBullets.Enqueue(bullet);
            }
        }
    }
}