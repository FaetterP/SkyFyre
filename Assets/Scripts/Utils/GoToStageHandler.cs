using Assets.Scripts.Gui;
using Assets.Scripts.Stage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utils
{
    [RequireComponent(typeof(AudioSource))]
    class GoToStageHandler : MonoBehaviour
    {
        [SerializeField] private WavesHandler _loaderStage;
        [SerializeField] private Sprite _backgroundSlow;
        [SerializeField] private Sprite _backgroundMedium;
        [SerializeField] private Sprite _backgroundFast;
        [SerializeField] private LoaderSceneScreen _screen;
        [SerializeField] private AudioClip _clip;
        private AudioSource _thisAudioSource;

        private void Awake()
        {
            _thisAudioSource = GetComponent<AudioSource>();
        }

        public void LoadStageScene()
        {
            _thisAudioSource.PlayOneShot(_clip);

            WavesHandler.CurrentLoader = _loaderStage;
            LoaderBackgrounds.BackgroundFast = _backgroundFast;
            LoaderBackgrounds.BackgroundMedium = _backgroundMedium;
            LoaderBackgrounds.BackgroundSlow = _backgroundSlow;

            _screen.LoadScene(ScenesEnum.Stage);
        }
    }
}
