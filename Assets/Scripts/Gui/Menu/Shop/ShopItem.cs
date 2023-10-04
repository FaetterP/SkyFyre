using Assets.Scripts.Player;
using Assets.Scripts.Player.Upgrades;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui.Menu.Shop
{
    [RequireComponent(typeof(Image))]
    class ShopItem : MonoBehaviour
    {
        [SerializeField] private Upgrade _upgrade;

        public Upgrade Upgrade => _upgrade;

        private Image _thisImage;
        private bool _isBlocked;

        private void Awake()
        {
            _thisImage = GetComponent<Image>();

            _thisImage.sprite = _upgrade.Icon;
        }

        private void OnMouseDown()
        {
            if (_isBlocked == false)
            {
                Inventory.AddUpgrade(_upgrade);
            }
        }

        public void Disable()
        {
            _isBlocked = true;
            _thisImage.color = new Color(1, 1, 1, 0.5f);
        }

        public void Enable()
        {
            _isBlocked = false;
            _thisImage.color = new Color(1, 1, 1, 1);
        }
    }
}
