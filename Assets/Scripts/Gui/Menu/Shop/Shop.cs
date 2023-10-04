using Assets.Scripts.Player;
using Assets.Scripts.Player.Upgrades;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gui.Menu.Shop
{
    class Shop : MonoBehaviour
    {
        [SerializeField] private ShopItem[] _shopItems;

        private void Awake()
        {
            Inventory.onItemsChanged.AddListener(ResolveShopItems);
        }

        public void ResolveShopItems(IReadOnlyCollection<Upgrade> upgrades)
        {
            List<UpgradesType> blockedTypes = Inventory.GetBlockedUpgrades();

            foreach (var t in _shopItems)
            {
                if (blockedTypes.Contains(t.Upgrade.Type))
                {
                    t.Disable();
                }
                else
                {
                    t.Enable();
                }
            }
        }
    }
}
