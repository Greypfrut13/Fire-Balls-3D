using System;
using TMPro;
using UnityEngine;

namespace Tower.View
{
    public class TowerSizeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _towerSizeText;
        [SerializeField] private Tower _tower;

        private void OnEnable()
        {
            _tower.OnTowerSizeChanged += TowerSizeChangeHandle;
        }

        private void OnDisable()
        {
            _tower.OnTowerSizeChanged -= TowerSizeChangeHandle;
        }

        private void TowerSizeChangeHandle(int towerSize)
        {
            _towerSizeText.text = towerSize.ToString();
        }
    }
}