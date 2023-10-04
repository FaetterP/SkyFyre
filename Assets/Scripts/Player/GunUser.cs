using Assets.Scripts.Player.Upgrades;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(AudioSource))]
    class GunUser : MonoBehaviour
    {
        [SerializeField] private float _shotsPerSecond = 10;
        [SerializeField] private AudioClip _shotSound;
        [SerializeField] private Transform _mainGunPosition;
        [Header("Gun Prefabs")]
        [SerializeField] private Gun _mainGun;
        [SerializeField] private Gun _bulletGun;
        [SerializeField] private Gun _missileGun;
        [SerializeField] private Gun _mainGunPowered;

        private List<Gun> _guns;
        private AudioSource _thisAudioSource;
        private float _delay;
        private float _currentDelay;

        private void Awake()
        {
            _thisAudioSource = GetComponent<AudioSource>();
            _guns = new List<Gun>();
            _guns.Add(Instantiate(_mainGun, _mainGunPosition.position, Quaternion.identity, transform));
            _delay = 1 / _shotsPerSecond;
        }

        private void Start()
        {
            if (Inventory.IsContainsUpgrade(UpgradesType.Turret1))
            {
                ApplyTurrets1();
            }
            if (Inventory.IsContainsUpgrade(UpgradesType.Turret2))
            {
                ApplyTurrets2();
            }
            if (Inventory.IsContainsUpgrade(UpgradesType.Turret3))
            {
                ApplyTurrets3();
            }
            if (Inventory.IsContainsUpgrade(UpgradesType.EnhanceTurrets))
            {
                ApplyTurrets4();
            }
        }

        private void Update()
        {
            TryShot();
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
                foreach (var gun in _guns)
                {
                    gun.Shoot();
                }
            }
        }

        public void ApplyTurrets1()
        {
            _guns.Add(Instantiate(_bulletGun, _mainGunPosition.position + new Vector3(0, 30), Quaternion.identity, transform));
            _guns.Add(Instantiate(_bulletGun, _mainGunPosition.position + new Vector3(0, -30), Quaternion.identity, transform));
        }

        public void ApplyTurrets2()
        {
            ApplyTurrets1();
            _guns.Add(Instantiate(_bulletGun, _mainGunPosition.position + new Vector3(0, 50), Quaternion.identity, transform));
            _guns.Add(Instantiate(_bulletGun, _mainGunPosition.position + new Vector3(0, -50), Quaternion.identity, transform));
        }

        public void ApplyTurrets3()
        {
            ApplyTurrets2();
            _guns.Add(Instantiate(_missileGun, _mainGunPosition.position + new Vector3(-50, 0), Quaternion.identity, transform));
        }

        public void ApplyTurrets4()
        {
            _guns.RemoveAt(0);
            _guns.Add(Instantiate(_mainGunPowered, _mainGunPosition.position + new Vector3(50, 0), Quaternion.identity, transform));
        }
    }
}
