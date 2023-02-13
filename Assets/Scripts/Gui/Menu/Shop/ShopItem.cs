using Assets.Scripts.Player;
using Assets.Scripts.Player.Upgrades;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui.Menu.Shop
{
    [RequireComponent(typeof(Image))]
    class ShopItem : MonoBehaviour
    {
        [SerializeField] private UpgradesType _upgrade;

        public UpgradesType UpgradeType => _upgrade;

        private Image _thisSpriteRenderer;
        private bool _isBlocked;

        private void Awake()
        {
            _thisSpriteRenderer = GetComponent<Image>();
        }

        private void OnMouseDown()
        {
            if (_isBlocked == false)
            {
                UpgradesController.AddUpgrade(_upgrade);
            }
        }

        public void Disable()
        {
            _isBlocked = true;
            _thisSpriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }

        public void Enable()
        {
            _isBlocked = false;
            _thisSpriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
}
