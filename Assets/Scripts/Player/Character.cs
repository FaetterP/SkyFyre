using Assets.Scripts.Enemies;
using Assets.Scripts.Gui;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(AudioSource))]
    class Character : Damageable
    {
        [SerializeField] private Transform _projectileSpawn;
        [SerializeField] private PlayerProjectile _projectile;
        [SerializeField] private float _shotsPerSecond = 10;
        [SerializeField] private HealthBar _healthBar;
        [SerializeField] private AudioClip _shotSound;
        [SerializeField] private AudioClip _hitSound;
        private Animator _thisAnimator;
        private TextCreator _textCreator;
        private AudioSource _thisAudioSource;

        private float _delay;
        private float _currentDelay;

        private void Awake()
        {
            _thisAnimator = GetComponent<Animator>();
            _thisAudioSource = GetComponent<AudioSource>();
            _delay = 1 / _shotsPerSecond;
            _textCreator = FindObjectOfType<TextCreator>();
            _healthBar.Init(_health);
        }

        private void Update()
        {
            Vector2 vec;
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                vec = touch.position;
            }
            else
            {
                vec = Input.mousePosition;
            }
            Vector2 position = Camera.main.ScreenToWorldPoint(vec);
            transform.position = position;
            TryShot();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EnemyProjectile projectile = collision.gameObject.GetComponent<EnemyProjectile>();
            if (projectile != null)
            {
                _textCreator.Create(transform.position, projectile.ContactDamage);
                ApplyDamage(projectile.ContactDamage);
                _healthBar.setupValue(_health);
                return;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                _textCreator.Create(transform.position, enemy.ContactDamage);
                ApplyDamage(enemy.ContactDamage);
                _healthBar.setupValue(_health);
                return;
            }
        }

        protected override void OnDamage()
        {
            _thisAudioSource.PlayOneShot(_hitSound);
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
            Destroy(gameObject);
        }

        private void TryShot()
        {
            if (_currentDelay > 0)
            {
                _currentDelay -= Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.Mouse0) || Input.touchCount > 0)
            {
                _thisAudioSource.PlayOneShot(_shotSound);
                _currentDelay = _delay;
                Instantiate(_projectile, _projectileSpawn.position, Quaternion.identity);
            }
        }
    }
}
