using Assets.Scripts.Enemies.AttackPatterns;
using Assets.Scripts.Gui;
using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;
using static Assets.Scripts.Utils.Delegates;

namespace Assets.Scripts.Enemies
{
    [RequireComponent(typeof(Animator))]
    abstract class Enemy : Damageable
    {
        [SerializeField] protected int _contactDamage;
        [SerializeField] private int _projectileDamage;
        [SerializeField] protected AttackPattern[] _guns;
        [SerializeField] protected int _experience;
        protected Animator _thisAnimator;
        private EnemyArgumentFunction d_removeFromList;
        private TextCreator _textCreator;

        public int ContactDamage
        {
            get
            {
                return _contactDamage;
            }
        }

        protected void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
            _textCreator = FindObjectOfType<TextCreator>();
            foreach (AttackPattern gun in _guns)
            {
                gun.Init(_projectileDamage);
            }
        }

        public void Init(EnemyArgumentFunction removeFromList)
        {
            d_removeFromList = removeFromList;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerProjectile projectile = collision.gameObject.GetComponent<PlayerProjectile>();
            if (projectile != null)
            {
                _textCreator.Create(transform.position, projectile.Damage);
                ApplyDamage(projectile.Damage);
                return;
            }
        }

        protected override void OnDamage()
        {
            _thisAnimator.SetBool("isDamaged", true);
            StartCoroutine(DisableAnimation());
        }

        IEnumerator DisableAnimation()
        {
            yield return new WaitForSeconds(0.05f);
            _thisAnimator.SetBool("isDamaged", false);
        }

        protected override void OnDeath()
        {
            foreach (AttackPattern gun in _guns)
            {
                gun.Destroy();
            }
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            d_removeFromList(this);
        }
    }
}
