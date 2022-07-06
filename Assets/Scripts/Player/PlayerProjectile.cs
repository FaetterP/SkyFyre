using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Player
{
    class PlayerProjectile : MonoBehaviour
    {
        private void Update()
        {
            transform.localPosition += new Vector3(1, 0, 0);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy == null) return;

            Destroy(gameObject);
        }
    }
}
