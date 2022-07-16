using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui
{
    class HealthBar : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private int _maxValue;

        public void Init(int maxValue)
        {
            _maxValue = maxValue;
            _text.text = _maxValue + "/" + _maxValue;
        }

        public void setupValue(int value)
        {
            transform.localScale = new Vector3(1f * value / _maxValue, 1, 1);
            _text.text = value + "/" + _maxValue;
        }
    }
}
