using Assets.Scripts.Enemies.AttackPatterns;
using Assets.Scripts.Stage;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies
{
    class Boss : Enemy
    {
        [SerializeField] private Boss _nextPhase;
        [SerializeField] private bool _startImmediately;

        protected override void OnDeath()
        {
            foreach (AttackPattern gun in _guns)
            {
                gun.Destroy();
            }

            if (_nextPhase == null)
            {
                InvokeOnDeath(null);
            }
            else
            {
                Boss nextPhase = Instantiate(_nextPhase, transform.position, Quaternion.identity);
                InvokeOnDeath(nextPhase);
            }

            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void Start()
        {
            if (_startImmediately)
            {
                StartAttack();
            }
        }
    }
}
