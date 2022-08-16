using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Drops
{
    [RequireComponent(typeof(AudioSource))]
    abstract class MoneyDrop : MonoBehaviour
    {
        [SerializeField] private AudioClip _pickUpClip;
        [SerializeField] private int _value;

        public AudioClip PickUpClip => _pickUpClip;
        public int Value => _value;

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            PickUpArea area = collider.gameObject.GetComponent<PickUpArea>();
            if (area != null)
            {
                Destroy(gameObject);
                return;
            }
        }
    }
}
