using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.AttackPatterns
{
    abstract class AttackPattern : MonoBehaviour
    {
        protected Cor[] _attacks;

        private void Start()
        {
            StartCoroutine(StartAttack());
        }

        IEnumerator StartAttack()
        {
            for (int i = 0; ; i = (i + 1) % _attacks.Length)
            {
                yield return _attacks[i]();
            }
        }
    }
}
