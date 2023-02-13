using Assets.Scripts.Player;
using Assets.Scripts.Player.Upgrades;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gui.Menu.Shop
{
    class ShopController : MonoBehaviour
    {
        [SerializeField] private ShopItem[] _shopItems;

        private void Awake()
        {
            UpgradesController.onBuyItem.AddListener(ResolveShopItems);
        }

        public void ResolveShopItems(UpgradesType a)
        {
            List<UpgradesType> blockedTypes = UpgradesController.GetBlockedUpgrades();

            foreach (var t in _shopItems)
            {
                if (blockedTypes.Contains(t.UpgradeType))
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
