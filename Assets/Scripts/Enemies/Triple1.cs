using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Triple1 : Enemy
    {
        [SerializeField] private float _lifeTime;

        private new void Awake()
        {
            _lifeTime = 0;
            base.Awake();
        }

        private void Update()
        {
            _lifeTime += Time.deltaTime;

            if (_lifeTime >= 10)
            {
                _thisAnimator.SetBool("isGoAway", true);
            }
        }
    }
}
