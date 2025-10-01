using System.Collections.Generic;
using Tower.TowerBlocks;
using UnityEngine;

namespace Tower.Builder
{
    public class TowerBuilder
    {
        private int _towerHeight;
        private TowerBlock _towerBlockPrefab;
        private Vector3 _startPosition;
        private Transform _blocksParent;

        public List<TowerBlock> BuiltBlocks { get;  } = new List<TowerBlock>();
        
        public TowerBuilder(int towerHeight, TowerBlock towerBlockPrefab, Vector3 startPosition, Transform blocksParent)
        {
            _towerHeight = towerHeight;
            _towerBlockPrefab = towerBlockPrefab;
            _startPosition = startPosition;
            _blocksParent = blocksParent;
        }
        
        public void BuildTower()
        {
            Vector3 currentPosition = _startPosition;
            
            for (int i = 0; i < _towerHeight; i++)
            {
                TowerBlock newBlock = BuildBlock(currentPosition);
                BuiltBlocks.Add(newBlock);
                currentPosition = GetNextBuildPoint(currentPosition);
            }
        }
        
        private TowerBlock BuildBlock(Vector3 position)
        {
            TowerBlock builtBlock = UnityEngine.Object.Instantiate(_towerBlockPrefab, position, Quaternion.identity, _blocksParent);
            
            return builtBlock;
        }

        private Vector3 GetNextBuildPoint(Vector3 currentPosition)
        {
            float blockHeight = _towerBlockPrefab.transform.localScale.y;
            return currentPosition + Vector3.up * blockHeight;
        }
    }
}