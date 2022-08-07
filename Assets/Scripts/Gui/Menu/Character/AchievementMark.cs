using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui.Menu.Character
{
    [RequireComponent(typeof(Image))]
    class AchievementMark : MonoBehaviour
    {
        [SerializeField] private AchievementEnum _achievement;
        [SerializeField] private Sprite _enabledSprite;
        [SerializeField] private Image _background;
        private Image _thisImage;

        public AchievementEnum Achievement => _achievement;

        private void Awake()
        {
            _thisImage = GetComponent<Image>();
            SetOpacity(0.5f);
        }

        public void Enable()
        {
            _thisImage.sprite = _enabledSprite;
            SetOpacity(1);
        }

        private void SetOpacity(float value)
        {
            _thisImage.color = new Color(1, 1, 1, value);

            Color color = _background.color;
            color.a = value;
            _background.color = color;
        }
    }
}
