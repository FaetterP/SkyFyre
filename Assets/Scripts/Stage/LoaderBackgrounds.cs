using UnityEngine;

namespace Assets.Scripts.Stage
{
    class LoaderBackgrounds : MonoBehaviour
    {
        public static Sprite BackgroundSlow;
        public static Sprite BackgroundMedium;
        public static Sprite BackgroundFast;

        [SerializeField] private SpriteRenderer _backgroundSlow;
        [SerializeField] private SpriteRenderer _backgroundMedium;
        [SerializeField] private SpriteRenderer _backgroundFast;

        private void Awake()
        {
            _backgroundFast.sprite = BackgroundFast;
            _backgroundMedium.sprite = BackgroundMedium;
            _backgroundSlow.sprite = BackgroundSlow;
        }
    }
}
