using Assets.Scripts.Enemies;
using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 150;
        [SerializeField] private int _damage;
        [SerializeField] private SelfDestroyingObject _sparks;

        public int Damage
        {
            get
            {
                return _damage;
            }
        }

        private void OnBecameInvisible()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            transform.Translate(new Vector2(Time.deltaTime * _speed, 0));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                Instantiate(_sparks, transform.position, Quaternion.identity);
                Destroy(gameObject);
                return;
            }
        }
    }
}
