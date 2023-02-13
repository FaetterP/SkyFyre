using System.Collections.Generic;

namespace Assets.Scripts.Player.Upgrades
{
    class Turrets1 : IUpgrade
    {
        public int Cost => 400;

        public List<UpgradesType> GetBlockedUpgrades()
        {
            return new List<UpgradesType>() {
                UpgradesType.Turret1,
                UpgradesType.Turret2,
                UpgradesType.Turret3
            };
        }
    }
}
