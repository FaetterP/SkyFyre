using Assets.Scripts.Player;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class EnemyProjectile : MonoBehaviour
    {
        [SerializeField] private GameObject _drop;
        private int _contactDamage;
        private List<EnemyProjectile> _list;

        public int ContactDamage
        {
            get
            {
                return _contactDamage;
            }
        }

        public void Init(List<EnemyProjectile> list, int damage)
        {
            _contactDamage = damage;
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

        private void OnBecameInvisible()
        {
            _list.Remove(this);
            Destroy(gameObject);
        }

        private void Update()
        {
            transform.Translate(new Vector2(1, 0));
        }

        public void DefeatDestroy()
        {
            Instantiate(_drop, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
