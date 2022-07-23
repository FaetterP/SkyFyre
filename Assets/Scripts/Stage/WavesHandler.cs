using UnityEngine;

namespace Assets.Scripts.Stage
{
    class WavesHandler : MonoBehaviour
    {
        public static WavesHandler CurrentLoader;

        [SerializeField] private Wave[] _waves;
        private int _indexWave;

        private void Awake()
        {
            _indexWave = 0;
        }

        private void Start()
        {
            Instantiate(_waves[0]).Init(SpawnNextWave);
        }

        public void SpawnNextWave()
        {
            _indexWave++;
            if (_indexWave < _waves.Length)
            {
                Instantiate(_waves[_indexWave]).Init(SpawnNextWave);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
