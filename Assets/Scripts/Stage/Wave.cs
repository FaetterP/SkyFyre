using System.Collections.Generic;
using Assets.Scripts.Enemies;
using UnityEngine;

namespace Assets.Scripts.Stage
{
    [CreateAssetMenu(menuName = "Game/Wave")]
    class Wave : ScriptableObject
    {
        [SerializeField] private List<Enemy> _enemies;

        public IReadOnlyCollection<Enemy> Enemies => _enemies.AsReadOnly();
    }
}