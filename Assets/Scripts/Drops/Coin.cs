using UnityEngine;

namespace Assets.Scripts.Drops
{
    class Coin : MoneyDrop
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }
}
