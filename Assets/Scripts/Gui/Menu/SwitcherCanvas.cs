using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gui.Menu
{
    [RequireComponent(typeof(AudioSource))]
    class SwitcherCanvas : MonoBehaviour
    {
        [SerializeField] private List<Canvas> _toEnable;
        [SerializeField] private List<Canvas> _toDisable;
        [SerializeField] private AudioClip _clip;
        private AudioSource _thisAudioSource;

        private void Awake()
        {
            _thisAudioSource = GetComponent<AudioSource>();
        }

        public void Switch()
        {
            foreach (Canvas canvas in _toDisable)
            {
                canvas.gameObject.SetActive(false);
            }
            foreach (Canvas canvas in _toEnable)
            {
                canvas.gameObject.SetActive(true);
            }

            _thisAudioSource.PlayOneShot(_clip);
        }
    }
}
