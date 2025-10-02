using DG.Tweening;
using UnityEngine;

namespace Tower.Obstacles
{
    public class ObstaclesRotator : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _rotationDuration;

        [SerializeField] private bool _isYoyo;
        
        private LoopType _loopType => _isYoyo? LoopType.Yoyo : LoopType.Incremental;
        
        private void Start()
        {
            StartRotation();
        }
        
        private void StartRotation()
        {
            transform.DORotate(new Vector3(0,360, 0), _rotationDuration, RotateMode.FastBeyond360)
                .SetLoops(-1, _loopType)
                .SetEase(Ease.Linear);
        }
    }
}