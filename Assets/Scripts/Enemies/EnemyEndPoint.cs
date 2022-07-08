using Assets.Scripts.Stage;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class EnemyEndPoint : MonoBehaviour
    {
        private Wave _pertainingWave;

        public void Init(Wave wave)
        {
            _pertainingWave = wave;
        }

        private void OnDestroy()
        {
            _pertainingWave.DecreaseCount();
        }
    }
}
