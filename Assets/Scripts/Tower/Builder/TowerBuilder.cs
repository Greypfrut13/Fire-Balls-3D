using System;
using System.Collections.Generic;
using Tower.TowerBlocks;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tower.Builder
{
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _towerHeight;

        [SerializeField] private TowerBlock _towerBlock;
        [SerializeField] private Transform _buildPoint;
        [SerializeField] private Transform _towerBLocksRoot;
        
        private List<TowerBlock> _builtBlocks = new List<TowerBlock>();

        private void Start()
        {
            BuildTower();
        }

        private void BuildTower()
        {
            for (int i = 0; i < _towerHeight; i++)
            {
                TowerBlock newBlock = BuildBlock(_buildPoint);
                _builtBlocks.Add(newBlock);
                _buildPoint = newBlock.transform;
            }
        }
        
        private TowerBlock BuildBlock(Transform buildPoint)
        {
            TowerBlock builtBlock = Instantiate(_towerBlock, GetNewBuildPoint(buildPoint), Quaternion.identity, _towerBLocksRoot);
            
            return builtBlock;
        }

        private Vector3 GetNewBuildPoint(Transform buildPoint)
        {
            Vector3 newBuildPoint = new Vector3(_buildPoint.position.x, 
                _buildPoint.position.y + _towerBlock.transform.localScale.y,
                _buildPoint.position.z);
            
            return newBuildPoint;
        }
    }
}