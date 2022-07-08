using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Renderer))]
    class PlayerProjectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 150;
        private Renderer _thisRenderer;

        private void Awake()
        {
            _thisRenderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            transform.Translate(new Vector2(Time.deltaTime * _speed, 0));

            if (_thisRenderer.isVisible == false)
            {
                Destroy(gameObject);
            }
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
