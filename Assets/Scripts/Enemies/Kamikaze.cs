using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Kamikaze : Enemy
    {
        [SerializeField] private int _enemyHealth;
        [SerializeField] private int _contectDamage;
        [SerializeField] private float _speed;
        private float k, b;
        private static System.Random rnd = new System.Random();

        private new void Awake()
        {
            _health = _enemyHealth;
            SolveKB(transform.position);

            base.Awake();
        }

        private void Update()
        {
            transform.localPosition -= new Vector3(_speed * Time.deltaTime, 0, 0);
            float x = transform.position.x;
            transform.position = new Vector2(x, FindY(x));
            if (transform.position.x < -1000)
            {
                Destroy(gameObject);
            }
        }

        private void SolveKB(Vector2 from)
        {
            Vector2 to = new Vector2(-1000, rnd.Next(-300, 300));
            k = (to.y - from.y) / (to.x - from.x);
            b = from.y - k * from.x;
        }

        private float FindY(float x)
        {
            return k * x + b;
        }
    }
}
