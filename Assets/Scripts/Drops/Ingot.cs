using UnityEngine;

namespace Assets.Scripts.Drops
{
    [RequireComponent(typeof(Rigidbody))]
    class Ingot : MoneyDrop
    {
        [SerializeField] private float _speed;

        private void Start()
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            rigidbody.AddRelativeForce(new Vector2(2500, 2500), ForceMode.VelocityChange);
        }

        private void Update()
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }
    }
}
