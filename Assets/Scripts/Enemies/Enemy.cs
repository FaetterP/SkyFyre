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
    [RequireComponent(typeof(AudioSource))]
    abstract class Enemy : Damageable
    {
        [SerializeField] protected int _contactDamage;
        [SerializeField] protected AttackPattern[] _guns;
        [SerializeField] protected int _experience;
        [SerializeField] protected GameObject _drop;
        [SerializeField] protected SelfDestroyingObject _explosion;
        [SerializeField] private int _projectileDamage;
        [SerializeField] private AudioClip _hitSound;
        protected Animator _thisAnimator;
        protected AudioSource _thisAudioSource;
        private EnemyArgumentFunction d_removeFromList;
        private TextCreator _textCreator;

        public int ContactDamage => _contactDamage;

        protected void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
            _thisAudioSource = GetComponent<AudioSource>();
            _textCreator = FindObjectOfType<TextCreator>();
            foreach (AttackPattern gun in _guns)
            {
                gun.Init(_projectileDamage);
                gun.gameObject.SetActive(false);
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
                _thisAudioSource.PlayOneShot(_hitSound);
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
            if (_drop != null)
            {
                Instantiate(_drop, transform.position, Quaternion.identity);
            }
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            d_removeFromList(this);
        }

        protected void StartAttack()
        {
            foreach (AttackPattern gun in _guns)
            {
                gun.gameObject.SetActive(true);
            }
        }
    }
}
