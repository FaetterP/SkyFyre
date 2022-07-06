using Assets.Scripts.Utils;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    abstract class Enemy : Damageable
    {
        [SerializeField] private Sprite _sprite;
    }
}
