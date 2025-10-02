using System;
using System.Collections.Generic;
using Tower.Builder;
using Tower.TowerBlocks;
using UnityEngine;

namespace Tower
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TowerDataSo _data;
        
        [SerializeField] private Transform _buildStartPosition;
        [SerializeField] private Transform _towerBlocksRoot;
        
        private TowerBuilder _towerBuilder;

        private List<TowerBlock> _towerBlocks = new List<TowerBlock>(); 

        private void Start()
        {
            _towerBuilder = new TowerBuilder(_data.TowerHeight, _data.TowerBlockPrefab, _buildStartPosition.position, _towerBlocksRoot);
            _towerBuilder.BuildTower();
            _towerBlocks = _towerBuilder.BuiltBlocks;

            foreach (TowerBlock block in _towerBlocks)
            {
                block.OnHit += OnTowerBlockHit;
            }
        }
        
        private void OnTowerBlockHit(TowerBlock hitedBlock)
        {
            hitedBlock.OnHit -= OnTowerBlockHit;

            _towerBlocks.Remove(hitedBlock);

            foreach (TowerBlock block in _towerBlocks)
            {
                Vector3 newPosition = new Vector3(block.transform.position.x,
                    block.transform.position.y - block.transform.localScale.y,
                    block.transform.position.z);
                    
                block.transform.position = newPosition;
            }
        }
    }
}