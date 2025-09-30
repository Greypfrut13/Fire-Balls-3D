using System;
using UnityEngine;
using UnityEngine.Events;

namespace Tank.Shoot
{
    public class Bullet : MonoBehaviour
    {
        public event UnityAction<Bullet> OnBulletDisabled;

    }
}