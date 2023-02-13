using System.Collections.Generic;

namespace Assets.Scripts.Player.Upgrades
{
    interface IUpgrade
    {
        public List<UpgradesType> GetBlockedUpgrades();
        public int Cost { get; }
    }
}
