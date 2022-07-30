using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Gui
{
    [RequireComponent(typeof(Animator))]
    class LoaderSceneScreen : MonoBehaviour
    {
        private Animator _thisAnimator;

        private void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
        }

        public void LoadScene(ScenesEnum scene)
        {
            StartCoroutine(Load((int)scene));
        }

        private IEnumerator Load(int scene)
        {
            _thisAnimator.SetTrigger("end");

            yield return new WaitForSeconds(_thisAnimator.GetCurrentAnimatorClipInfo(0).Length);

            SceneManager.LoadScene(scene);
        }
    }
}
