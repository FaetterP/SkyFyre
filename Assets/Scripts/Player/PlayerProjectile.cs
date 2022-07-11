using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 150;

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
                Destroy(gameObject);
                return;
            }
        }
    }
}
