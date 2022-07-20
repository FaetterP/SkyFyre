using Assets.Scripts.Enemies.AttackPatterns;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Boss : Enemy
    {
        [SerializeField] private Enemy _nextPhase;

        protected override void OnDeath()
        {
            foreach (AttackPattern gun in _guns)
            {
                gun.Destroy();
            }

            if (_nextPhase != null)
            {
                Instantiate(_nextPhase, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        private void OnDestroy() { }
    }
}
