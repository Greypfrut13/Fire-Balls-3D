using DG.Tweening;
using UnityEngine;

namespace Tank.Effects
{
    public class TankEffectsHandler : MonoBehaviour
    {
        [Header("Shoot Effect")]
        [SerializeField] [Min(0.0f)] private float _recoilDistance;
        
        public void PlayShootAnimation(float animationTime)
        {
            transform.DOMoveZ(transform.position.z - _recoilDistance, animationTime).SetLoops(2, LoopType.Yoyo);
        }
    }
}