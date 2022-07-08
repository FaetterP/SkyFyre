using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Renderer))]
    class EnemyProjectile : MonoBehaviour
    {
        private Renderer _thisRenderer;
        private int _contactDamage = 5;
        
        public int ContactDamage
        {
            get
            {
                return _contactDamage;
            }
        }

        private void Awake()
        {
            _thisRenderer = GetComponent<Renderer>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            transform.Translate(new Vector2(1, 0));

            if (_thisRenderer.isVisible == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
