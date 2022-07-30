using Assets.Scripts.Gui;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Stage
{
    class WavesHandler : MonoBehaviour
    {
        public static WavesHandler CurrentLoader;

        [SerializeField] private Wave[] _waves;
        private int _indexWave;
        private LoaderSceneScreen _loaderSceneScreen;

        private void Awake()
        {
            _indexWave = 0;
            _loaderSceneScreen = FindObjectOfType<LoaderSceneScreen>();
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
                StartCoroutine(WaitAndGoToMenu());
            }
        }

        private IEnumerator WaitAndGoToMenu()
        {
            yield return new WaitForSeconds(5f);
            _loaderSceneScreen.LoadScene(ScenesEnum.MenuStages);
        }
    }
}
