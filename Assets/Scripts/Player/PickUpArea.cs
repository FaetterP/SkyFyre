using Assets.Scripts.Drops;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(AudioSource))]
    class PickUpArea : MonoBehaviour
    {
        private AudioSource _thisAudioSource;

        private void Awake()
        {
            _thisAudioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            MoneyDrop moneyDrop = collider.gameObject.GetComponent<MoneyDrop>();
            if (moneyDrop != null)
            {
                Stats.AddMoney(moneyDrop.Value);
                _thisAudioSource.PlayOneShot(moneyDrop.PickUpClip);
                return;
            }
        }
    }
}
