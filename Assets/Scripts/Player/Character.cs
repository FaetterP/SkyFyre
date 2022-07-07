using UnityEngine;

namespace Assets.Scripts.Player
{
    class Character : MonoBehaviour
    {
        [SerializeField] private Transform _projectileSpawn;
        [SerializeField] private PlayerProjectile _projectile;

        private void Update()
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = vec;

            if (Input.GetKey(KeyCode.Mouse0))
            {
                Instantiate(_projectile, _projectileSpawn.position, Quaternion.identity);
            }
        }
    }
}
