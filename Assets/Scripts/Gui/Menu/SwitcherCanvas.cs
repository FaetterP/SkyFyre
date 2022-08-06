using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Gui.Menu
{
    class SwitcherCanvas : MonoBehaviour
    {
        [SerializeField] private List<Canvas> _toEnable;
        [SerializeField] private List<Canvas> _toDisable;

        public void Switch()
        {
            foreach (Canvas canvas in _toDisable)
            {
                canvas.gameObject.SetActive(false);
            }
            foreach (Canvas canvas in _toEnable)
            {
                canvas.gameObject.SetActive(true);
            }
        }
    }
}
