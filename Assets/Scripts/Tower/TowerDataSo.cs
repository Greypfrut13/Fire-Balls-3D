using Tower.TowerBlocks;
using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "TowerData", menuName = "ScriptableObjects/Tower/TowerData")]
    public class TowerDataSo : ScriptableObject
    {
        [SerializeField] [Min(0)] private int _towerHeight;
        [SerializeField] private TowerBlock _towerBlockPrefab;

        public int TowerHeight => _towerHeight;

        public TowerBlock TowerBlockPrefab => _towerBlockPrefab;
    }
}