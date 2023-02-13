using Assets.Scripts.Player.Upgrades;
using Assets.Scripts.Utilities;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    class UpgradesController
    {
        private static List<UpgradesType> s_upgrades = new List<UpgradesType>();
        public static Dictionary<UpgradesType, IUpgrade> s_upgradesDictionary = new Dictionary<UpgradesType, IUpgrade>() {
            { UpgradesType.Turret1, new Turrets1() }
        };

        public static EventUpgradesType onBuyItem = new EventUpgradesType();

        public static void AddUpgrade(UpgradesType upgrade)
        {
            if (IsContainsUpgrade(upgrade))
                return;

            s_upgrades.Add(upgrade);
            onBuyItem.Invoke(upgrade);
        }

        public static bool IsContainsUpgrade(UpgradesType upgrade)
        {
            return s_upgrades.Contains(upgrade);
        }

        public static void RemoveUpgrade(UpgradesType upgrade)
        {
            s_upgrades.Remove(upgrade);
        }

        public static List<UpgradesType> GetBlockedUpgrades()
        {
            if (s_upgrades.Count >= 3)
            {
                return new List<UpgradesType>() {
                    UpgradesType.Turret1,
                    UpgradesType.Turret2,
                    UpgradesType.Turret3,
                    UpgradesType.EnhanceTurrets,
                    UpgradesType.ChainTime1,
                    UpgradesType.ChainTime2,
                    UpgradesType.ChainTime3,
                    UpgradesType.HealthToMana1,
                    UpgradesType.HealthToMana2,
                    UpgradesType.HealthToMana3,
                };
            }

            List<UpgradesType> ret = new List<UpgradesType>();
            foreach (UpgradesType upgrade in s_upgrades)
            {
                ret.AddRange(s_upgradesDictionary[upgrade].GetBlockedUpgrades());
            }
            return ret;
        }
    }
}
