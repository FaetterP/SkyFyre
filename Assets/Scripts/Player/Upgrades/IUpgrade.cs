using System.Collections.Generic;

namespace Assets.Scripts.Player.Upgrades
{
    interface IUpgrade
    {
        public List<IUpgrade> GetBlockedUpgrades();
        public int Cost { get; }
    }
}
