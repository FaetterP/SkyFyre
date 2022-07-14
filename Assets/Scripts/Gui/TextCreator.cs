using UnityEngine;

namespace Assets.Scripts.Gui
{
    class TextCreator : MonoBehaviour
    {
        [SerializeField] private DamageText _damageText;
        private static System.Random rnd = new System.Random();

        public void Create(Vector2 position, int value)
        {
            DamageText created = Instantiate(_damageText, transform);
            created.transform.localPosition = position + new Vector2(rnd.Next(-10, 10), rnd.Next(-10, 10));
            created.Init(value);
        }
    }
}
