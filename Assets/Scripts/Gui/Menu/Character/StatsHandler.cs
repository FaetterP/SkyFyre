using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui.Menu.Character
{
    class StatsHandler : MonoBehaviour
    {
        [SerializeField] private Text _textValue;
        [SerializeField] private Text _textPoints;
        private StatsCounter _stat;

        private void Awake()
        {
            _stat = new StatsCounter(5);
        }

        private void Start()
        {
            UpdateTexts();
        }

        public void AddStat()
        {
            _stat.AddValue();
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            _textValue.text = _stat.Value.ToString();
            _textPoints.text = StatsCounter.Points.ToString();
        }
    }
}
