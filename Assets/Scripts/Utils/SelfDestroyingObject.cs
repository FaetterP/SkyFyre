using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    class SelfDestroyingObject : MonoBehaviour
    {
        private Animator _thisAnimator;

        private void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            StartCoroutine(StartDestroying());
        }

        private IEnumerator StartDestroying()
        {
            yield return new WaitForSeconds(_thisAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.length);
            Destroy(gameObject);
        }
    }
}
