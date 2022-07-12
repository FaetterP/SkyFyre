using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemies
{
    class Rider1 : Enemy
    {
        private int _spawn;

        public void Init(int spawn)
        {
            _spawn = spawn;
        }
    }
}
