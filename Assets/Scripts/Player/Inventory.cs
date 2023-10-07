using Assets.Scripts.Player.Upgrades;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

namespace Assets.Scripts.Player
{
    class Inventory
    {
        public class EventUpgradesType : UnityEvent<IReadOnlyCollection<Upgrade>> { }

        private static List<Upgrade> s_upgrades = new List<Upgrade>();

        public static EventUpgradesType onItemsChanged = new EventUpgradesType();

        public static void AddUpgrade(Upgrade upgrade)
        {
            if (IsContainsUpgrade(upgrade.Type))
                return;

            s_upgrades.Add(upgrade);
            onItemsChanged.Invoke(s_upgrades.AsReadOnly());
        }

        public static bool IsContainsUpgrade(UpgradesType upgrade)
        {
            return s_upgrades.Select(upgrade => upgrade.Type).Contains(upgrade);
        }

        public static void RemoveUpgrade(Upgrade upgrade)
        {
            s_upgrades.Remove(upgrade);
            onItemsChanged.Invoke(s_upgrades.AsReadOnly());
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
            foreach (Upgrade upgrade in s_upgrades)
            {
                ret.AddRange(upgrade.BlockedUpgrades);
            }
            return ret;
        }
    }
}
