using Assets.Scripts.Enemies.AttackPatterns;
using Assets.Scripts.Gui;
using Assets.Scripts.Player;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

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
        private TextCreator _textCreator;
        private UnityEvent<Enemy, Enemy> e_onDeath = new UnityEvent<Enemy, Enemy>();
        private UnityEvent<Enemy> e_onEndTrace = new UnityEvent<Enemy>();

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

        public void OnDeathAddListener(UnityAction<Enemy, Enemy> callback)
        {
            e_onDeath.AddListener(callback);
        }

        public void OnDeathRemoveListener(UnityAction<Enemy, Enemy> callback)
        {
            e_onDeath.RemoveListener(callback);
        }

        public void OnEndTraceAddListener(UnityAction<Enemy> callback)
        {
            e_onEndTrace.AddListener(callback);
        }

        public void OnEndTraceRemoveListener(UnityAction<Enemy> callback)
        {
            e_onEndTrace.RemoveListener(callback);
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

        protected void InvokeOnDeath(Enemy nextPhase)
        {
            e_onDeath.Invoke(this, nextPhase);
        }

        private IEnumerator DisableAnimation()
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

            e_onDeath.Invoke(this, null);
            Destroy(gameObject);
        }

        protected void FinishTrace()
        {
            e_onEndTrace.Invoke(this);
            Destroy(gameObject);
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
