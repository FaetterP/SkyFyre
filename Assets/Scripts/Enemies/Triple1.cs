using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Triple1 : Enemy
    {
        [SerializeField] private int _enemyHealth;
        [SerializeField] private int _contectDamage;

        private new void Awake()
        {
            _health = _enemyHealth;

            base.Awake();
        }
    }
}
