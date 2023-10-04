using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.Upgrades
{
    [CreateAssetMenu(menuName = "Game/Upgrade")]
    class Upgrade : ScriptableObject
    {
        [SerializeField] private int _cost;
        [SerializeField] private Sprite _icon;
        [SerializeField] private List<UpgradesType> _blockedUpgrades;
        [SerializeField] private UpgradesType _type;

        public int Cost => _cost;
        public Sprite Icon => _icon;
        public List<UpgradesType> GetBlockedUpgrades() => _blockedUpgrades;
        public UpgradesType Type => _type;
    }
}
