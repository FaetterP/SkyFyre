using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Player.Upgrades
{
    class Turrets1 : IUpgrade
    {
        public int Cost => 400;

        public List<IUpgrade> GetBlockedUpgrades()
        {
            return new List<IUpgrade>();
        }
    }
}
