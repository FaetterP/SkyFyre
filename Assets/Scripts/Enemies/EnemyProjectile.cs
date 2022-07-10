using Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Renderer))]
    class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private GameObject _drop;
        private Renderer _thisRenderer;
        private int _contactDamage = 5;
        private List<EnemyProjectile> _list;

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

        public void Init(List<EnemyProjectile> list)
        {
            _list = list;
            _list.Add(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null)
            {
                _list.Remove(this);
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            transform.Translate(new Vector2(1, 0));

            if (_thisRenderer.isVisible == false)
            {
                _list.Remove(this);
                Destroy(gameObject);
            }
        }

        public void DefeatDestroy()
        {
            Instantiate(_drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
