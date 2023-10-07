using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stage
{
    [CreateAssetMenu(menuName = "Game/Stage")]
    class Stage : ScriptableObject
    {
        public static Stage CurrentStage;

        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Sprite _backgroundSlow;
        [SerializeField] private Sprite _backgroundMedium;
        [SerializeField] private Sprite _backgroundFast;

        public IReadOnlyCollection<Wave> Waves => _waves.AsReadOnly();
        public Sprite BackgroundSlow => _backgroundSlow;
        public Sprite BackgroundMedium => _backgroundMedium;
        public Sprite BackgroundFast => _backgroundFast;
    }
}