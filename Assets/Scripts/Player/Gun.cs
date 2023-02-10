using UnityEngine;

namespace Assets.Scripts.Player
{
    class Gun : MonoBehaviour
    {
        [SerializeField] private PlayerProjectile _projectile;

        public void Shoot()
        {
            Instantiate(_projectile, transform.position, Quaternion.identity);
        }
    }
}
