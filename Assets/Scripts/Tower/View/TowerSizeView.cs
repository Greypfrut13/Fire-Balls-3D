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
            _tower.OnBlockHit += ChangeTowerSizeText;

            ChangeTowerSizeText();
        }

        private void OnDisable()
        {
            _tower.OnBlockHit -= ChangeTowerSizeText;
        }

        private void ChangeTowerSizeText()
        {
            _towerSizeText.text = _tower.TowerSize.ToString();
        }
    }
}