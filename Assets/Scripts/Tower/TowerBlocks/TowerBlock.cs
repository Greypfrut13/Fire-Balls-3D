using UnityEngine;
using UnityEngine.Events;

namespace Tower.TowerBlocks
{
    public class TowerBlock : MonoBehaviour
    {
        public event UnityAction<TowerBlock> OnHit;
        
        public void Break()
        {
            OnHit?.Invoke(this);
            Destroy(gameObject);
        }
    }
}