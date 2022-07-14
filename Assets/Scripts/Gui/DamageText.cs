using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Gui
{
    class DamageText : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public void Init(int damage)
        {
            _text.text = damage.ToString();
        }

        private void Start()
        {
            StartCoroutine(Destroy());
        }

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(0.9f);
            Destroy(gameObject);
        }
    }
}
