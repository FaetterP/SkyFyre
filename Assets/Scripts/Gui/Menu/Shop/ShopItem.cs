using Assets.Scripts.Player;
using Assets.Scripts.Player.Upgrades;
using UnityEngine;

namespace Assets.Scripts.Gui.Menu.Shop
{
    class ShopItem : MonoBehaviour
    {
        [SerializeField] private UpgradesType _upgrade;

        private bool _isBlocked;

        private void OnMouseDown()
        {
            UpgradesController.AddUpgrade(_upgrade);
        }
    }
}
