using UnityEngine;

namespace Assets.Scripts.Stage
{
    class Background : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Transform _nextPoint;
        private bool _isCreatedNext;

        private void Awake()
        {
            _isCreatedNext = false;
        }

        private void Update()
        {
            transform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
            if (transform.position.x < 0 && _isCreatedNext == false)
            {
                Instantiate(gameObject, _nextPoint.position , Quaternion.identity);
                _isCreatedNext = true;
            }
        }

        private void OnBecameInvisible()
        {
            if (transform.position.x < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
