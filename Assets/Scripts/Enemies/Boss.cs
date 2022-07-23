using Assets.Scripts.Enemies.AttackPatterns;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies
{
    class Boss : Enemy
    {
        [SerializeField] private Boss _nextPhase;
        private EmptyArgumentFunction d_spawnNextWave;

        public void Init(EmptyArgumentFunction spawnNexWave)
        {
            d_spawnNextWave = spawnNexWave;
        }

        protected override void OnDeath()
        {
            foreach (AttackPattern gun in _guns)
            {
                gun.Destroy();
            }

            if (_nextPhase == null)
            {
                d_spawnNextWave();
            }
            else
            {
                Instantiate(_nextPhase, transform.position, Quaternion.identity).Init(d_spawnNextWave);
            }

            Destroy(gameObject);
        }

        private void OnDestroy() { }
    }
}
