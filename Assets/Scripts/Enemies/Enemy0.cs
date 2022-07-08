using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Enemy0 : Enemy
    {
        private new void Awake()
        {
            _health = 7;

            base.Awake();
        }
    }
}
