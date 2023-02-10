using Assets.Scripts.Player.Upgrades;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    class UpgradesController
    {
        private static List<UpgradesType> s_upgrades = new List<UpgradesType>();

        public static void AddUpgrade(UpgradesType upgrade)
        {
            if (IsContainsUpgrade(upgrade))
                return;

            s_upgrades.Add(upgrade);
        }

        public static bool IsContainsUpgrade(UpgradesType upgrade)
        {
            return s_upgrades.Contains(upgrade);
        }

        public static void RemoveUpgrade(UpgradesType upgrade)
        {
            s_upgrades.Remove(upgrade);
        }
    }
}
