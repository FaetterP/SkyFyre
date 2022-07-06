using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 150;

        private void Update()
        {
            transform.localPosition += new Vector3(1, 0, 0) * Time.deltaTime * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy == null) return;

            Destroy(gameObject);
        }
    }
}
