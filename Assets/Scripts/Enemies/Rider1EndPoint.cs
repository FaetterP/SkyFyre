using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Rider1EndPoint : EnemyEndPoint
    {
        private Wave _pertainingWave;
        [SerializeField] private Rider1 _rider;

        public void Init(Wave wave, int spawn)
        {
            _pertainingWave = wave;
            _rider.Init(spawn);
        }

        private void OnDestroy()
        {
            _pertainingWave.DecreaseCount();
        }
    }
}
