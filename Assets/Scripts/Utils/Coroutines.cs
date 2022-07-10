using Assets.Scripts.Enemies;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    class Coroutines
    {
        public delegate IEnumerator AttackCoroutine(List<EnemyProjectile> list);
    }
}
