using Assets.Scripts.Player;
using Assets.Scripts.Player.Upgrades;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui.Menu.Shop
{
    class DisplayInventory : MonoBehaviour
    {
        [SerializeField] private Image[] _slots = new Image[3];

        private void OnEnable()
        {
            Inventory.onItemsChanged.AddListener(Display);
        }

        private void OnDisable()
        {
            Inventory.onItemsChanged.RemoveListener(Display);
        }

        private void Display(IReadOnlyCollection<Upgrade> upgrades)
        {
            for (int i = 0; i < upgrades.Count; i++)
            {
                _slots[i].sprite = upgrades.ToArray()[i].Icon;
            }
        }
    }
}
