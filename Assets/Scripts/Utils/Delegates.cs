using Assets.Scripts.Enemies;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Utils
{
    class Delegates
    {
        public delegate IEnumerator AttackCoroutine(List<EnemyProjectile> list);
        public delegate void EnemyArgumentFunction(Enemy enemy);
        public delegate void EmptyArgumentFunction();
    }
}
