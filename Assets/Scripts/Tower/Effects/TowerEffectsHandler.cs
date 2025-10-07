using System;
using UnityEngine;

namespace Tower.Effects
{
    public class TowerEffectsHandler : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _blockHitParticles;
        
        [SerializeField] private Tower _tower;

        private void OnEnable()
        {
             _tower.OnBlockHit += PlayBlockHitParticles;
        }

        private void OnDisable()
        {
            _tower.OnBlockHit -= PlayBlockHitParticles;
        }

        private void PlayBlockHitParticles()
        {
            _blockHitParticles.Play();
        }
    }
}