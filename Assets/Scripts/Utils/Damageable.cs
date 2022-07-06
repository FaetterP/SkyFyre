using UnityEngine;

namespace Assets.Scripts.Utils
{
    abstract class Damageable : MonoBehaviour
    {
        protected int _health;

        public void ApplyDamage(int damage)
        {
            _health -= damage;
            OnDamage();

            if (_health < 0)
            {
                OnDeath();
            }
        }

        protected abstract void OnDeath();
        protected virtual void OnDamage() { }
    }
}
