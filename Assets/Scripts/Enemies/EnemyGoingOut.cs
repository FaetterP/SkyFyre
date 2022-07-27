using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class EnemyGoingOut : Enemy
    {
        [SerializeField] private float _timer;

        private new void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                _thisAnimator.SetBool("isGoAway", true);
            }
        }

        private void OnWentOut()
        {
            Destroy(gameObject);
        }
    }
}
