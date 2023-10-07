using Assets.Scripts.Gui;
using Assets.Scripts.Stage;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utils
{
    [RequireComponent(typeof(AudioSource))]
    class GoToStageHandler : MonoBehaviour
    {
        [SerializeField] private Stage.Stage _stage;
        [SerializeField] private LoaderSceneScreen _screen;
        [SerializeField] private AudioClip _clip;
        private AudioSource _thisAudioSource;

        private void Awake()
        {
            _thisAudioSource = GetComponent<AudioSource>();
        }

        public void LoadStageScene()
        {
            Stage.Stage.CurrentStage = _stage;

            _thisAudioSource.PlayOneShot(_clip);

            _screen.LoadScene(ScenesEnum.Stage);
        }
    }
}
